using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using TSSN.FTE.Insurance.Domain;
using TSSN.FTE.Insurance.Service.Contracts;

namespace TSSN.FTE.Insurance.Web.Infrastructure.Filters
{
    public class AuditAttribute : ActionFilterAttribute
    {
        public IAuditingService AuditingService { get; set; }
        //Our value to handle our AuditingLevel
        public int AuditingLevel { get; set; }

        protected DateTime start_time;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            start_time = DateTime.Now;
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //Stores the Request in an Accessible object
            var request = filterContext.HttpContext.Request;

            //Generate the appropriate key based on the user's Authentication Cookie
            //This is overkill as you should be able to use the Authorization Key from
            //Forms Authentication to handle this. 
            string sessionIdentifier = "";
            try
            {
                sessionIdentifier = string.Join("", MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(request.Cookies[".AspNet.ApplicationCookie"].Value)).Select(s => s.ToString("x2")));
            }
            catch (Exception ex) { Elmah.ErrorSignal.FromCurrentContext().Raise(ex); }

            //Generate an audit
            Audit audit = new Audit()
            {
                SessionID = sessionIdentifier,
                IPAddress = request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? request.UserHostAddress,
                URLAccessed = request.RawUrl,
                TimeAccessed = DateTime.UtcNow,
                UserId = (request.IsAuthenticated) ? HttpContext.Current.User.Identity.GetUserId<int>() : 0,
                Data = SerializeRequest(request),
                Duration = (DateTime.Now - start_time)
            };
            //Stores the Audit in the Database
            AuditingService.CreateAsync(audit);
            
            base.OnResultExecuted(filterContext);
        }

        //This will serialize the Request object based on the level that you determine
        private string SerializeRequest(HttpRequestBase request)
        {
            switch (AuditingLevel)
            {
                //No Request Data will be serialized
                case 0:
                default:
                    return "";
                //Basic Request Serialization - just stores Data
                case 1:
                    return Json.Encode(new { request.Cookies, request.Headers, request.Files });
                //Middle Level - Customize to your Preferences
                case 2:
                    return Json.Encode(new { request.Cookies, request.Headers, request.Files, request.Form, request.QueryString, request.Params });
                //Highest Level - Serialize the entire Request object
                case 3:
                    //We can't simply just Encode the entire request string due to circular references as well
                    //as objects that cannot "simply" be serialized such as Streams, References etc.
                    //return Json.Encode(request);
                    return Json.Encode(new { request.Cookies, request.Headers, request.Files, request.Form, request.QueryString, request.Params });
            }
        }
    }
}
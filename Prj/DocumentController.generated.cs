// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
// 0108: suppress "Foo hides inherited member Foo. Use the new keyword if hiding was intended." when a controller and its abstract parent are both processed
// 0114: suppress "Foo.BarController.Baz()' hides inherited member 'Qux.BarController.Baz()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword." when an action (with an argument) overrides an action in a parent controller
#pragma warning disable 1591, 3008, 3009, 0108, 0114
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace TSSN.FTE.Insurance.Web.Controllers
{
    public partial class DocumentController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected DocumentController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(Task<ActionResult> taskResult)
        {
            return RedirectToAction(taskResult.Result);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(Task<ActionResult> taskResult)
        {
            return RedirectToActionPermanent(taskResult.Result);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.FileResult DownloadPDF()
        {
            return new T4MVC_System_Web_Mvc_FileResult(Area, Name, ActionNames.DownloadPDF);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.JsonResult> GetTransDocumentDetail()
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.GetTransDocumentDetail);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.JsonResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.JsonResult> DeleteDocument()
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.DeleteDocument);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.JsonResult);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public DocumentController Actions { get { return MVC.Document; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Document";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Document";
        [GeneratedCode("T4MVC", "2.0")]
        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string CreateTransDocument = "CreateTransDocument";
            public readonly string DownloadPDF = "DownloadPDF";
            public readonly string GetTransDocumentDetail = "GetTransDocumentDetail";
            public readonly string DeleteDocument = "DeleteDocument";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string CreateTransDocument = "CreateTransDocument";
            public const string DownloadPDF = "DownloadPDF";
            public const string GetTransDocumentDetail = "GetTransDocumentDetail";
            public const string DeleteDocument = "DeleteDocument";
        }


        static readonly ActionParamsClass_DownloadPDF s_params_DownloadPDF = new ActionParamsClass_DownloadPDF();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_DownloadPDF DownloadPDFParams { get { return s_params_DownloadPDF; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_DownloadPDF
        {
            public readonly string transId = "transId";
        }
        static readonly ActionParamsClass_GetTransDocumentDetail s_params_GetTransDocumentDetail = new ActionParamsClass_GetTransDocumentDetail();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_GetTransDocumentDetail GetTransDocumentDetailParams { get { return s_params_GetTransDocumentDetail; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_GetTransDocumentDetail
        {
            public readonly string transId = "transId";
        }
        static readonly ActionParamsClass_DeleteDocument s_params_DeleteDocument = new ActionParamsClass_DeleteDocument();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_DeleteDocument DeleteDocumentParams { get { return s_params_DeleteDocument; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_DeleteDocument
        {
            public readonly string transId = "transId";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
            }
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_DocumentController : TSSN.FTE.Insurance.Web.Controllers.DocumentController
    {
        public T4MVC_DocumentController() : base(Dummy.Instance) { }

        [NonAction]
        partial void CreateTransDocumentOverride(T4MVC_System_Web_Mvc_JsonResult callInfo);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.JsonResult> CreateTransDocument()
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.CreateTransDocument);
            CreateTransDocumentOverride(callInfo);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.JsonResult);
        }

        [NonAction]
        partial void DownloadPDFOverride(T4MVC_System_Web_Mvc_FileResult callInfo, int transId);

        [NonAction]
        public override System.Web.Mvc.FileResult DownloadPDF(int transId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_FileResult(Area, Name, ActionNames.DownloadPDF);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "transId", transId);
            DownloadPDFOverride(callInfo, transId);
            return callInfo;
        }

        [NonAction]
        partial void GetTransDocumentDetailOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, int transId);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.JsonResult> GetTransDocumentDetail(int transId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.GetTransDocumentDetail);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "transId", transId);
            GetTransDocumentDetailOverride(callInfo, transId);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.JsonResult);
        }

        [NonAction]
        partial void DeleteDocumentOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, long transId);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.JsonResult> DeleteDocument(long transId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.DeleteDocument);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "transId", transId);
            DeleteDocumentOverride(callInfo, transId);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.JsonResult);
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114

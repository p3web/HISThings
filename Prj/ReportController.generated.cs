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
    public partial class ReportController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected ReportController(Dummy d) { }

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
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.JsonResult> GetSentTransList()
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.GetSentTransList);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.JsonResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> ExportToExcelSentTrans()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ExportToExcelSentTrans);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult SendedTransReport()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.SendedTransReport);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ReportController Actions { get { return MVC.Report; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Report";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Report";
        [GeneratedCode("T4MVC", "2.0")]
        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string SentTransReport = "SentTransReport";
            public readonly string GetSentTransList = "GetSentTransList";
            public readonly string ExportToExcelSentTrans = "ExportToExcelSentTrans";
            public readonly string SendedTransReport = "SendedTransReport";
            public readonly string GetReportSnapshot = "GetReportSnapshot";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string SentTransReport = "SentTransReport";
            public const string GetSentTransList = "GetSentTransList";
            public const string ExportToExcelSentTrans = "ExportToExcelSentTrans";
            public const string SendedTransReport = "SendedTransReport";
            public const string GetReportSnapshot = "GetReportSnapshot";
        }


        static readonly ActionParamsClass_GetSentTransList s_params_GetSentTransList = new ActionParamsClass_GetSentTransList();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_GetSentTransList GetSentTransListParams { get { return s_params_GetSentTransList; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_GetSentTransList
        {
            public readonly string jQueryDataTablesModel = "jQueryDataTablesModel";
            public readonly string searchModel = "searchModel";
        }
        static readonly ActionParamsClass_ExportToExcelSentTrans s_params_ExportToExcelSentTrans = new ActionParamsClass_ExportToExcelSentTrans();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ExportToExcelSentTrans ExportToExcelSentTransParams { get { return s_params_ExportToExcelSentTrans; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ExportToExcelSentTrans
        {
            public readonly string searchModel = "searchModel";
        }
        static readonly ActionParamsClass_SendedTransReport s_params_SendedTransReport = new ActionParamsClass_SendedTransReport();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_SendedTransReport SendedTransReportParams { get { return s_params_SendedTransReport; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_SendedTransReport
        {
            public readonly string searchModel = "searchModel";
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
                public readonly string SentTransReport = "SentTransReport";
            }
            public readonly string SentTransReport = "~/Views/Report/SentTransReport.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_ReportController : TSSN.FTE.Insurance.Web.Controllers.ReportController
    {
        public T4MVC_ReportController() : base(Dummy.Instance) { }

        [NonAction]
        partial void SentTransReportOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> SentTransReport()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.SentTransReport);
            SentTransReportOverride(callInfo);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void GetSentTransListOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, TSSN.FTE.Insurance.Web.CustomModelBinders.JQueryDataTablesModel jQueryDataTablesModel, TSSN.FTE.Insurance.DTO.SearchTransDto searchModel);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.JsonResult> GetSentTransList(TSSN.FTE.Insurance.Web.CustomModelBinders.JQueryDataTablesModel jQueryDataTablesModel, TSSN.FTE.Insurance.DTO.SearchTransDto searchModel)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.GetSentTransList);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "jQueryDataTablesModel", jQueryDataTablesModel);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "searchModel", searchModel);
            GetSentTransListOverride(callInfo, jQueryDataTablesModel, searchModel);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.JsonResult);
        }

        [NonAction]
        partial void ExportToExcelSentTransOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, TSSN.FTE.Insurance.DTO.SearchTransDto searchModel);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> ExportToExcelSentTrans(TSSN.FTE.Insurance.DTO.SearchTransDto searchModel)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ExportToExcelSentTrans);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "searchModel", searchModel);
            ExportToExcelSentTransOverride(callInfo, searchModel);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void SendedTransReportOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, TSSN.FTE.Insurance.DTO.SearchTransDto searchModel);

        [NonAction]
        public override System.Web.Mvc.ActionResult SendedTransReport(TSSN.FTE.Insurance.DTO.SearchTransDto searchModel)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.SendedTransReport);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "searchModel", searchModel);
            SendedTransReportOverride(callInfo, searchModel);
            return callInfo;
        }

        [NonAction]
        partial void GetReportSnapshotOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> GetReportSnapshot()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.GetReportSnapshot);
            GetReportSnapshotOverride(callInfo);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114

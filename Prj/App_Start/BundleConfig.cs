using System.Web;
using System.Web.Optimization;

namespace TSSN.FTE.Insurance.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                 "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/unobtrusiveajax").Include(
                        "~/Scripts/jquery.unobtrusive-ajax.js"));            

             // Use the development version of Modernizr to develop with and learn from. Then, when you're
             // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
             bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap-rtl.min.js"
                      //,"~/Scripts/respond.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/content/bootstrap-rtl.min.css",
                      "~/content/core_green.css",
                      "~/content/icons.css",
                      "~/content/components_green.css",
                      "~/content/pages_green.css",
                      "~/content/menu_green.css",
                      "~/content/responsive.css",
                      "~/plugins/switchery/switchery.min.css",
                      "~/plugins/select2/select2.css",
                       "~/plugins/notifications/notification.css",
                      "~/content/site.css",
                      "~/content/PGridStyle.css"));

            bundles.Add(new ScriptBundle("~/bundle/common").Include(
                    "~/Scripts/detect.js",
                    "~/Scripts/fastclick.js",
                    "~/Scripts/jquery.blockUI.js",
                    "~/Scripts/waves.js",
                    "~/Scripts/wow.min.js",
                    "~/Scripts/jquery.nicescroll.js",
                    "~/Scripts/jquery.scrollTo.min.js",
                    "~/plugins/switchery/switchery.min.js",
                    "~/Scripts/jquery.slimscroll.js",
                    "~/plugins/notifications/notify.min.js",
                    "~/plugins/notifications/notify-metro.js",
                    "~/plugins/select2/select2.js",                    
                    "~/Scripts/customs/notify.alerts.js",
                    "~/Scripts/customs/ajax.methods.js",
                    "~/Scripts/customs/gridCode.js",
                    "~/Scripts/customs/FuncHandler.js",
                    "~/Scripts/customs/ajax.js",
                    "~/Scripts/customs/DateConvertor.js"));

            bundles.Add(new ScriptBundle("~/bundle/core-app").Include(
                    "~/Scripts/jquery.core.js",
                    "~/Scripts/jquery.app.js"));

            // data table
            bundles.Add(new StyleBundle("~/Content/datatable").Include(
                      "~/plugins/datatables/jquery.dataTables.min.css",
                      "~/plugins/datatables/buttons.bootstrap.min.css",
                      "~/plugins/datatables/fixedHeader.bootstrap.min.css",
                      "~/plugins/datatables/responsive.bootstrap.min.css",
                      "~/plugins/datatables/scroller.bootstrap.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/datatable").Include(
                      "~/plugins/datatables/jquery.dataTables.min.js",
                      "~/plugins/datatables/dataTables.bootstrap.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/autocomplete").Include(
                      "~/plugins/jquery-autocomplete/jquery.autocomplete.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
            //          "~/plugins/jquery-ui/jquery-ui.js"));

            bundles.Add(new StyleBundle("~/Content/fileinput").Include(
                "~/plugins/bootstrap-fileinput/css/fileinput.css"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-fileinput").Include(
                "~/plugins/bootstrap-fileinput/js/fileinput.js",
                "~/plugins/bootstrap-fileinput/js/locales/fa.js"));

        }
    }
}

using System.Web;
using System.Web.Optimization;

namespace ATS.Presentation.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/plugins/jQuery/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Content/plugins/jqueryValidate/jquery.validate*",
                        "~/Content/plugins/jqueryValidate/additional-methods.min.js",
                        "~/Content/plugins/jqueryValidate/add_method_for_chrome.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Content/plugins/modernizr/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/bootstrap/js/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/toastr").Include(
                      "~/Content/plugins/toastr/scripts/toastr.js"));

            bundles.Add(new ScriptBundle("~/bundles/dataPicker").Include(
                      "~/Content/plugins/datepicker/bootstrap-datepicker.js",
                      "~/Content/plugins/datepicker/locales/bootstrap-datepicker.pt-BR.js"));

            bundles.Add(new ScriptBundle("~/bundles/moment").Include(
                      "~/Content/plugins/moment/moment.js",
                      "~/Content/plugins/moment/moment-with-locales.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap/css/bootstrap.css",
                      "~/Content/plugins/font-awesome-4.6.3/css/font-awesome.css",
                      "~/Content/plugins/ionicons-2.0.1/css/ionicons.css",
                      "~/Content/plugins/toastr/content/toastr.css",
                      "~/Content/custom/css/AdminLTE.css",
                      "~/Content/custom/css/skins/skin-yellow.css",
                      "~/Content/custom/css/CustomStyle.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}

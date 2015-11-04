using System.Web.Optimization;

namespace CashRegister.Angular
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/angularjs").Include(
                "~/Scripts/angular.min.js",
                "~/Scripts/angular-route.min.js",
                "~/Scripts/angular-ui-router.min.js",
                "~/Scripts/angular-ui/ui-bootstrap.min.js",
                "~/Scripts/angular-ui/ui-bootstrap-tpls.min.js",
                "~/Scripts/ui-grid.min.js",
                "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/angularModules").Include(
                "~/Modules/CashRegisterModule.js"));

            bundles.Add(new ScriptBundle("~/bundles/controllers").IncludeDirectory(
                "~/WebControllers", "*.js"));

            bundles.Add(new ScriptBundle("~/bundles/directives").Include(
                "~/Directives/AutoFocus.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.min.css",
                "~/Content/bootstrap-cosmo/cosmo.min.css",
                "~/Content/ui-grid.min.css",
                "~/Content/ui-bootstrap-csp.css"));
        }
    }
}
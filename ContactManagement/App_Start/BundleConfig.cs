using System.Web.Optimization;

namespace ContactManagement
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval")
                .Include("~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr")
                .Include("~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                .Include("~/Scripts/bootstrap.js")
                .Include("~/Scripts/ui-bootstrap-tpls-1.1.0.js")
                .Include("~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/animations.css")
                .Include("~/Content/bootstrap.css")
                .Include("~/Content/contactMgr.css")
                .Include("~/Content/normalize.css"));

            bundles.Add(new ScriptBundle("~/bundles/angular")
                    .Include("~/Scripts/angular.js")
                    .Include("~/Scripts/angular-animate.js")
                    .Include("~/Scripts/angular-cookies.js")
                    .Include("~/Scripts/angular-route.js")
                    .Include("~/Scripts/angular-sanitize.js"));

            bundles.Add(new ScriptBundle("~/bundles/app")
                .Include("~/Scripts/app/app.js")
                .Include("~/Scripts/app/controllers/contacts.main.js")
                .Include("~/Scripts/app/factories/contacts.resource.js")
                .Include("~/Scripts/app/factories/contacts.resource.category.js")
                .Include("~/Scripts/app/factories/contacts.resource.contact.js")
                .Include("~/Scripts/app/factories/contacts.resource.string.js"));
        }
    }
}
using System.Web;
using System.Web.Optimization;

namespace FixedAsset
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/Content/Layoutjs").Include(
           "~/Content/Regna/assets/vendor/purecounter/purecounter.js",
           "~/Content/Regna/assets/vendor/aos/aos.js",
           "~/Content/Regna/assets/vendor/bootstrap/js/bootstrap.bundle.min.js",
           "~/Content/Regna/assets/vendor/glightbox/js/glightbox.min.js",
           "~/Content/Regna/assets/vendor/isotope-layout/isotope.pkgd.min.js",
           "~/Content/Regna/assets/vendor/swiper/swiper-bundle.min.js",
           "~/Content/Regna/assets/vendor/php-email-form/validate.js",
           "~/Content/Regna/assets/js/main.js"));

            bundles.Add(new StyleBundle("~/Content/Layoutcss").Include(
                 "~/Content/consula/DataTables/DataTables-1.10.24/css/jquery.dataTables.min.css",
           "~/Content/consula/DataTables/DataTables-1.10.24/css/dataTables.semanticui.min.css",
               "~/Content/consula/DataTables/DataTables-1.10.24/css/dataTables.jqueryui.min.css",
                   "~/Content/consula/DataTables/DataTables-1.10.24/css/dataTables.foundation.min.css",
                      "~/Content/Regna/assets/vendor/font/googleapis.css",
                      "~/Content/Regna/assets/vendor/aos/aos.css",
                      "~/Content/Regna/assets/vendor/bootstrap/css/bootstrap.min.css",
                      "~/Content/Regna/assets/vendor/bootstrap-icons/bootstrap-icons.css",
                      "~/Content/consula/DataTables/DataTables-1.10.24/css/dataTables.bootstrap4.min.css",
                      "~/Content/consula/DataTables/DataTables-1.10.24/css/dataTables.bootstrap.min.css",

                      "~/Content/Regna/assets/vendor/boxicons/css/boxicons.min.css",
                      "~/Content/Regna/assets/vendor/glightbox/css/glightbox.min.css",
                      "~/Content/Regna/assets/vendor/swiper/swiper-bundle.min.css",
                      "~/Content/Regna/assets/css/style.css"));
            //BundleTable.EnableOptimizations = true;




            bundles.Add(new ScriptBundle("~/Content/EkitiJs").Include(
"~/Content/consula/DataTables/DataTables-1.10.24/js/jquery.dataTables.min.js",
"~/Content/consula/DataTables/DataTables-1.10.24/js/dataTables.semanticui.min.js",
"~/Content/consula/DataTables/DataTables-1.10.24/js/dataTables.jqueryui.min.js",
"~/Content/consula/DataTables/DataTables-1.10.24/js/dataTables.foundation.min.js",
"~/Content/consula/DataTables/DataTables-1.10.24/js/dataTables.bootstrap4.min.js",
"~/Content/consula/DataTables/DataTables-1.10.24/js/dataTables.bootstrap.min.js",
//"~/Content/consula/consula/js/SweetAlert.js",
"~/Content/consula/consula/js/SweetAlert2.js"
//"~/Content/consula/consula/js/SweetAlert3.js"
//"~/Content/consula/DataTables/DataTables-1.10.24/js/dataTables.bootstrap.js",

//"~/Content/consula/DataTables/DataTables-1.10.24/js/dataTables.bootstrap4.js",

//"~/Content/consula/DataTables/DataTables-1.10.24/js/dataTables.foundation.js",

//"~/Content/consula/DataTables/DataTables-1.10.24/js/dataTables.jqueryui.js",

//"~/Content/consula/DataTables/DataTables-1.10.24/js/dataTables.semanticui.js",

//"~/Content/consula/DataTables/DataTables-1.10.24/js/jquery.dataTables.js",
));


            bundles.Add(new StyleBundle("~/Content/EkitiCss").Include(
       "~/Content/consula/DataTables/DataTables-1.10.24/css/jquery.dataTables.min.css",
           "~/Content/consula/DataTables/DataTables-1.10.24/css/dataTables.semanticui.min.css",
               "~/Content/consula/DataTables/DataTables-1.10.24/css/dataTables.jqueryui.min.css",
                   "~/Content/consula/DataTables/DataTables-1.10.24/css/dataTables.foundation.min.css",
                       "~/Content/consula/DataTables/DataTables-1.10.24/css/dataTables.bootstrap4.min.css",
                          "~/Content/consula/DataTables/DataTables-1.10.24/css/dataTables.bootstrap.min.css"
//"~/Content/consula/DataTables/DataTables-1.10.24/css/dataTables.bootstrap.css",

//"~/Content/consula/DataTables/DataTables-1.10.24/css/dataTables.bootstrap4.css",

//"~/Content/consula/DataTables/DataTables-1.10.24/css/dataTables.foundation.css",

//"~/Content/consula/DataTables/DataTables-1.10.24/css/dataTables.jqueryui.css",

//"~/Content/consula/DataTables/DataTables-1.10.24/css/dataTables.semanticui.css",

//"~/Content/consula/DataTables/DataTables-1.10.24/css/jquery.dataTables.css",
));
        }
    }
}

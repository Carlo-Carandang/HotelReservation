using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;

namespace Hotel_Reserve.Controllers
{

    namespace BootstrapSupport
    {
        public class BootstrapBundleConfig
        {
            public static void RegisterBundles(BundleCollection bundles)
            {
                bundles.Add(new ScriptBundle("~/js").Include(
                    "~/Scripts/jquery-1.*",
                    "~/Scripts/bootstrap.js",
                    "~/Scripts/bootstrap-datepicker.js", // ** NEW for Bootstrap Datepicker
                    "~/Scripts/jquery.validate.js",
                    "~/scripts/jquery.validate.unobtrusive.js",
                    "~/Scripts/jquery.validate.unobtrusive-custom-for-bootstrap.js"
                    ));

                bundles.Add(new StyleBundle("~/content/css").Include(
                    "~/Content/bootstrap.css",
                    "~/Content/bootstrap-datepicker.css" // ** NEW for Bootstrap Datepicker
                    ));

                bundles.Add(new StyleBundle("~/content/css-responsive").Include(
                    "~/Content/bootstrap-responsive.css"
                    ));
            }
        }
    }

}
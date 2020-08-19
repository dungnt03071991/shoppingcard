using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace VPExam
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("ItemDataList", "ItemDataList", new { controller = "Item", action = "ItemList" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Item", action = "Index", id = UrlParameter.Optional }

            );
            routes.MapRoute("CartDataList", "CartDataList", new { controller = "Cart", action = "CartList" });

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Milestones
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            //default routing
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //routing for news content
            routes.MapRoute(
                "NewsContent",
                "News/Details/{id}/{title}",//URL
               new
               {
                   controller = "News",
                   action = "Details",
                   //id = UrlParameter.Optional,
                   title = UrlParameter.Optional
               },
              new {
                  id = @"\d+" //URL constraints
              }
           );
        }

    }
    public class HyphenatedRouteHandler : MvcRouteHandler
    {
        protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            requestContext.RouteData.Values["title"] = requestContext.RouteData.Values["title"].ToString().Replace("%20", "-");
            //requestContext.RouteData.Values["action"] = requestContext.RouteData.Values["action"].ToString().Replace("%20", "-");
            return base.GetHttpHandler(requestContext);
        }
    }
}
using MaintainContacts.Main.Controllers;
using MaintainContacts.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MaintainContacts.Main
{
    public class MaintainContactsMain : System.Web.HttpApplication
    {
        private ILoggerRepository _iLoggerRepository;

        protected void Application_Start()
        {
            Database.SetInitializer<Entities.DbContactsContext>(null);
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BundleTable.EnableOptimizations = true;
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            _iLoggerRepository = DependencyResolver.Current.GetService<ILoggerRepository>();
            var exMessage = new StringBuilder();

            try
            {
                var httpContext = ((MaintainContactsMain)sender).Context;
                var currentController = string.Empty;
                var currentAction = string.Empty;

                if (httpContext != null && httpContext.Error != null)
                {
                    var currentRouteData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));

                    if (currentRouteData != null)
                    {
                        if (!String.IsNullOrEmpty(Convert.ToString(currentRouteData.Values["controller"])))
                        {
                            currentController = Convert.ToString(currentRouteData.Values["controller"]);
                        }

                        if (!String.IsNullOrEmpty(Convert.ToString(currentRouteData.Values["action"])))
                        {
                            currentAction = Convert.ToString(currentRouteData.Values["action"]);
                        }
                    }

                    exMessage.Append(string.Concat("Controller:", currentController, Environment.NewLine));
                    exMessage.Append(string.Concat("Action:", currentAction, Environment.NewLine));

                    _iLoggerRepository.Error(Convert.ToString(exMessage), httpContext.Error);
                }

                var ex = Server.GetLastError();
                    
                if(ex != null)
                {
                    exMessage.Clear();
                    exMessage.Append(string.Concat("Start GetLastError", Environment.NewLine));
                    _iLoggerRepository.Error(Convert.ToString(exMessage), ex);
                }

                httpContext.ClearError();
                httpContext.Response.Clear();
                httpContext.Response.StatusCode = ex is HttpException ? ((HttpException)ex).GetHttpCode() : 500;
                httpContext.Response.TrySkipIisCustomErrors = true;
                
                var errorController = new ErrorController();
                var errorRouteData = new RouteData();
                var action = "Error";

                if (ex is HttpException)
                {
                    var httpEx = ex as HttpException;

                    switch (httpEx.GetHttpCode())
                    {
                        case 404:
                            action = "PageNotFound";
                            break;

                        default:
                            action = "Error";
                            break;
                    }
                }

                errorRouteData.Values["controller"] = "Error";
                errorRouteData.Values["action"] = action;
                ((IController)errorController).Execute(new RequestContext(new HttpContextWrapper(httpContext), errorRouteData));
            }
            catch (Exception ex)
            {
                exMessage.Clear();
                exMessage.Append(string.Concat("Exception Application_Error", Environment.NewLine));
                _iLoggerRepository.Error(Convert.ToString(exMessage), ex);
            }
        }
    }
}

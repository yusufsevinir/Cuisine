// Type: System.Web.Mvc.Controller
// Assembly: System.Web.Mvc, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Assembly location: C:\Program Files\Microsoft ASP.NET\ASP.NET MVC 3\Assemblies\System.Web.Mvc.dll

using System;
using System.IO;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Routing;

namespace System.Web.Mvc
{
    public abstract class Controller : ControllerBase, IActionFilter, IAuthorizationFilter, IDisposable, IExceptionFilter, IResultFilter
    {
        public IActionInvoker ActionInvoker { get; set; }
        protected internal ModelBinderDictionary Binders { get; set; }
        public HttpContextBase HttpContext { get; }
        public ModelStateDictionary ModelState { get; }
        public HttpRequestBase Request { get; }
        public HttpResponseBase Response { get; }
        public RouteData RouteData { get; }
        public HttpServerUtilityBase Server { get; }
        public HttpSessionStateBase Session { get; }
        public ITempDataProvider TempDataProvider { get; set; }
        public UrlHelper Url { get; set; }
        public IPrincipal User { get; }

        #region IActionFilter Members

        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext);
        void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext);

        #endregion

        #region IAuthorizationFilter Members

        void IAuthorizationFilter.OnAuthorization(AuthorizationContext filterContext);

        #endregion

        #region IDisposable Members

        public void Dispose();

        #endregion

        #region IExceptionFilter Members

        void IExceptionFilter.OnException(ExceptionContext filterContext);

        #endregion

        #region IResultFilter Members

        void IResultFilter.OnResultExecuting(ResultExecutingContext filterContext);
        void IResultFilter.OnResultExecuted(ResultExecutedContext filterContext);

        #endregion

        protected internal ContentResult Content(string content);
        protected internal ContentResult Content(string content, string contentType);
        protected internal virtual ContentResult Content(string content, string contentType, Encoding contentEncoding);
        protected virtual IActionInvoker CreateActionInvoker();
        protected virtual ITempDataProvider CreateTempDataProvider();
        protected virtual void Dispose(bool disposing);
        protected override void ExecuteCore();
        protected internal FileContentResult File(byte[] fileContents, string contentType);
        protected internal virtual FileContentResult File(byte[] fileContents, string contentType, string fileDownloadName);
        protected internal FileStreamResult File(Stream fileStream, string contentType);
        protected internal virtual FileStreamResult File(Stream fileStream, string contentType, string fileDownloadName);
        protected internal FilePathResult File(string fileName, string contentType);
        protected internal virtual FilePathResult File(string fileName, string contentType, string fileDownloadName);
        protected virtual void HandleUnknownAction(string actionName);
        protected internal HttpNotFoundResult HttpNotFound();
        protected internal virtual HttpNotFoundResult HttpNotFound(string statusDescription);
        protected internal virtual JavaScriptResult JavaScript(string script);
        protected internal JsonResult Json(object data);
        protected internal JsonResult Json(object data, string contentType);
        protected internal virtual JsonResult Json(object data, string contentType, Encoding contentEncoding);
        protected internal JsonResult Json(object data, JsonRequestBehavior behavior);
        protected internal JsonResult Json(object data, string contentType, JsonRequestBehavior behavior);
        protected internal virtual JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior);
        protected override void Initialize(RequestContext requestContext);
        protected virtual void OnActionExecuting(ActionExecutingContext filterContext);
        protected virtual void OnActionExecuted(ActionExecutedContext filterContext);
        protected virtual void OnAuthorization(AuthorizationContext filterContext);
        protected virtual void OnException(ExceptionContext filterContext);
        protected virtual void OnResultExecuted(ResultExecutedContext filterContext);
        protected virtual void OnResultExecuting(ResultExecutingContext filterContext);
        protected internal PartialViewResult PartialView();
        protected internal PartialViewResult PartialView(object model);
        protected internal PartialViewResult PartialView(string viewName);
        protected internal virtual PartialViewResult PartialView(string viewName, object model);
        protected internal virtual RedirectResult Redirect(string url);
        protected internal virtual RedirectResult RedirectPermanent(string url);
        protected internal RedirectToRouteResult RedirectToAction(string actionName);
        protected internal RedirectToRouteResult RedirectToAction(string actionName, object routeValues);
        protected internal RedirectToRouteResult RedirectToAction(string actionName, RouteValueDictionary routeValues);
        protected internal RedirectToRouteResult RedirectToAction(string actionName, string controllerName);
        protected internal RedirectToRouteResult RedirectToAction(string actionName, string controllerName, object routeValues);
        protected internal virtual RedirectToRouteResult RedirectToAction(string actionName, string controllerName, RouteValueDictionary routeValues);
        protected internal RedirectToRouteResult RedirectToActionPermanent(string actionName);
        protected internal RedirectToRouteResult RedirectToActionPermanent(string actionName, object routeValues);
        protected internal RedirectToRouteResult RedirectToActionPermanent(string actionName, RouteValueDictionary routeValues);
        protected internal RedirectToRouteResult RedirectToActionPermanent(string actionName, string controllerName);
        protected internal RedirectToRouteResult RedirectToActionPermanent(string actionName, string controllerName, object routeValues);
        protected internal virtual RedirectToRouteResult RedirectToActionPermanent(string actionName, string controllerName, RouteValueDictionary routeValues);
        protected internal RedirectToRouteResult RedirectToRoute(object routeValues);
        protected internal RedirectToRouteResult RedirectToRoute(RouteValueDictionary routeValues);
        protected internal RedirectToRouteResult RedirectToRoute(string routeName);
        protected internal RedirectToRouteResult RedirectToRoute(string routeName, object routeValues);
        protected internal virtual RedirectToRouteResult RedirectToRoute(string routeName, RouteValueDictionary routeValues);
        protected internal RedirectToRouteResult RedirectToRoutePermanent(object routeValues);
        protected internal RedirectToRouteResult RedirectToRoutePermanent(RouteValueDictionary routeValues);
        protected internal RedirectToRouteResult RedirectToRoutePermanent(string routeName);
        protected internal RedirectToRouteResult RedirectToRoutePermanent(string routeName, object routeValues);
        protected internal virtual RedirectToRouteResult RedirectToRoutePermanent(string routeName, RouteValueDictionary routeValues);
        protected internal bool TryUpdateModel<TModel>(TModel model) where TModel : class;
        protected internal bool TryUpdateModel<TModel>(TModel model, string prefix) where TModel : class;
        protected internal bool TryUpdateModel<TModel>(TModel model, string[] includeProperties) where TModel : class;
        protected internal bool TryUpdateModel<TModel>(TModel model, string prefix, string[] includeProperties) where TModel : class;
        protected internal bool TryUpdateModel<TModel>(TModel model, string prefix, string[] includeProperties, string[] excludeProperties) where TModel : class;
        protected internal bool TryUpdateModel<TModel>(TModel model, IValueProvider valueProvider) where TModel : class;
        protected internal bool TryUpdateModel<TModel>(TModel model, string prefix, IValueProvider valueProvider) where TModel : class;
        protected internal bool TryUpdateModel<TModel>(TModel model, string[] includeProperties, IValueProvider valueProvider) where TModel : class;
        protected internal bool TryUpdateModel<TModel>(TModel model, string prefix, string[] includeProperties, IValueProvider valueProvider) where TModel : class;
        protected internal bool TryUpdateModel<TModel>(TModel model, string prefix, string[] includeProperties, string[] excludeProperties, IValueProvider valueProvider) where TModel : class;
        protected internal bool TryValidateModel(object model);
        protected internal bool TryValidateModel(object model, string prefix);
        protected internal void UpdateModel<TModel>(TModel model) where TModel : class;
        protected internal void UpdateModel<TModel>(TModel model, string prefix) where TModel : class;
        protected internal void UpdateModel<TModel>(TModel model, string[] includeProperties) where TModel : class;
        protected internal void UpdateModel<TModel>(TModel model, string prefix, string[] includeProperties) where TModel : class;
        protected internal void UpdateModel<TModel>(TModel model, string prefix, string[] includeProperties, string[] excludeProperties) where TModel : class;
        protected internal void UpdateModel<TModel>(TModel model, IValueProvider valueProvider) where TModel : class;
        protected internal void UpdateModel<TModel>(TModel model, string prefix, IValueProvider valueProvider) where TModel : class;
        protected internal void UpdateModel<TModel>(TModel model, string[] includeProperties, IValueProvider valueProvider) where TModel : class;
        protected internal void UpdateModel<TModel>(TModel model, string prefix, string[] includeProperties, IValueProvider valueProvider) where TModel : class;
        protected internal void UpdateModel<TModel>(TModel model, string prefix, string[] includeProperties, string[] excludeProperties, IValueProvider valueProvider) where TModel : class;
        protected internal void ValidateModel(object model);
        protected internal void ValidateModel(object model, string prefix);
        protected internal ViewResult View();
        protected internal ViewResult View(object model);
        protected internal ViewResult View(string viewName);
        protected internal ViewResult View(string viewName, string masterName);
        protected internal ViewResult View(string viewName, object model);
        protected internal virtual ViewResult View(string viewName, string masterName, object model);
        protected internal ViewResult View(IView view);
        protected internal virtual ViewResult View(IView view, object model);
    }
}

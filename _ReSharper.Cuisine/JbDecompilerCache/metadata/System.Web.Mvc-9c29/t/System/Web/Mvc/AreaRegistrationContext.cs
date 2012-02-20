// Type: System.Web.Mvc.AreaRegistrationContext
// Assembly: System.Web.Mvc, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Assembly location: C:\Program Files\Microsoft ASP.NET\ASP.NET MVC 3\Assemblies\System.Web.Mvc.dll

using System.Collections.Generic;
using System.Web.Routing;

namespace System.Web.Mvc
{
    public class AreaRegistrationContext
    {
        public AreaRegistrationContext(string areaName, RouteCollection routes);
        public AreaRegistrationContext(string areaName, RouteCollection routes, object state);
        public string AreaName { get; }
        public ICollection<string> Namespaces { get; }
        public RouteCollection Routes { get; }
        public object State { get; }
        public Route MapRoute(string name, string url);
        public Route MapRoute(string name, string url, object defaults);
        public Route MapRoute(string name, string url, object defaults, object constraints);
        public Route MapRoute(string name, string url, string[] namespaces);
        public Route MapRoute(string name, string url, object defaults, string[] namespaces);
        public Route MapRoute(string name, string url, object defaults, object constraints, string[] namespaces);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaferProject.INFO
{
    class RouteInfo
    {
        private string routeId;
        private string currRoute;
        private string nextRoute;

        public RouteInfo() { }

        public RouteInfo(string routeId, string currRoute, string nextRoute)
        {
            this.routeId = routeId;
            this.currRoute = currRoute;
            this.nextRoute = nextRoute;
        }
        public void setNextRoute(string nextRoute)
        {
            this.nextRoute = nextRoute;
        }
        public string getNextRoute()
        {
            return nextRoute;
        }
        public void setCurrRoute(string currRoute)
        {
            this.currRoute = currRoute;
        }
        public string getCurrRoute()
        {
            return currRoute;
        }
        public void setRouteId(string routeId)
        {
            this.routeId = routeId;
        }
        public string getRouteId()
        {
            return routeId;
        }
    }
}

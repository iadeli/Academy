using System;
using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;

namespace Academy.WebUI
{
    public class CustomControllerFactory : DefaultControllerFactory
    {
        private readonly IWindsorContainer _container;
        public CustomControllerFactory(IWindsorContainer container)
        {
            _container = container;
        }

        [DebuggerHidden]
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType != null)
                return (IController)_container.Resolve(controllerType);
            return base.GetControllerInstance(requestContext, controllerType);
        }
    }
}
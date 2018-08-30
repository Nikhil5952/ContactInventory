
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: OwinStartup(typeof(ContactInventory.API.Startup))]

namespace ContactInventory.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {            
            //app.Use(WebApiConfig.Register());
        }
    }
}
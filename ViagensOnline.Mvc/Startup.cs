using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using ViagensOnline.Mvc.Models;

[assembly: OwinStartup(typeof(ViagensOnline.Mvc.Startup))]

namespace ViagensOnline.Mvc
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(
                new CookieAuthenticationOptions
                {
                    AuthenticationType = Cookie.ViagensOnlineCookieAuthentication.ToString(),
                    LoginPath = new PathString("/Login")
                }
            );
        }
    }
}

using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace MyAsset
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/")   //沒有權限時導到首頁
            });
        }
    }
}
using System.Configuration;
using Microsoft.Owin.Cors;
using Owin;

namespace AccidentalFish.ApiUnavailable
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            string message = ConfigurationManager.AppSettings["UnavailabilityMessage"];
            app.UseCors(CorsOptions.AllowAll);
            app.Run(ctx =>
            {
                ctx.Response.StatusCode = 503;
                return ctx.Response.WriteAsync(message);
            });
        }
    }
}
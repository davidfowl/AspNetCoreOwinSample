using Microsoft.Owin.Builder;
using Microsoft.Owin.BuilderProperties;
using Owin;

namespace Microsoft.AspNetCore.Builder
{
    public static class OwinExtensions
    {
        public static IApplicationBuilder UseOwinApp(
            this IApplicationBuilder app,
            Action<IAppBuilder> configuration)
        {
            // Only apply this middleware if there's no executable endpoint. 
            // This is what makes ASP.NET Core routing preferred over the OWIN pipeline.

            return app.MapWhen(c => c.GetEndpoint()?.RequestDelegate is null, sub => sub.UseOwin(setup => setup(next =>
            {
                var owinAppBuilder = new AppBuilder();

                var lifetime = app.ApplicationServices.GetRequiredService<IHostApplicationLifetime>();
                var env = app.ApplicationServices.GetRequiredService<IWebHostEnvironment>();
                var owinAppProperties = new AppProperties(owinAppBuilder.Properties);

                owinAppProperties.OnAppDisposing = lifetime.ApplicationStopping;

                owinAppProperties.DefaultApp = next;

                owinAppProperties.AppName = env.ApplicationName;

                configuration(owinAppBuilder);

                return owinAppBuilder.Build<Func<IDictionary<string, object>, Task>>();
            })));
        }
    }
}
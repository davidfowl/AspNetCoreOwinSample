using System.Web.Http;
using Owin;

var builder = WebApplication.CreateBuilder(args);
// Uncomment this to use HTTP.sys
// builder.WebHost.UseHttpSys();

builder.Services.AddControllers();

var app = builder.Build();

app.UseAspNetCoreMiddleware();

// Routing will win over the OWIN middleware
app.MapGet("/", () => "Hello World!");

// Wire up ASP.NET Core controllers
app.MapControllers();

// This will run the owin pipeline on top of ASP.NET Core
app.UseOwinApp(owinApp =>
{
    // Sample middleware
    owinApp.Use<SampleOwinMiddleware>();

    var config = new HttpConfiguration();
    config.Routes.MapHttpRoute(
        name: "DefaultApi",
        routeTemplate: "api/{controller}/{id}",
        defaults: new { id = RouteParameter.Optional }
    );
    owinApp.UseWebApi(config);
});

app.Run();

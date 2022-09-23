using Microsoft.Owin;

public class SampleOwinMiddleware : OwinMiddleware
{
    public SampleOwinMiddleware(OwinMiddleware next)
        : base(next)
    {
    }
    public async override Task Invoke(IOwinContext context)
    {
        context.Response.Headers.Append("Framework", "OWIN");

        await Next.Invoke(context);
    }
}
using Owin;

namespace HelloOwin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // example of a filter - writeline each request
            app.UseFilter(req => req.TraceOutput.WriteLine(
                "{0} {1}{2} {3}",
                req.Method,
                req.PathBase,
                req.Path,
                req.QueryString));

            // example of a handler - all paths reply Hello, Owin!
            app.UseHandler(async (req, res) =>
            {
                res.ContentType = "text/plain";
                await res.WriteAsync("Hello, OWIN!");
            });
        }
    }
}

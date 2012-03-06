using System.Collections.Generic;
using System.IO;
using Nancy;
using Nancy.Responses;
using Nancy.ViewEngines;

namespace LittleBlog.CustomViewEngine
{
    public class MyViewEngine : IViewEngine
    {
        public void Initialize(ViewEngineStartupContext viewEngineStartupContext)
        {
        }

        public Response RenderView(ViewLocationResult viewLocationResult, dynamic model, IRenderContext renderContext)
        {
            var values = (string[])model;
            var template = viewLocationResult.Contents.Invoke().ReadToEnd();
            var rendered = string.Format(template, values);

            return new HtmlResponse(contents: stream =>
            {
                var writer = new StreamWriter(stream);
                writer.Write(rendered);
                writer.Flush();
            });
        }

        public IEnumerable<string> Extensions
        {
            get { return new[] { "mine" }; }
        }
    }
}
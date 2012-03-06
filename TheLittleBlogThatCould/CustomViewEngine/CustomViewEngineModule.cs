using Nancy;

namespace LittleBlog.CustomViewEngine
{
    public class CustomViewEngineModule : NancyModule
    {
        public CustomViewEngineModule() : base("customviewengine")
        {
            Get["/"] = r => 
                View["MyCustomView", new [] { "Super", "Happy" }];
        }
    }
}
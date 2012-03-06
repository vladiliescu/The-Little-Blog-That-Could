using Nancy;
using Nancy.Conventions;

namespace LittleBlog
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureConventions(NancyConventions conventions)
        {
            base.ConfigureConventions(conventions);

            conventions.ViewLocationConventions.Add((viewName, model, viewLocationContext) =>
                string.Concat(viewLocationContext.ModuleName, "/Views/", viewName)
            );
        }
    }
}
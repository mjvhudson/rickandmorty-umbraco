using Umbraco.Cms.Web.Common.ApplicationBuilder;

namespace RickAndMortyProject.App_Code.UmbracoEndpointBuilders
{
    public static class UmbracoEndpointBuilder
    {
        public static IUmbracoEndpointBuilderContext UseCustomRouting(this IUmbracoEndpointBuilderContext context)
        {
            if (!context.RuntimeState.UmbracoCanBoot())
            {
                return context;
            }

            context.EndpointRouteBuilder.MapControllerRoute(
                "Admin",
                "umbraco/backoffice/RickAndMortyCharacters",
                new { Controller = "RickAndMorty", Action = "Index" });

            return context;
        }
    }
}

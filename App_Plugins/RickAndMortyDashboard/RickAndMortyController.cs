using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RickAndMortyProject.Models.RickAndMorty;
using Umbraco.Cms.Web.Common.Authorization;

namespace RickAndMortyProject.App_Plugins.RickAndMortyDashboard
{
    [Authorize(Policy = AuthorizationPolicies.BackOfficeAccess)]
    public class RickAndMortyController : Controller
    {
        public IActionResult Index()
        {
            CharactersModel model = new();

            return View(model);
        }
    }
}

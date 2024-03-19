using Umbraco.Cms.Web.BackOffice.Controllers;
using Umbraco.Cms.Core.Web.Mvc;
using Umbraco.Cms.Core.Services;
using RickAndMortyProject.App_Code.Helpers;
using Umbraco.Cms.Core.Models;
using RickAndMortyProject.App_Code.Entities;

namespace RickAndMortyProject.App_Code.RickAndMortyProject
{
    //[PluginControllerMetadata("")]
    public class GetCharactersApiController : UmbracoAuthorizedJsonController
    {
        private readonly IContentService _contentService;

        public GetCharactersApiController(IContentService contentService)
        {
            _contentService = contentService;
        }

        public int LoadCharacters()
        {
            List<Character> characters = APIHelper.GetCharacters();

            var parentID = Guid.Parse("630646f7-5ed8-474f-8580-6b7b7cf02671");

            // Get existing characters
            var children = _contentService.GetPagedChildren(1060, 0, 1000, out long count);
            List<string> existingCharacters = children.Select(c => c.Name).ToList();

            IContent? tempChild;
            string tempChildName;

            int charactersAdded = 0;

            foreach (var character in characters)
            {
                tempChildName = character.Id + "_" + character.Name;
                if (existingCharacters.Contains(tempChildName)) { continue; }

                tempChild = _contentService.Create(tempChildName, parentID, "character");

                tempChild.SetValue("fullName", character.Name);
                tempChild.SetValue("status", character.Status);
                tempChild.SetValue("species", character.Species);
                tempChild.SetValue("gender", character.Gender);

                _contentService.SaveAndPublish(tempChild);
                charactersAdded++;
            }

            return charactersAdded;
        }
    }
}

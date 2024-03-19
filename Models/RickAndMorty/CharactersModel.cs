using RickAndMortyProject.App_Code.Entities;
using RickAndMortyProject.App_Code.Helpers;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;

namespace RickAndMortyProject.Models.RickAndMorty
{
    public class CharactersModel
    {
        /// <summary>
        /// Load all characters from the Rick and Morty API into the content service.
        /// </summary>
        /// <param name="contentService">Umbraco Content Service</param>
        public void LoadCharacters(IContentService contentService)
        {
            List<Character> characters = APIHelper.GetCharacters();

            var parentID = Guid.Parse("630646f7-5ed8-474f-8580-6b7b7cf02671");

            // Get existing characters
            var children = contentService.GetPagedChildren(1060, 0, 1000, out long count);
            List<string> existingCharacters = children.Select(c => c.Name).ToList();
            IContent? existingChild;

            IContent? tempChild;
            string tempChildName;

            foreach (var character in characters)
            {
                // Generate character content node name
                tempChildName = character.Id + "_" + character.Name;
                
                if (existingCharacters.Contains(tempChildName))
                {
                    // Find existing content by its name and update its values
                    existingChild = children.Where(c => c.Name == tempChildName).First();

                    existingChild.SetValue("fullName", character.Name);
                    existingChild.SetValue("status", character.Status);
                    existingChild.SetValue("species", character.Species);
                    existingChild.SetValue("gender", character.Gender);
                    existingChild.SetValue("imageURL", character.Image);

                    contentService.SaveAndPublish(existingChild);
                }
                else
                {
                    // Create new content node
                    tempChild = contentService.Create(tempChildName, parentID, "character");

                    tempChild.SetValue("fullName", character.Name);
                    tempChild.SetValue("status", character.Status);
                    tempChild.SetValue("species", character.Species);
                    tempChild.SetValue("gender", character.Gender);
                    tempChild.SetValue("imageURL", character.Image);

                    contentService.SaveAndPublish(tempChild);
                }
            }
        }
    }
}

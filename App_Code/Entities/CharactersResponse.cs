namespace RickAndMortyProject.App_Code.Entities
{
    public class CharactersResponse
    {
        public required Info Info { get; set; }

        public Character[]? Results { get; set; }
    }
}

namespace MarvelCatalog_App.Models
{
    public interface ICharacterModel
    {
        int Id { get; set; }

        string Name { get; set; }

        string Thumbnail { get; set; }
    }
}
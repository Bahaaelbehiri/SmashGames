namespace SmashGames.Server.Models
{
    public class Studio
    {
        public int StudioID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}

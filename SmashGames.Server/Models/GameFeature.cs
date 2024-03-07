namespace SmashGames.Server.Models
{
    public class GameFeature
    {
        public int GameFeatureID { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}

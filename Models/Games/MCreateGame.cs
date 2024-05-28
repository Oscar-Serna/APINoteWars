namespace PruebaFetchAPI.Models
{
    public class MCreateGame
    {
        public string GameName { get; set; }
        public string Category { get; set; }
        public float MaxScore { get; set; }
        public int SubjectIdentificator { get; set; }
        public int GameIdentificator { get; set; }

    }
}

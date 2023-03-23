namespace ConnectToSQLdatabase
{
    internal class Game
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool multiplayer { get; set; }
        public string relseaseDate { get; set; }
        public string lastUpdatedDate { get; set; }
        public int rating { get; set; }
        public int avgPrice { get; set; }
        public int developer { get; set; }
        public int publisher { get; set; }

        public static List<Game> games = new List<Game>();

        public Game(int id, string name, bool multiplayer, string relseaseDate, string lastUpdatedDate, int rating, int avgPrice, int developer, int publisher)
        {
            this.id = id;
            this.name = name;
            this.multiplayer = multiplayer;
            this.relseaseDate = relseaseDate;
            this.lastUpdatedDate = lastUpdatedDate;
            this.rating = rating;
            this.avgPrice = avgPrice;
            this.developer = developer;
            this.publisher = publisher;

            games.Add(this);
        }
    }
}

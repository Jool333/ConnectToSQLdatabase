namespace ConnectToSQLdatabase
{
    internal class Publisher
    {
        public int id { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public int nbrOfGames { get; set; }
        public int address { get; set; }

        public static List<Publisher> publishers = new List<Publisher>();

        public Publisher(int id, string name, string country, int nbrOfGames = 0, int address = -1)
        {
            this.id = id;
            this.name = name;
            this.country = country;
            this.nbrOfGames = nbrOfGames;
            this.address = address;

            publishers.Add(this);
        }
    }
}

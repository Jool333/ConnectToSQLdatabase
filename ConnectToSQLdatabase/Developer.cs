namespace ConnectToSQLdatabase
{
    internal class Developer
    {
        public int id { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public int nbrOfGames { get; set; }
        public int address { get; set; }

        public static List<Developer> developers = new List<Developer>();

        public Developer(int id, string name, string country, int nbrOfGames = 0, int address = -1)
        {
            this.id = id;
            this.name = name;
            this.country = country;
            this.nbrOfGames = nbrOfGames;
            this.address = address;

            developers.Add(this);
        }
    }
}

namespace ConnectToSQLdatabase
{
    internal class Tag
    {
        public int id { get; set; }
        public string name { get; set; }
        public string gamelist { get; set; }
        public int nbrOfGames { get; set; }

        public static List<Tag> tags = new List<Tag>();
        public Tag(int id, string name, string gamelist = "", int nbrOfGames = 0)
        {
            this.id = id;
            this.name = name;
            this.gamelist = gamelist;
            this.nbrOfGames = nbrOfGames;

            tags.Add(this);
        }
    }
}

namespace ConnectToSQLdatabase
{
    internal class Store
    {
        public int id { get; set; }
        public string name { get; set; }
        public int nbrOfGames { get; set; }
        public int addresses { get; set; }

        public static List<Store> stores = new List<Store>();

        public Store(int id, string name, int nbrOfGames = 0, int addresses = -1)
        {
            this.id = id;
            this.name = name;
            this.addresses = addresses;
            this.nbrOfGames = nbrOfGames;

            stores.Add(this);
        }
    }
}

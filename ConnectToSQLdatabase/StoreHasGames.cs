namespace ConnectToSQLdatabase
{
    internal class StoreHasGames
    {
        public int storeid { get; set; }
        public int gamesid { get; set; }
        public int price { get; set; }

        public static List<StoreHasGames> storehasgames = new List<StoreHasGames>();

        public StoreHasGames(int storeid, int gamesid, int price)
        {
            this.storeid = storeid;
            this.gamesid = gamesid;
            this.price = price;

            storehasgames.Add(this);
        }
    }
}

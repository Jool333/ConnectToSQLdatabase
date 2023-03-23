namespace ConnectToSQLdatabase
{
    internal class GamesHasTags
    {
        public int gameid { get; set; }
        public int tagid { get; set; }

        public static List<GamesHasTags> gameshastags = new List<GamesHasTags>();

        public GamesHasTags(int gameid, int tagid)
        {
            this.gameid = gameid;
            this.tagid = tagid;

            gameshastags.Add(this);
        }
    }
}

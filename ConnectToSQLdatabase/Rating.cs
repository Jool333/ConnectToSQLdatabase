namespace ConnectToSQLdatabase
{
    internal class Rating
    {
        public int id { get; set; }
        public string review { get; set; }
        public int score { get; set; }
        public string ratedgame { get; set; }

        public static List<Rating> ratings = new List<Rating>();

        public Rating(int id, string review, int score, string ratedgame)
        {
            this.id = id;
            this.review = review;
            this.score = score;
            this.ratedgame = ratedgame;

            ratings.Add(this);
        }
    }
}

namespace ConnectToSQLdatabase
{
    internal class Address
    {
        public int id { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public string zip { get; set; }

        public static List<Address> addresses = new List<Address>();

        public Address(int id, string city, string street, string zip)
        {
            this.id = id;
            this.city = city;
            this.street = street;
            this.zip = zip;

            addresses.Add(this);
        }
    }
}

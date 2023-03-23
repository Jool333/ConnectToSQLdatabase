using MySql.Data.MySqlClient;

namespace ConnectToSQLdatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string server = "LOCALHOST";
            string database = "gamedb";
            string uid = "root";
            string pass = String.Empty;


            bool loginCheck = !string.IsNullOrEmpty(pass);
            MySqlConnection conn = null;
            int count = 0;
            if (loginCheck)
            {
                string connStr = $"SERVER = '{server}'; DATABASE = '{database}'; UID = '{uid}'; PASSWORD = '{pass}';";
                conn = new MySqlConnection(connStr);
            }
            while (loginCheck == false)
            {
                Console.WriteLine($"Enter the password for user: {uid} on database {database}, {3 - count} attempts remaining: ");
                pass = login();


                string connStr = $"SERVER = '{server}'; DATABASE = '{database}'; UID = '{uid}'; PASSWORD = '{pass}';";
                conn = new MySqlConnection(connStr);
                try
                {
                    conn.Open();
                    conn.Close();
                    loginCheck = true;
                    Console.WriteLine($"\nLogin Successful. Entering database: {database}");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
                catch (Exception e)
                {
                    loginCheck = false;
                    Console.WriteLine("\nIncorrect Password, try again");
                    count++;
                    Thread.Sleep(500);
                    Console.Clear();
                }
                if (count >= 3)
                {
                    Console.WriteLine("Three failed attempts, wait 30 seconds before trying again");
                    timer();
                    Console.Clear();
                    count = 0;
                }
            }


            int menuChoice = 0;
            string choice;
            bool validchoice = true;
            do
            {
                Console.WriteLine("Select what type of object you wish to interact with:" +
               "\n1.\tGame" +
               "\n2.\tDeveloper" +
               "\n3.\tPublishers" +
               "\n4.\tStores" +
               "\n5.\tTags" +
               "\n6.\tRating" +
               "\n7.\tAddress" +
               "\n0.\tExit the program");


                if (!int.TryParse(Console.ReadLine(), out menuChoice))
                {
                    Console.WriteLine("invalid number, press any key try again...");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                Console.Clear();

                int index;
                string keyword;
                double doubleChoice;
                switch (menuChoice)
                {
                    case 0:
                        System.Environment.Exit(0);
                        break;

                    case 1:
                        do
                        {
                            Console.WriteLine("Select an option:" +
                            "\n0.\tGo back to the previous menu" +
                            "\n1.\tAdd a game" +
                            "\n\t1,1\tAdd a game to a store" +
                            "\n2.\tShow all games" +
                            "\n3.\tSearch for a game" +
                            "\n\t3,1\tSearch what stores have a specific game" +
                            "\n\t3,2\tSearch which tags a specific game has" +
                            "\n4.\tUpdate a games info" +
                            "\n5.\tRemove a game" +
                            "\n6.\tRemove a game from a store");

                            if (!double.TryParse(Console.ReadLine(), out doubleChoice))
                            {
                                Console.WriteLine("invalid number, press any key try again...");
                                Console.ReadKey();
                                Console.Clear();
                                continue;
                            }
                            Console.Clear();

                            switch (doubleChoice)
                            {
                                case 0:
                                    validchoice = false;
                                    Console.Clear();
                                    break;

                                case 1:
                                    add(conn, Game.games);
                                    break;

                                case 1.1:
                                    add(conn, StoreHasGames.storehasgames);
                                    break;

                                case 2:
                                    selectAllAndPrintAllData(conn, Game.games);
                                    break;

                                case 3:
                                    searchAndPrintAllData(conn, Game.games);
                                    break;

                                case 3.1:
                                    searchAndPrintBasicData(conn, StoreHasGames.storehasgames);
                                    break;

                                case 3.2:
                                    searchAndPrintBasicData(conn, GamesHasTags.gameshastags);
                                    break;

                                case 4:
                                    update(conn, Game.games);
                                    break;

                                case 5:

                                    delete(conn, Game.games);
                                    break;

                                case 6:
                                    delete(conn, StoreHasGames.storehasgames);
                                    break;

                                default:
                                    Console.WriteLine("Please choose a valid option. Press any key to continue...");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                            }
                        } while (validchoice);
                        break;

                    case 2:
                        do
                        {
                            Console.WriteLine("Select an option:" +
                            "\n0.\tGo back to the previous menu" +
                            "\n1.\tAdd a developer" +
                            "\n2.\tShow all developers" +
                            "\n3.\tSearch for a developer" +
                            "\n4.\tUpdate a developers info" +
                            "\n5.\tRemove a developer");
                            if (!int.TryParse(Console.ReadLine(), out menuChoice))
                            {
                                Console.WriteLine("invalid number, press any key try again...");
                                Console.ReadKey();
                                Console.Clear();
                                continue;
                            }
                            Console.Clear();
                            switch (menuChoice)
                            {
                                case 0:
                                    validchoice = false;
                                    Console.Clear();
                                    break;

                                case 1:
                                    add(conn, Developer.developers);
                                    break;

                                case 2:
                                    selectAllAndPrintAllData(conn, Developer.developers);
                                    break;

                                case 3:
                                    searchAndPrintAllData(conn, Developer.developers);
                                    break;

                                case 4:
                                    update(conn, Developer.developers);
                                    break;

                                case 5:
                                    delete(conn, Developer.developers);
                                    break;

                                default:
                                    Console.WriteLine("Please choose a valid option. Press any key to continue...");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                            }
                        } while (validchoice);
                        break;

                    case 3:
                        do
                        {
                            Console.WriteLine("Select an option:" +
                            "\n0.\tGo back to the previous menu" +
                            "\n1.\tAdd a publisher" +
                            "\n2.\tShow all publishers" +
                            "\n3.\tSearch for a publisher" +
                            "\n4.\tUpdate a publishers info" +
                            "\n5.\tRemove a publisher");
                            if (!int.TryParse(Console.ReadLine(), out menuChoice))
                            {
                                Console.WriteLine("invalid number, press any key try again...");
                                Console.ReadKey();
                                Console.Clear();
                                continue;
                            }
                            Console.Clear();
                            switch (menuChoice)
                            {
                                case 0:
                                    validchoice = false;
                                    Console.Clear();
                                    break;

                                case 1:
                                    add(conn, Publisher.publishers);
                                    break;

                                case 2:
                                    selectAllAndPrintAllData(conn, Publisher.publishers);
                                    break;

                                case 3:
                                    searchAndPrintAllData(conn, Publisher.publishers);
                                    break;

                                case 4:
                                    update(conn, Publisher.publishers);
                                    break;

                                case 5:
                                    delete(conn, Publisher.publishers);
                                    break;

                                default:
                                    Console.WriteLine("Please choose a valid option. Press any key to continue...");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                            }
                        } while (validchoice);
                        break;

                    case 4:
                        do
                        {
                            Console.WriteLine("Select an option:" +
                            "\n0.\tGo back to the previous menu" +
                            "\n1.\tAdd a store" +
                            "\n2.\tShow all stores" +
                            "\n3.\tSearch for a store" +
                            "\n4.\tUpdate a stores info" +
                            "\n\t4,1\tUpdate a games price in a store" +
                            "\n5.\tRemove a store");
                            if (!double.TryParse(Console.ReadLine(), out doubleChoice))
                            {
                                Console.WriteLine("invalid number, press any key try again...");
                                Console.ReadKey();
                            }
                            Console.Clear();
                            switch (doubleChoice)
                            {
                                case 0:
                                    validchoice = false;
                                    Console.Clear();
                                    break;

                                case 1:
                                    add(conn, Store.stores);
                                    break;

                                case 2:
                                    selectAllAndPrintAllData(conn, Store.stores);
                                    break;

                                case 3:
                                    searchAndPrintAllData(conn, Store.stores);
                                    break;

                                case 4:
                                    update(conn, Store.stores);
                                    break;

                                case 4.1:
                                    update(conn, StoreHasGames.storehasgames);
                                    break;

                                case 5:
                                    delete(conn, Store.stores);
                                    break;

                                default:
                                    Console.WriteLine("Please choose a valid option. Press any key to continue...");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                            }
                        } while (validchoice);
                        break;

                    case 5:
                        do
                        {
                            Console.WriteLine("Select an option:" +
                        "\n0.\tGo back to the previous menu" +
                        "\n1.\tAdd a tag" +
                        "\n\t1,1\tAdd a tag to a game" +
                        "\n2.\tShow all tags" +
                        "\n3.\tSearch for games with a tag" +
                        "\n4.\tUpdate a tag" +
                        "\n5.\tRemove a tag from a game");
                            if (!double.TryParse(Console.ReadLine(), out doubleChoice))
                            {
                                Console.WriteLine("invalid number, press any key try again...");
                                Console.ReadKey();
                                Console.Clear();
                                continue;
                            }
                            Console.Clear();

                            switch (doubleChoice)
                            {
                                case 0:
                                    validchoice = false;
                                    Console.Clear();
                                    break;

                                case 1:
                                    add(conn, Tag.tags);
                                    break;

                                case 1.1:
                                    add(conn, GamesHasTags.gameshastags);
                                    break;

                                case 2:
                                    selectAllAndPrintAllData(conn, Tag.tags);
                                    break;

                                case 3:
                                    searchAndPrintAllData(conn, Tag.tags);
                                    break;

                                case 4:
                                    update(conn, Tag.tags);
                                    break;

                                case 5:
                                    delete(conn, GamesHasTags.gameshastags);
                                    break;

                                default:
                                    Console.WriteLine("Please choose a valid option. Press any key to continue...");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                            }
                        } while (validchoice);
                        break;

                    case 6:
                        do
                        {
                            Console.WriteLine("Select an option:" +
                            "\n0.\tGo back to the previous menu" +
                            "\n1.\tAdd a rating" +
                            "\n2.\tShow all ratings" +
                            "\n3.\tSearch for a rating on a game" +
                            "\n4.\tUpdate a ratings info" +
                            "\n5.\tRemove a rating from a game");
                            if (!int.TryParse(Console.ReadLine(), out menuChoice))
                            {
                                Console.WriteLine("invalid number, press any key try again...");
                                Console.ReadKey();
                                Console.Clear();
                                continue;
                            }
                            Console.Clear();
                            switch (menuChoice)
                            {
                                case 0:
                                    validchoice = false;
                                    Console.Clear();
                                    break;

                                case 1:
                                    add(conn, Rating.ratings);
                                    break;

                                case 2:
                                    selectAllAndPrintAllData(conn, Rating.ratings);
                                    break;

                                case 3:
                                    searchAndPrintAllData(conn, Rating.ratings);
                                    break;

                                case 4:
                                    update(conn, Rating.ratings);
                                    break;

                                case 5:
                                    delete(conn, Rating.ratings);
                                    break;

                                default:
                                    Console.WriteLine("Please choose a valid option. Press any key to continue...");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                            }
                        } while (validchoice);
                        break;

                    case 7:
                        do
                        {
                            Console.WriteLine("Select an option:" +
                            "\n0.\tGo back to the previous menu" +
                            "\n1.\tAdd an address and attach to a business" +
                            "\n2.\tShow all addresses" +
                            "\n3.\tSearch for a business using city" +
                            "\n4.\tUpdate a business address");

                            if (!int.TryParse(Console.ReadLine(), out menuChoice))
                            {
                                Console.WriteLine("invalid number, press any key try again...");
                                Console.ReadKey();
                                Console.Clear();
                                continue;
                            }
                            Console.Clear();

                            switch (menuChoice)
                            {
                                case 0:
                                    validchoice = false;
                                    Console.Clear();
                                    break;

                                case 1:
                                    add(conn, Address.addresses);
                                    break;

                                case 2:
                                    selectAllAndPrintAllData(conn, Address.addresses);
                                    break;

                                case 3:
                                    searchAndPrintAllData(conn, Address.addresses);
                                    break;

                                case 4:
                                    update(conn, Address.addresses);
                                    break;

                                default:
                                    Console.WriteLine("Please choose a valid option. Press any key to continue...");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                            }
                        } while (validchoice);
                        break;

                    default:
                        Console.WriteLine("Error: did not pick a menu choice");
                        break;
                }
                validchoice = true;
            } while (validchoice);




        }
        public static void add<T>(MySqlConnection conn, List<T> list)
        {
            string query = "";
            MySqlCommand cmd;
            MySqlDataReader reader;
            switch (typeof(T).ToString())
            {
                case "ConnectToSQLdatabase.Game":

                    Console.Clear();
                    Console.Write("Enter the name of the game you wish to add: ");
                    string gamename = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Enter 1 if the games has multiplayer otherwise enter 0: ");
                    int mp = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine("Enter the date the game was released in YYYY-MM-DD format:  ");
                    string release = Console.ReadLine();

                    Console.Clear();
                    //display devchoice list
                    selectAllAndPrintBasicData(conn, Developer.developers);

                    Console.WriteLine("If the name appears on the list enter the number corresponding with the name, write -1 if unknown " +
                        "\nIf the name has not appeared type in the name instead, if you know the country of origin seprarate with a comma " +
                        "otherwise leave blank Ex: -1 | 1 | GameDev , Sweden | GameDev: ");
                    var dev = Console.ReadLine();
                    int devAdd;
                    string[] devC = null;
                    if (int.TryParse(dev, out devAdd))
                    {
                        devAdd = getRealID(Developer.developers, devAdd);
                    }
                    else
                    {
                        dev.Trim();
                        if (dev.Contains(","))
                        {
                            devC = dev.Split(',');
                            dev = devC[0] + "'" + "," + "'" + devC[1];
                        }

                        string addDev = $"CALL addDev('{dev}');" +
                            $"call searchDev(last_insert_id());";
                        cmd = new MySqlCommand(addDev, conn);
                        conn.Open();
                        reader = cmd.ExecuteReader();
                        reader.Read();
                        devAdd = Convert.ToInt32(reader["developers_id"]);
                        new Developer(Convert.ToInt32(reader["developers_id"]), reader["developers_name"].ToString(),
                            reader["developers_country"].ToString(), 0, -1);
                        conn.Close();
                    }

                    //display pubchoice list
                    Console.Clear();
                    selectAllAndPrintBasicData(conn, Publisher.publishers);
                    Console.WriteLine("If the name appears on the list enter the number corresponding with the name, write -1 if unknown " +
                       "\nIf the name has not appeared type in the name instead, if you know the country of origin seprarate with a comma " +
                       "otherwise leave blank Ex: 1 | GamePub, Swedem| GamePub:");
                    var pub = Console.ReadLine();
                    int pubAdd;
                    string[] pubC = null;
                    if (int.TryParse(pub, out pubAdd))
                    {
                        pubAdd = getRealID(Publisher.publishers, pubAdd);
                    }
                    else
                    {
                        pub.Trim();
                        if (pub.Contains(","))
                        {
                            pubC = pub.Split(',');
                            pub = pubC[0] + "'" + "," + "'" + pubC[1];
                        }

                        string addPub = $"CALL addPub('{pub}');" +
                            $"call searchPub(last_insert_id());";
                        cmd = new MySqlCommand(addPub, conn);
                        conn.Open();
                        reader = cmd.ExecuteReader();
                        reader.Read();
                        pubAdd = Convert.ToInt32(reader["publishers_id"]);
                        new Publisher(Convert.ToInt32(reader["publishers_id"]), reader["publishers_name"].ToString(),
                            reader["publishers_country"].ToString(), 0, -1);
                        conn.Close();
                    }
                    query = $"CALL addGame('{gamename}',{mp},'{release}',{devAdd},{pubAdd}); call searchOnlyGame(last_insert_id());";
                    cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    int gameid = Convert.ToInt32(reader["games_id"]);
                    new Game(Convert.ToInt32(reader["games_id"]), reader["games_name"].ToString(), Boolean.Parse(reader["games_multiplayer"].ToString()), reader["games_release"].ToString(),
                        null, 0, 0, Convert.ToInt32(reader["developers_developers_id"]), Convert.ToInt32(reader["publishers_publishers_id"]));
                    conn.Close();
                    Console.WriteLine($"The game:\t{gamename} was succesfully added");
                    break;

                case "ConnectToSQLdatabase.Developer":
                    Console.Clear();
                    Console.Write("Enter the name of the developer you wish to add: ");
                    string devname = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("if you know the country of origin enter it, otherwise leave blank: ");
                    string countryDev = Console.ReadLine();
                    if (string.IsNullOrEmpty(countryDev))
                        countryDev = "''";

                    Console.Clear();
                    Console.WriteLine("Do you want to add an address? type 1, otherwise leave blank and press enter");
                    string adDevAdd = Console.ReadLine();
                    if (adDevAdd.Equals("1"))
                    {
                        Console.Clear();
                        Console.WriteLine("Enter the city, street-address and zip-code, separate with comma: ");
                        string add = Console.ReadLine();
                        add.Trim();
                        string[] addressParts = adDevAdd.Split(',');
                        query = $"CALL addDev('{devname}','{countryDev}');" +
                            $"CALL addAddressToDev(last_insert_id(),'{addressParts[0]}','{addressParts[1]}','{addressParts[2]}');" +
                            $"call searchDevFromAdd(LAST_INSERT_ID());";
                    }
                    else query = $"CALL addDev('{devname}','{countryDev}');call searchDev(LAST_INSERT_ID());";
                    cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    new Developer(Convert.ToInt32(reader["developers_id"]), reader["developers_name"].ToString(),
                            reader["developers_country"].ToString(), default, Convert.ToInt32(reader["addresses_id"]));
                    if (Convert.ToInt32(reader["addresses_id"]) != -1)
                        new Address(Convert.ToInt32(reader["addresses_id"]), reader["addresses_city"].ToString(), reader["addresses_street"].ToString(), reader["addresses_zip"].ToString());
                    conn.Close();
                    Console.WriteLine($"The developers:\t{devname} was successfully added");
                    break;

                case "ConnectToSQLdatabase.Publisher":
                    Console.Clear();
                    Console.Write("Enter the name of the publisher you wish to add: ");
                    string pubname = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("if you know the country of origin enter it, otherwise leave blank: ");
                    string countryPub = Console.ReadLine();
                    if (string.IsNullOrEmpty(countryPub))
                        countryPub = "''";

                    Console.Clear();
                    Console.WriteLine("Do you want to add an address? type 1, otherwise leave blank and press enter");
                    string adPubAdd = Console.ReadLine();
                    if (adPubAdd.Equals("1"))
                    {
                        Console.Clear();
                        Console.WriteLine("Enter the city, street-address and zip-code, separate with comma: ");
                        string add = Console.ReadLine();
                        add.Trim();
                        string[] addressParts = adPubAdd.Split(',');
                        query = $"CALL addPub('{pubname}','{countryPub}');" +
                            $"CALL addAddressToPub(LAST_INSERT_ID(),'{addressParts[0]}','{addressParts[1]}','{addressParts[2]}');" +
                            $"CALL searchPubFromAdd(LAST_INSERT_ID());";
                    }
                    else query = $"CALL addPub('{pubname}','{countryPub}');CALL searchPub(LAST_INSERT_ID());";
                    cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    new Publisher(Convert.ToInt32(reader["publishers_id"]), reader["publishers_name"].ToString(),
                            reader["publishers_country"].ToString(), default, Convert.ToInt32(reader["addresses_id"]));
                    if (Convert.ToInt32(reader["addresses_id"]) != -1)
                        new Address(Convert.ToInt32(reader["addresses_id"]), reader["addresses_city"].ToString(), reader["addresses_street"].ToString(), reader["addresses_zip"].ToString());
                    conn.Close();
                    Console.WriteLine($"The publisher:\t{pubname} was successfully added");
                    break;

                case "ConnectToSQLdatabase.Store":
                    Console.Clear();
                    Console.Write("Enter the name of the store you wish to add: ");
                    string storename = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Do you want to add an address? type 1, otherwise leave blank and press enter");
                    string adstoreAdd = Console.ReadLine();
                    if (adstoreAdd.Equals("1"))
                    {
                        Console.Clear();
                        Console.WriteLine("Enter the city, street-address and zip-code, separate with comma: ");
                        string add = Console.ReadLine();
                        add.Trim();
                        string[] addressParts = adstoreAdd.Split(',');
                        query = $"CALL addStore('{storename}');" +
                            $"CALL addAddressToPub(LAST_INSERT_ID(),'{addressParts[0]}','{addressParts[1]}','{addressParts[2]}');" +
                            $"CALL searchStoreFromAdd(LAST_INSERT_ID());";
                    }
                    else query = $"CALL addStore('{storename}');CALL searchStore(LAST_INSERT_ID());";
                    cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    new Store(Convert.ToInt32(reader["stores_id"]), reader["stores_name"].ToString(), 0, Convert.ToInt32(reader["addresses_id"]));
                    if (Convert.ToInt32(reader["addresses_id"]) != -1)
                        new Address(Convert.ToInt32(reader["addresses_id"]), reader["addresses_city"].ToString(),
                            reader["addresses_street"].ToString(), reader["addresses_zip"].ToString());
                    conn.Close();
                    Console.WriteLine($"The store:\t{storename} was successfully added");
                    break;

                case "ConnectToSQLdatabase.Tag":
                    Console.Clear();
                    Console.Write("Enter the name of the tag you wish to add: ");
                    string tagname = Console.ReadLine();
                    query = $"CALL addTags('{tagname}');CALL searchTag(LAST_INSERT_ID());";
                    cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    new Tag(Convert.ToInt32(reader["tags_id"]), reader["tags_name"].ToString());
                    conn.Close();
                    Console.WriteLine($"The tag:\t{tagname} was successfully added");
                    break;

                case "ConnectToSQLdatabase.Rating":
                    string game;
                    int revgameid;

                    do
                    {
                        Console.Clear();
                        selectAllAndPrintBasicData(conn, Game.games);
                        Console.WriteLine("Type the number corresponding to the game you wish to add a rating to: ");
                        game = Console.ReadLine();

                        if (int.TryParse(game, out revgameid))
                        {
                            revgameid = getRealID(Game.games, revgameid);
                        }
                        else
                        {
                            Console.WriteLine("invalid number, press any key to try again");
                            Console.ReadKey();
                        }
                    } while (!int.TryParse(game, out revgameid));
                    Console.Clear();
                    int maxlength = 300;
                    string review = "";
                    ConsoleKey key = ConsoleKey.Spacebar;
                    do
                    {
                        Console.Write($"Write your review of the game maximum 300 charachters. {maxlength - review.Length} remaining\n{review}");
                        var keyInfo = Console.ReadKey(intercept: true);
                        key = keyInfo.Key;
                        if (key == ConsoleKey.Backspace && review.Length > 0)
                        {
                            Console.Write("\b \b");
                            review = review[0..^1];
                        }
                        else
                        {
                            review += keyInfo.KeyChar;
                        }
                        Console.Clear();
                    } while (review.Length <= 300 && key != ConsoleKey.Enter);

                    Console.WriteLine("What would you rate the game from 1 to 100, 100 being the best:");
                    int score = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    query = $"CALL addRating('{review}',{score},{revgameid});CALL searchRating(LAST_INSERT_ID());";
                    cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    new Rating(Convert.ToInt32(reader["rating_id"]), reader["rating_review"].ToString(),
                        Convert.ToInt32(reader["rating_score"]), reader["games_name"].ToString());
                    conn.Close();
                    Console.WriteLine($"The rating was successfully added to {Game.games[Convert.ToInt32(game) - 1].name}");
                    break;

                case "ConnectToSQLdatabase.StoreHasGames":
                    Console.Clear();
                    //List names of gamesid
                    selectAllAndPrintBasicData(conn, Game.games);
                    Console.Write("Enter the number of the game you wish to add: ");
                    gameid = Convert.ToInt32(Console.ReadLine());
                    int gameindex = getRealID(Game.games, gameid);
                    Console.Clear();
                    //List names of stores
                    selectAllAndPrintBasicData(conn, Store.stores);
                    Console.WriteLine("Enter the number of the store you wish to add the game to: ");
                    int storeid = Convert.ToInt32(Console.ReadLine());
                    int storeindex = getRealID(Store.stores, storeid);
                    Console.Clear();
                    Console.WriteLine("Enter the price of the game:  ");
                    int price = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();

                    query = $"CALL addGameToStore({storeindex},{gameindex},{price});";
                    cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    new StoreHasGames(storeindex, gameindex, price);
                    Console.WriteLine($"The game: {Game.games[gameid - 1].name} was successfully added to {Store.stores[storeid - 1].name}");
                    break;

                case "ConnectToSQLdatabase.GamesHasTags":
                    Console.Clear();
                    //List names of gamesid
                    Console.Write("Enter the number of the game you wish to add: ");
                    gameid = Convert.ToInt32(Console.ReadLine());
                    gameindex = getRealID(Game.games, gameid);
                    Console.Clear();
                    //List names of stores
                    Console.WriteLine("Enter the number of the tag you wish to add to the game: ");
                    int tagid = Convert.ToInt32(Console.ReadLine());
                    int tagindex = getRealID(Tag.tags, tagid);
                    Console.Clear();

                    query = $"CALL addTagToGame({gameindex},{tagindex});";
                    cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    new GamesHasTags(gameid, tagid);
                    Console.WriteLine($"The tag: {Tag.tags[tagid - 1].name} was successfully added to {Game.games[gameid - 1].name}");
                    break;

                case "ConnectToSQLdatabase.Address":
                    Console.Clear();
                    int index = 0;
                    Console.Clear();

                    Console.WriteLine("Enter the city you wish to add: ");
                    string city = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Enter the street address you wish to add: ");
                    string street = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Enter the zipcode you wish to add: ");
                    string zip = Console.ReadLine();
                    Console.Clear();

                    bool validchoice = true;
                    do
                    {
                        Console.WriteLine("Do you wish to add an address to a store (1), a developer (2) or a publisher (3)");
                        int addressChoice = Convert.ToInt32(Console.ReadLine());
                        switch (addressChoice)
                        {
                            case 1:
                                selectAllAndPrintBasicData(conn, Store.stores);
                                Console.WriteLine("Enter the number corresponding with the store you wish to add the address to: ");
                                index = Convert.ToInt32(Console.ReadLine());
                                index = getRealID(Store.stores, index);
                                query = $"CALL addAddressToStore({index},'{city}','{street}','{zip}'); CALL searchStore({index});";
                                Console.Clear();
                                validchoice = false;
                                break;

                            case 2:
                                selectAllAndPrintBasicData(conn, Developer.developers);
                                Console.WriteLine("Enter the number corresponding with the developer you wish to add the address to: ");
                                index = Convert.ToInt32(Console.ReadLine());
                                index = getRealID(Developer.developers, index);
                                query = $"CALL addAddressToDev({index},'{city}','{street}','{zip}'); CALL searchDev({index});";
                                Console.Clear();
                                break;

                            case 3:
                                selectAllAndPrintBasicData(conn, Publisher.publishers);
                                Console.WriteLine("Enter the number corresponding with the publisher you wish to add the address to: ");
                                index = Convert.ToInt32(Console.ReadLine());
                                index = getRealID(Publisher.publishers, index);
                                query = $"CALL addAddressToPub({index},'{city}','{street}','{zip}'); CALL searchPub({index});";
                                Console.Clear();

                                break;

                            default:
                                Console.WriteLine("invalid choice, try again, press any key to try again...");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                        }
                    } while (validchoice);

                    cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    int addIndex = Convert.ToInt32(reader["addresses_id"]);
                    conn.Close();

                    new Address(addIndex, city, street, zip);
                    Console.WriteLine("successfully added the address to the business");
                    break;

                default:
                    Console.WriteLine("invalid datatype");
                    break;
            }

        }

        public static void selectAllData<T>(MySqlConnection conn, List<T> list)
        {
            string query;
            MySqlCommand cmd;
            MySqlDataReader reader;
            switch (typeof(T).ToString())
            {
                case "ConnectToSQLdatabase.Game":
                    query = $"CALL selectAllGames()";
                    cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    reader = cmd.ExecuteReader();

                    Game.games.Clear();

                    while (reader.Read())
                    {
                        int avgRating = reader["average_game_rating"] == DBNull.Value ? 0 : Convert.ToInt32(reader["average_game_rating"]);
                        int avgPrice = reader["average_game_price"] == DBNull.Value ? 0 : Convert.ToInt32(reader["average_game_price"]);
                        string gameLastUpdate = reader["games_lastUpdate"] == DBNull.Value ? null : reader["games_lastUpdate"].ToString();
                        new Game(Convert.ToInt32(reader["games_id"]), reader["games_name"].ToString(),
                            Convert.ToBoolean(reader["games_multiplayer"].ToString()), reader["games_release"].ToString(),
                            gameLastUpdate, avgRating, avgPrice,
                            Convert.ToInt32(reader["developers_developers_id"]), Convert.ToInt32(reader["publishers_publishers_id"]));
                    }
                    conn.Close();
                    break;

                case "ConnectToSQLdatabase.Developer":
                    query = $"CALL selectAllDev()";
                    cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    reader = cmd.ExecuteReader();

                    Developer.developers.Clear();

                    while (reader.Read())
                    {
                        new Developer(Convert.ToInt32(reader["developers_id"]), reader["developers_name"].ToString(), reader["developers_country"].ToString(),
                            Convert.ToInt32(reader["Number_of_Games"]), Convert.ToInt32(reader["addresses_id"]));
                    }
                    conn.Close();
                    break;

                case "ConnectToSQLdatabase.Publisher":
                    query = $"CALL selectAllPub()";
                    cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    reader = cmd.ExecuteReader();

                    Publisher.publishers.Clear();

                    while (reader.Read())
                    {
                        new Publisher(Convert.ToInt32(reader["publishers_id"]), reader["publishers_name"].ToString(), reader["publishers_country"].ToString(),
                            Convert.ToInt32(reader["Number_of_Games"]), Convert.ToInt32(reader["addresses_id"]));
                    }
                    conn.Close();
                    break;

                case "ConnectToSQLdatabase.Store":
                    query = $"CALL selectAllStores()";
                    cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    reader = cmd.ExecuteReader();

                    Store.stores.Clear();

                    while (reader.Read())
                    {
                        new Store(Convert.ToInt32(reader["stores_id"]), reader["stores_name"].ToString(),
                            Convert.ToInt32(reader["Number_of_games"]), Convert.ToInt32(reader["addresses_id"]));
                    }
                    conn.Close();
                    break;

                case "ConnectToSQLdatabase.Tag":
                    query = $"CALL selectAllGamesWithTags()";
                    cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    reader = cmd.ExecuteReader();

                    Tag.tags.Clear();

                    while (reader.Read())
                    {
                        new Tag(Convert.ToInt32(reader["tags_id"]), reader["tags_name"].ToString(), reader["all_games"].ToString(), Convert.ToInt32(reader["number_of_games"]));
                    }
                    conn.Close();
                    break;

                case "ConnectToSQLdatabase.Rating":
                    query = $"CALL selectAllRatings()";
                    cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    reader = cmd.ExecuteReader();

                    Rating.ratings.Clear();

                    while (reader.Read())
                    {
                        new Rating(Convert.ToInt32(reader["rating_id"]), reader["rating_review"].ToString(),
                            Convert.ToInt32(reader["rating_score"]), reader["games_name"].ToString());
                    }
                    conn.Close();
                    break;

                case "ConnectToSQLdatabase.StoreHasGames":
                    query = $"CALL selectAllGames()";
                    cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    reader = cmd.ExecuteReader();

                    Game.games.Clear();

                    while (reader.Read())
                    {
                        int avgRating = reader["average_game_rating"] == DBNull.Value ? 0 : Convert.ToInt32(reader["average_game_rating"]);
                        int avgPrice = reader["average_game_price"] == DBNull.Value ? 0 : Convert.ToInt32(reader["average_game_price"]);
                        string gameLastUpdate = reader["games_lastUpdate"] == DBNull.Value ? null : reader["games_lastUpdate"].ToString();
                        new Game(Convert.ToInt32(reader["games_id"]), reader["games_name"].ToString(),
                            Convert.ToBoolean(reader["games_multiplayer"].ToString()), reader["games_release"].ToString(),
                            gameLastUpdate, avgRating, avgPrice,
                            Convert.ToInt32(reader["developers_developers_id"]), Convert.ToInt32(reader["publishers_publishers_id"]));
                    }
                    conn.Close();
                    break;

                case "ConnectToSQLdatabase.GamesHasTags":
                    query = $"CALL selectAllDev()";
                    cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    reader = cmd.ExecuteReader();

                    Developer.developers.Clear();

                    while (reader.Read())
                    {
                        new Developer(Convert.ToInt32(reader["developers_id"]), reader["developers_name"].ToString(), reader["developers_country"].ToString(),
                            Convert.ToInt32(reader["Number_of_Games"]), Convert.ToInt32(reader["addresses_id"]));
                    }
                    conn.Close();
                    break;

                case "ConnectToSQLdatabase.Address":
                    query = $"selectAllAddresses()";
                    cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    reader = cmd.ExecuteReader();

                    Address.addresses.Clear();
                    while (reader.Read())
                    {
                        new Address(Convert.ToInt32(reader["addresses_id"]), reader["addresses_city"].ToString(),
                            reader["addresses_street"].ToString(), reader["addresses_zip"].ToString());
                    }
                    conn.Close();
                    break;

                default:
                    Console.WriteLine("invalid datatype");
                    break;
            }
        }

        public static void selectAllAndPrintAllData<T>(MySqlConnection conn, List<T> list)
        {
            switch (typeof(T).ToString())
            {
                case "ConnectToSQLdatabase.Game":
                    selectAllData(conn, list);
                    printAllData(list);
                    break;

                case "ConnectToSQLdatabase.Developer":
                    selectAllData(conn, list);
                    printAllData(list);
                    break;

                case "ConnectToSQLdatabase.Publisher":
                    selectAllData(conn, list);
                    printAllData(list);
                    break;

                case "ConnectToSQLdatabase.Store":
                    selectAllData(conn, list);
                    printAllData(list);
                    break;

                case "ConnectToSQLdatabase.Tag":
                    selectAllData(conn, list);
                    printAllData(list);
                    break;

                case "ConnectToSQLdatabase.Rating":
                    selectAllData(conn, list);
                    printAllData(list);
                    break;

                case "ConnectToSQLdatabase.StoreHasGames":
                    selectAllData(conn, list);
                    printAllData(list);
                    break;

                case "ConnectToSQLdatabase.GamesHasTags":
                    selectAllData(conn, list);
                    printAllData(list);
                    break;

                case "ConnectToSQLdatabase.Address":
                    selectAllData(conn, list);
                    printAllData(list);
                    break;

                default:
                    Console.WriteLine("invalid datatype");
                    break;
            }
        }
        public static void selectAllAndPrintBasicData<T>(MySqlConnection conn, List<T> list)
        {
            switch (typeof(T).ToString())
            {
                case "ConnectToSQLdatabase.Game":
                    selectAllData(conn, list);
                    printBasicData(list);
                    break;

                case "ConnectToSQLdatabase.Developer":
                    selectAllData(conn, list);
                    printBasicData(list);
                    break;

                case "ConnectToSQLdatabase.Publisher":
                    selectAllData(conn, list);
                    printBasicData(list);
                    break;

                case "ConnectToSQLdatabase.Store":
                    selectAllData(conn, list);
                    printBasicData(list);
                    break;

                case "ConnectToSQLdatabase.Tag":
                    selectAllData(conn, list);
                    printBasicData(list);
                    break;

                case "ConnectToSQLdatabase.Rating":
                    selectAllData(conn, list);
                    printBasicData(list);
                    break;

                case "ConnectToSQLdatabase.StoreHasGames":
                    selectAllData(conn, list);
                    printBasicData(list);
                    break;

                case "ConnectToSQLdatabase.GamesHasTags":
                    selectAllData(conn, list);
                    printBasicData(list);
                    break;

                case "ConnectToSQLdatabase.Address":
                    selectAllData(conn, list);
                    printBasicData(list);
                    break;

                default:
                    Console.WriteLine("invalid datatype");
                    break;
            }

        }

        public static void searchAllData<T>(MySqlConnection conn, List<T> list)
        {
            string query;
            int index;
            string keyword;
            MySqlCommand cmd;
            MySqlDataReader reader;
            switch (typeof(T).ToString())
            {
                case "ConnectToSQLdatabase.Game":
                    Console.WriteLine("Write a keyword to search for in the games title: ");
                    keyword = Console.ReadLine();
                    query = $"CALL searchGameTitle('{keyword}')";
                    cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    reader = cmd.ExecuteReader();

                    Game.games.Clear();

                    while (reader.Read())
                    {
                        int avgRating = reader["average_game_rating"] == DBNull.Value ? 0 : Convert.ToInt32(reader["average_game_rating"]);
                        int avgPrice = reader["average_game_price"] == DBNull.Value ? 0 : Convert.ToInt32(reader["average_game_price"]);
                        string gameLastUpdate = reader["games_lastUpdate"] == DBNull.Value ? null : reader["games_lastUpdate"].ToString();
                        new Game(Convert.ToInt32(reader["games_id"]), reader["games_name"].ToString(),
                            Convert.ToBoolean(reader["games_multiplayer"].ToString()), reader["games_release"].ToString(),
                            gameLastUpdate, avgRating, avgPrice,
                            Convert.ToInt32(reader["developers_developers_id"]), Convert.ToInt32(reader["publishers_publishers_id"]));
                    }
                    conn.Close();
                    break;

                case "ConnectToSQLdatabase.Developer":
                    Console.WriteLine("Write a keyword to search for in the developers name: ");
                    keyword = Console.ReadLine();
                    query = $"CALL searchDevTitle('{keyword}')";
                    cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    reader = cmd.ExecuteReader();

                    Developer.developers.Clear();

                    while (reader.Read())
                    {
                        new Developer(Convert.ToInt32(reader["developers_id"]), reader["developers_name"].ToString(), reader["developers_country"].ToString(),
                            Convert.ToInt32(reader["Number_of_Games"]), Convert.ToInt32(reader["addresses_id"]));
                    }
                    conn.Close();
                    break;

                case "ConnectToSQLdatabase.Publisher":
                    Console.WriteLine("Write a keyword to search for in the publishers name: ");
                    keyword = Console.ReadLine();
                    query = $"CALL searchPubTitle('{keyword}')";
                    cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    reader = cmd.ExecuteReader();

                    Publisher.publishers.Clear();

                    while (reader.Read())
                    {
                        new Publisher(Convert.ToInt32(reader["publishers_id"]), reader["publishers_name"].ToString(), reader["publishers_country"].ToString(),
                            Convert.ToInt32(reader["Number_of_Games"]), Convert.ToInt32(reader["addresses_id"]));
                    }
                    conn.Close();
                    break;

                case "ConnectToSQLdatabase.Store":
                    Console.WriteLine("Write a keyword to search for in the stores name: ");
                    keyword = Console.ReadLine();
                    query = $"CALL searchStoreTitle('{keyword}')";
                    cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    reader = cmd.ExecuteReader();

                    Store.stores.Clear();

                    while (reader.Read())
                    {
                        new Store(Convert.ToInt32(reader["stores_id"]), reader["stores_name"].ToString(),
                            Convert.ToInt32(reader["Number_of_games"]), Convert.ToInt32(reader["addresses_id"]));
                    }
                    conn.Close();
                    break;

                case "ConnectToSQLdatabase.Tag":
                    //present list of tags
                    selectAllAndPrintBasicData(conn, Tag.tags);
                    Console.WriteLine("Type the number corresponding to the tag you wish to search for games with: ");
                    keyword = Console.ReadLine();
                    index = Convert.ToInt32(keyword);
                    index = getRealID(Tag.tags, index);
                    query = $"CALL searchGameWithTag({index})";
                    cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    reader = cmd.ExecuteReader();

                    Tag.tags.Clear();

                    while (reader.Read())
                    {
                        new Tag(Convert.ToInt32(reader["tags_id"]), reader["tags_name"].ToString(),
                            reader["all_games"].ToString(), Convert.ToInt32(reader["number_of_games"]));
                    }
                    conn.Close();
                    break;

                case "ConnectToSQLdatabase.Rating":
                    //present list of gamesid
                    selectAllAndPrintBasicData(conn, Game.games);
                    Console.WriteLine("Type the number corresponding to the game you wish to search for ratings with: ");
                    keyword = Console.ReadLine();
                    index = Convert.ToInt32(keyword);
                    index = getRealID(Game.games, index);
                    query = $"CALL searchRatingPerGame({index})";
                    cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    reader = cmd.ExecuteReader();

                    Rating.ratings.Clear();

                    while (reader.Read())
                    {
                        new Rating(Convert.ToInt32(reader["rating_id"]), reader["rating_review"].ToString(),
                            Convert.ToInt32(reader["rating_score"]), reader["games_name"].ToString());
                    }
                    conn.Close();
                    break;

                case "ConnectToSQLdatabase.StoreHasGames":
                    //print list of gamesid
                    selectAllAndPrintBasicData(conn, Game.games);
                    //have user select number
                    Console.WriteLine("Type the number of the game you wish to see what stores its in");
                    keyword = Console.ReadLine();
                    index = Convert.ToInt32(keyword);
                    index = getRealID(Game.games, index);
                    query = $"CALL searchStoresAllGames({index})";
                    cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    reader = cmd.ExecuteReader();

                    StoreHasGames.storehasgames.Clear();
                    while (reader.Read())
                    {
                        new StoreHasGames(Convert.ToInt32(reader["stores_stores_id"]), Convert.ToInt32(reader["games_games_id"]), Convert.ToInt32(reader["stores_has_games_price"]));
                    }
                    conn.Close();
                    break;

                case "ConnectToSQLdatabase.GamesHasTags":
                    //print list of gamesid
                    selectAllAndPrintBasicData(conn, Game.games);
                    //have user select number
                    Console.WriteLine("Type the number of the game you to see what tags it has");
                    keyword = Console.ReadLine();
                    index = Convert.ToInt32(keyword);
                    index = getRealID(Tag.tags, index);
                    query = $"CALL searchTagsAllGames({index})";
                    cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    reader = cmd.ExecuteReader();

                    StoreHasGames.storehasgames.Clear();
                    while (reader.Read())
                    {
                        new GamesHasTags(Convert.ToInt32(reader["games_games_id"]), Convert.ToInt32(reader["tags_tags_id"]));
                    }
                    conn.Close();
                    break;

                case "ConnectToSQLdatabase.Address":
                    Console.Clear();
                    string city;
                    bool validchoice = true;
                    int addressChoice;
                    query = null;
                    do
                    {
                        Console.WriteLine("Do you wish to search for a store (1), a developer (2) or a publisher (3)");
                        addressChoice = Convert.ToInt32(Console.ReadLine());
                        switch (addressChoice)
                        {
                            case 1:
                                Console.WriteLine("Enter the city you wish to search with to find a store : ");
                                city = Console.ReadLine();
                                query = $"CALL searchStoreByCity('{city}')";
                                Console.Clear();
                                break;

                            case 2:
                                Console.WriteLine("Enter the city you wish to search with to find a developer : ");
                                city = Console.ReadLine();
                                query = $"CALL searchDevByCity('{city}')";
                                Console.Clear();
                                break;

                            case 3:
                                Console.WriteLine("Enter the city you wish to search with to find a developer : ");
                                city = Console.ReadLine();
                                query = $"CALL searchPubByCity('{city}')";
                                break;

                            default:
                                Console.WriteLine("invalid choice, try again, press any key to try again...");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                        }
                    } while (validchoice);
                    Console.Clear();
                    cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    switch (addressChoice)
                    {
                        case 1:
                            Store.stores.Clear();
                            while (reader.Read())
                            {
                                new Store(Convert.ToInt32(reader["stores_id"]), reader["stores_name"].ToString(),
                                    0, Convert.ToInt32(reader["addresses_id"]));
                            }
                            conn.Close();
                            break;

                        case 2:
                            Developer.developers.Clear();
                            while (reader.Read())
                            {
                                new Developer(Convert.ToInt32(reader["developers_id"]), reader["developers_name"].ToString(), reader["developers_country"].ToString(),
                                    0, Convert.ToInt32(reader["addresses_id"]));
                            }
                            conn.Close();
                            break;

                        case 3:
                            Publisher.publishers.Clear();
                            while (reader.Read())
                            {
                                new Publisher(Convert.ToInt32(reader["publishers_id"]), reader["publishers_name"].ToString(), reader["publishers_country"].ToString(),
                                    0, Convert.ToInt32(reader["publishers_id"]));
                            }
                            conn.Close();
                            break;

                        default:
                            Console.WriteLine("invalid choice, try again, press any key to try again...");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }

                    break;

                default:
                    Console.WriteLine("invalid datatype");
                    break;
            }
        }
        public static void searchAndPrintAllData<T>(MySqlConnection conn, List<T> list)
        {
            switch (typeof(T).ToString())
            {
                case "ConnectToSQLdatabase.Game":
                    searchAllData(conn, list);
                    printAllData(list);
                    break;

                case "ConnectToSQLdatabase.Publisher":
                    searchAllData(conn, list);
                    printAllData(list);
                    break;

                case "ConnectToSQLdatabase.Store":
                    searchAllData(conn, list);
                    printAllData(list);
                    break;

                case "ConnectToSQLdatabase.Tag":
                    searchAllData(conn, list);
                    printAllData(list);
                    break;

                case "ConnectToSQLdatabase.Rating":
                    searchAllData(conn, list);
                    printAllData(list);
                    break;

                case "ConnectToSQLdatabase.StoreHasGames":
                    searchAllData(conn, list);
                    printAllData(list);
                    break;

                case "ConnectToSQLdatabase.GamesHasTags":
                    searchAllData(conn, list);
                    printAllData(list);
                    break;

                case "ConnectToSQLdatabase.Address":
                    searchAllData(conn, list);
                    printAllData(list);
                    break;

                default:
                    Console.WriteLine("invalid datatype");
                    break;
            }
        }
        public static void searchAndPrintBasicData<T>(MySqlConnection conn, List<T> list)
        {
            switch (typeof(T).ToString())
            {
                case "ConnectToSQLdatabase.Game":

                    searchAllData(conn, list);
                    printBasicData(list);
                    break;

                case "ConnectToSQLdatabase.Developer":

                    searchAllData(conn, list);
                    printBasicData(list);
                    break;

                case "ConnectToSQLdatabase.Publisher":
                    searchAllData(conn, list);
                    printBasicData(list);
                    break;

                case "ConnectToSQLdatabase.Store":

                    searchAllData(conn, list);
                    printBasicData(list);
                    break;

                case "ConnectToSQLdatabase.Tag":
                    searchAllData(conn, list);
                    printBasicData(list);
                    break;

                case "ConnectToSQLdatabase.Rating":
                    searchAllData(conn, list);
                    printBasicData(list);
                    break;

                case "ConnectToSQLdatabase.StoreHasGames":
                    searchAllData(conn, list);
                    printBasicData(list);
                    break;

                case "ConnectToSQLdatabase.GamesHasTags":
                    searchAllData(conn, list);
                    printBasicData(list);
                    break;

                case "ConnectToSQLdatabase.Address":
                    searchAllData(conn, list);
                    printBasicData(list);
                    break;

                default:
                    Console.WriteLine("invalid datatype");
                    break;
            }
        }


        public static void update<T>(MySqlConnection conn, List<T> list)
        {
            int index;
            string keyword;
            string query;
            MySqlCommand cmd;
            MySqlDataReader reader;
            string choice;
            switch (typeof(T).ToString())
            {
                case "ConnectToSQLdatabase.Game":
                    Console.Clear();
                    //print list of gamesid
                    selectAllAndPrintBasicData(conn, Game.games);
                    //have user select number
                    Console.WriteLine("Type the number of the game you wish to update");
                    index = Convert.ToInt32(Console.ReadLine());
                    Game currentGame = Game.games[index - 1];
                    int gameindex = getRealID(Game.games, index);
                    Console.Clear();
                    //present all variables in gamesid that are updatable
                    //have user enter the new values
                    Console.WriteLine($"Do you wish to alter the name, current: {currentGame.name}? If yes type the name, otherwise leave blank");
                    choice = Console.ReadLine();
                    string gameName = string.IsNullOrEmpty(choice) ? currentGame.name : choice;
                    Console.Clear();
                    Console.WriteLine($"Do you wish to alter if the game is multiplayer or not, current: {currentGame.multiplayer}? If yes type the status (true for yes and false for no), otherwise leave blank");
                    choice = Console.ReadLine();
                    bool mp = string.IsNullOrEmpty(choice) ? currentGame.multiplayer : Convert.ToBoolean(choice);
                    Console.Clear();
                    Console.WriteLine($"Do you wish to alter the release date, current: {currentGame.relseaseDate}? If yes type the date (use YYYY-MM-DD format), otherwise leave blank");
                    choice = Console.ReadLine();
                    string release = string.IsNullOrEmpty(choice) ? currentGame.relseaseDate : choice;
                    Console.Clear();

                    selectAllData(conn, Developer.developers);
                    Console.WriteLine($"Do you wish to alter the developer, current: {Developer.developers[currentGame.developer].name}? If yes type anything to confirm, otherwise leave blank ");
                    string devchoice = Console.ReadLine();
                    string gamedevname;
                    int devAdd;
                    Console.Clear();
                    if (string.IsNullOrEmpty(devchoice))
                    {
                        //display devchoice list
                        selectAllAndPrintBasicData(conn, Developer.developers);
                        Console.WriteLine("If the name you wish to change to appears on the list, enter the number corresponding with the name, write -1 if unknown." +
                        "\nIf the name has not appeared, you can add a new developer:" +
                        "\nTo add type in the name and the country of origin, seprarate with a comma, is the country unknown leave it blank" +
                        "\nEx: -1 | 1 | GameDev , Sweden | GameDev: ");
                        devchoice = Console.ReadLine();


                        string[] devC = null;
                        if (int.TryParse(devchoice, out devAdd))
                        {
                            gamedevname = Developer.developers[devAdd].name;
                            devAdd = getRealID(Developer.developers, devAdd);
                        }
                        else
                        {
                            devchoice.Trim();
                            if (devchoice.Contains(","))
                            {
                                devC = devchoice.Split(',');
                                devchoice = string.IsNullOrEmpty(devC[1]) ? devC[0] : devC[0] + "'" + "," + "'" + devC[1];
                            }

                            query = $"CALL addDev('{devchoice}');" +
                                $"CALL searchDev(last_insert_id());";
                            cmd = new MySqlCommand(query, conn);
                            conn.Open();
                            reader = cmd.ExecuteReader();
                            reader.Read();
                            devAdd = Convert.ToInt32(reader["developers_id"]);
                            gamedevname = reader["developers_name"].ToString();
                            new Developer(Convert.ToInt32(reader["developers_id"]), reader["developers_name"].ToString(),
                                reader["developers_country"].ToString(), 0, -1);
                            conn.Close();
                        }
                    }
                    else
                    {
                        gamedevname = Developer.developers[currentGame.developer].name;
                        devAdd = Developer.developers[currentGame.developer].id;
                    }


                    //display pub list
                    Console.Clear();
                    selectAllData(conn, Publisher.publishers);
                    Console.WriteLine($"Do you wish to alter the publisher, current: {Publisher.publishers[currentGame.publisher].name}? If yes type anything to confirm, otherwise leave blank ");
                    string pubchoice = Console.ReadLine();
                    string gamepubname;
                    int pubAdd;
                    Console.Clear();
                    if (string.IsNullOrEmpty(devchoice))
                    {
                        selectAllAndPrintBasicData(conn, Publisher.publishers);
                        Console.WriteLine("If the name you wish to change to appears on the list, enter the number corresponding with the name, write -1 if unknown." +
                            "\nIf the name has not appeared, you can add a new publisher:" +
                            "\nTo add type in the name and the country of origin, seprarate with a comma, is the country unknown leave it blank" +
                           "otherwise leave blank Ex: 1 | GamePub, Swedem| GamePub:");
                        pubchoice = Console.ReadLine();


                        string[] pubC = null;
                        if (int.TryParse(pubchoice, out pubAdd))
                        {
                            gamepubname = Publisher.publishers[pubAdd].name;
                            pubAdd = getRealID(Publisher.publishers, pubAdd - 1);
                        }
                        else
                        {
                            pubchoice.Trim();
                            if (pubchoice.Contains(","))
                            {
                                pubC = pubchoice.Split(',');
                                pubchoice = string.IsNullOrEmpty(pubC[1]) ? pubC[0] : pubC[0] + "'" + "," + "'" + pubC[1];
                            }

                            string addPub = $"CALL addPub('{pubchoice}');" +
                                $"call searchPub(last_insert_id());";
                            cmd = new MySqlCommand(addPub, conn);
                            conn.Open();
                            reader = cmd.ExecuteReader();
                            reader.Read();
                            pubAdd = Convert.ToInt32(reader["publishers_id"]);
                            gamepubname = reader["publishers_name"].ToString();
                            new Publisher(Convert.ToInt32(reader["publishers_id"]), reader["publishers_name"].ToString(),
                                reader["publishers_country"].ToString(), 0, -1);
                            conn.Close();
                        }
                    }
                    else
                    {
                        gamepubname = Publisher.publishers[currentGame.publisher].name;
                        pubAdd = Publisher.publishers[currentGame.publisher].id;
                    }

                    //show the new result, have user confirm

                    Console.WriteLine($"The game will change from" +
                    $"\n\tNAME: {currentGame.name}\tMULTIPLAYER: {currentGame.multiplayer}\tRELEASE DATE: {currentGame.relseaseDate}\tDEVELOPER: {currentGame.developer}\tPUBLISHER: {currentGame.publisher}" +
                    $"\nto\tNAME: {gameName}\tMULTIPLAYER: {mp}\tRELEASE DATE: {release}\tDEVELOPER: {gamedevname}\tPUBLISHER: {gamepubname}" +
                    $"\nDo you wish to approve of these changes, type 1, to discard type 0:");
                    choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            // build command string
                            //Execute it
                            query = $"CALL updateGame('{gameName}',{mp},'{release}',{devAdd},{pubAdd})";
                            cmd = new MySqlCommand(query, conn);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            break;

                        case "0":

                            break;

                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }


                    Console.Clear();
                    break;

                case "ConnectToSQLdatabase.Developer":

                    //print list of developers
                    selectAllAndPrintBasicData(conn, Developer.developers);
                    //have user select number
                    Console.WriteLine("Type the number of the developer you wish to update");
                    index = Convert.ToInt32(Console.ReadLine());
                    int devindex = getRealID(Developer.developers, index);
                    Developer currDev = Developer.developers[index - 1];
                    Console.Clear();
                    //present all variables in developers that are updatable
                    //have user enter the new values
                    Console.WriteLine("Do you wish to alter the name? If yes type the name, otherwise leave blank");
                    choice = Console.ReadLine();
                    string devname = string.IsNullOrEmpty(choice) ? currDev.name : choice;
                    Console.Clear();
                    Console.WriteLine("Do you wish to alter the country? If yes type the country of origin, otherwise leave blank: ");
                    choice = Console.ReadLine();
                    string countryDev = string.IsNullOrEmpty(choice) ? currDev.country : choice;
                    Console.Clear();

                    //show the new result, have user confirm

                    Console.WriteLine($"The developer will change from" +
                    $"\n\tNAME: {currDev.name}\tCOUNTRY: {currDev.country}" +
                    $"\nto\tNAME: {devname}\tCOUNTRY: {countryDev}" +
                    $"\nDo you wish to approve of these changes, type 1, to discard type 0:");
                    choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            // build command string
                            //Execute it
                            query = $"CALL updateDev({devindex},'{devname}','{countryDev}')";
                            cmd = new MySqlCommand(query, conn);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            break;

                        case "0":
                            break;

                        default:
                            Console.WriteLine("Invalid choice try again");
                            break;
                    }


                    Console.Clear();
                    break;

                case "ConnectToSQLdatabase.Publisher":
                    //print list of publishers
                    selectAllAndPrintBasicData(conn, Publisher.publishers);
                    //have user select number
                    Console.WriteLine("Type the number of the publisher you wish to update");
                    index = Convert.ToInt32(Console.ReadLine());
                    int pubindex = getRealID(Publisher.publishers, index);
                    Publisher currPub = Publisher.publishers[index - 1];
                    Console.Clear();
                    //present all variables in developers that are updatable
                    //have user enter the new values
                    Console.WriteLine("Do you wish to alter the name? If yes type the name, otherwise leave blank");
                    choice = Console.ReadLine();
                    string pubname = string.IsNullOrEmpty(choice) ? currPub.name : choice;
                    Console.Clear();
                    Console.WriteLine("Do you wish to alter the country? If yes type the country of origin, otherwise leave blank: ");
                    choice = Console.ReadLine();
                    string countryPub = string.IsNullOrEmpty(choice) ? currPub.country : choice;
                    Console.Clear();

                    //show the new result, have user confirm

                    Console.WriteLine($"The publisher will change from" +
                    $"\n\tNAME: {currPub.name}\tCOUNTRY: {currPub.country}" +
                    $"\nto\tNAME: {pubname}\tCOUNTRY: {countryPub}" +
                    $"\nDo you wish to approve of these changes, type 1, to discard type 0:");
                    choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            // build command string
                            //Execute it
                            query = $"CALL updatePub({pubindex},'{pubname}','{countryPub}')";
                            cmd = new MySqlCommand(query, conn);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            break;

                        case "0":
                            break;

                        default:
                            Console.WriteLine("Invalid choice try again");
                            break;
                    }

                    Console.Clear();
                    break;

                case "ConnectToSQLdatabase.Store":
                    //print list of stores
                    selectAllAndPrintBasicData(conn, Store.stores);
                    //have user select number
                    Console.WriteLine("Type the number of the store you wish to update");
                    index = Convert.ToInt32(Console.ReadLine());
                    int storeindex = getRealID(Store.stores, index);
                    Store currstore = Store.stores[index - 1];
                    Console.Clear();
                    //present all variables in developers that are updatable
                    //have user enter the new values
                    Console.WriteLine("Do you wish to alter the name? If yes type the name, otherwise leave blank");
                    choice = Console.ReadLine();
                    string storename = string.IsNullOrEmpty(choice) ? currstore.name : choice;
                    Console.Clear();

                    //show the new result, have user confirm

                    Console.WriteLine($"The store will change from" +
                    $"\n\tNAME: {currstore.name}" +
                    $"\nto\tNAME: {storename}" +
                    $"\nDo you wish to approve of these changes, type 1, to discard type 0:");
                    choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            // build command string
                            //Execute it
                            query = $"CALL updateStore({storeindex},'{storename}');";
                            cmd = new MySqlCommand(query, conn);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            break;

                        case "0":
                            break;

                        default:
                            Console.WriteLine("Invalid choice try again");
                            break;
                    }

                    Console.Clear();
                    break;

                case "ConnectToSQLdatabase.Tag":
                    //print list of tags
                    selectAllAndPrintBasicData(conn, Tag.tags);
                    //have user select number
                    Console.WriteLine("Type the number of the tag you wish to update");
                    index = Convert.ToInt32(Console.ReadLine());
                    int tagindex = getRealID(Tag.tags, index);
                    Tag currTag = Tag.tags[index - 1];
                    Console.Clear();
                    //present all variables in developers that are updatable
                    //have user enter the new values
                    Console.WriteLine("Do you wish to alter the name? If yes type the name, otherwise leave blank");
                    choice = Console.ReadLine();
                    string tagname = string.IsNullOrEmpty(choice) ? currTag.name : choice;
                    Console.Clear();

                    //show the new result, have user confirm
                    Console.WriteLine($"The store will change from" +
                    $"\n\tNAME: {currTag.name}" +
                    $"\nto\tNAME: {tagname}" +
                    $"\nDo you wish to approve of these changes, type 1, to discard type 0:");
                    choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            // build command string
                            //Execute it
                            query = $"CALL updateTags({tagindex},'{tagname}');";
                            cmd = new MySqlCommand(query, conn);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            break;

                        case "0":
                            break;

                        default:
                            Console.WriteLine("Invalid choice try again");
                            break;
                    }

                    Console.Clear();
                    break;

                case "ConnectToSQLdatabase.Rating":
                    selectAllAndPrintBasicData(conn, list);
                    Console.WriteLine("Type the number of the rating you wish to update: ");
                    index = Convert.ToInt32(Console.ReadLine());
                    int ratindex = getRealID(list, index);
                    Rating currRat = Rating.ratings[index - 1];
                    Console.Clear();
                    //present all variables in developers that are updatable
                    //have user enter the new values
                    Console.WriteLine("Do you wish to alter the review? If yes type the name, otherwise leave blank");
                    choice = Console.ReadLine();
                    string review = string.IsNullOrEmpty(choice) ? currRat.review : choice;
                    Console.Clear();
                    Console.WriteLine("Do you wish to alter the score? If yes type the score, otherwise leave blank: ");
                    choice = Console.ReadLine();
                    int ratscore = string.IsNullOrEmpty(choice) ? currRat.score : Convert.ToInt32(choice);
                    Console.Clear();

                    //show the new result, have user confirm

                    Console.WriteLine($"The rating will change from" +
                    $"\n\tREVIEW: {currRat.review}\tSCORE: {currRat.score}" +
                    $"\nto\tREVIEW: {review}\tSCORE: {ratscore}" +
                    $"\nDo you wish to approve of these changes, type 1, to discard type 0:");
                    choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            // build command string
                            //Execute it
                            query = $"CALL updateRating({ratindex},'{review}',{ratscore})";
                            cmd = new MySqlCommand(query, conn);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            break;

                        case "0":

                            break;

                        default:
                            Console.WriteLine("Invalid choice try again");
                            break;
                    }


                    Console.Clear();
                    break;

                case "ConnectToSQLdatabase.StoreHasGames":
                    //update price
                    //get list of games
                    //list of stores that have game
                    searchAndPrintBasicData(conn, list);
                    if (Store.stores.Count == 0)
                    {
                        break;
                    }
                    Console.WriteLine("Enter the number corresponding with the store selling the game you wish to change the price of");
                    index = Convert.ToInt32(Console.ReadLine());

                    StoreHasGames currSHG = StoreHasGames.storehasgames[index - 1];
                    int gameid = currSHG.gamesid;
                    int storeid = currSHG.storeid;
                    Console.Clear();
                    Console.WriteLine($"Enter the new price (Current price: {currSHG.price}): ");
                    int price = Convert.ToInt32(Console.ReadLine());

                    //show the new result, have user confirm
                    Console.WriteLine($"The price will change from:" +
                    $"\n\t{currSHG.price} to {price}" +
                    $"\nDo you wish to approve of these changes, type 1, to discard type 0:");
                    choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            // build command string
                            //Execute it
                            query = $"CALL updatePrice({storeid},{gameid},{price}";
                            cmd = new MySqlCommand(query, conn);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            break;

                        case "0":
                            break;

                        default:
                            Console.WriteLine("Invalid choice try again");
                            break;
                    }
                    break;

                case "ConnectToSQLdatabase.Address":

                    bool validchoice = true;
                    do
                    {

                        Console.WriteLine("Do you wish to update an address of a store (1), a developer (2) or a publisher (3)");
                        int addressChoice = Convert.ToInt32(Console.ReadLine());
                        string business;
                        int addressIndex;
                        Address currAdd;
                        Console.Clear();
                        switch (addressChoice)
                        {
                            case 1:
                                searchAndPrintBasicData(conn, Store.stores);
                                Console.WriteLine("Enter the number corresponding with the store you wish to add the address to: ");
                                index = Convert.ToInt32(Console.ReadLine());
                                index = getRealID(Store.stores, index);
                                Store currStore = Store.stores[index - 1];
                                addressIndex = currStore.addresses;
                                currAdd = Address.addresses[addressIndex];
                                Console.Clear();
                                Console.WriteLine("Enter the city you wish to add: ");
                                string city = Console.ReadLine();
                                Console.Clear();
                                Console.WriteLine("Enter the street address you wish to add: ");
                                string street = Console.ReadLine();
                                Console.Clear();
                                Console.WriteLine("Enter the zipcode you wish to add: ");
                                string zip = Console.ReadLine();
                                Console.Clear();
                                query = $"CALL updateAddress({index},'{city}','{street}','{zip}'); CALL searchStore({index});";
                                Console.Clear();
                                do
                                {
                                    Console.WriteLine($"The address will change from" +
                                    $"\n\tCITY: {currAdd.city}\tSTREET: {currAdd.street}\tZIP: {currAdd.zip}" +
                                    $"\nto\tCITY: {city}\tSTREET: {street}\tZIP: {zip}" +
                                    $"\nDo you wish to approve of these changes, type 1, to discard type 0:");
                                    choice = Console.ReadLine();
                                    switch (choice)
                                    {
                                        case "1":
                                            // build command string
                                            //Execute it
                                            cmd = new MySqlCommand(query, conn);
                                            conn.Open();
                                            cmd.ExecuteNonQuery();
                                            conn.Close();
                                            break;

                                        case "0":
                                            continue;
                                            break;

                                        default:
                                            Console.WriteLine("Invalid choice try again");
                                            break;
                                    }
                                } while (choice != "0" ^ choice != "1");
                                break;

                            case 2:
                                selectAllAndPrintBasicData(conn, Developer.developers);
                                Console.WriteLine("Enter the number corresponding with the developer you wish to add the address to: ");
                                index = Convert.ToInt32(Console.ReadLine());
                                index = getRealID(Developer.developers, index);
                                currDev = Developer.developers[index - 1];
                                addressIndex = currDev.address;
                                currAdd = Address.addresses[addressIndex];
                                Console.Clear();
                                Console.WriteLine("Enter the city you wish to add: ");
                                city = Console.ReadLine();
                                Console.Clear();
                                Console.WriteLine("Enter the street address you wish to add: ");
                                street = Console.ReadLine();
                                Console.Clear();
                                Console.WriteLine("Enter the zipcode you wish to add: ");
                                zip = Console.ReadLine();
                                Console.Clear();
                                query = $"CALL updateAddress({index},'{city}','{street}','{zip}'); CALL searchDev({index});";
                                Console.Clear();
                                do
                                {
                                    Console.WriteLine($"The address will change from" +
                                    $"\n\tCITY: {currAdd.city}\tSTREET: {currAdd.street}\tZIP: {currAdd.zip}" +
                                    $"\nto\tCITY: {city}\tSTREET: {street}\tZIP: {zip}" +
                                    $"\nDo you wish to approve of these changes, type 1, to discard type 0:");
                                    choice = Console.ReadLine();
                                    switch (choice)
                                    {
                                        case "1":
                                            // build command string
                                            //Execute it
                                            cmd = new MySqlCommand(query, conn);
                                            conn.Open();
                                            cmd.ExecuteNonQuery();
                                            conn.Close();
                                            break;

                                        case "0":
                                            continue;
                                            break;

                                        default:
                                            Console.WriteLine("Invalid choice try again");
                                            break;
                                    }
                                } while (choice != "0" ^ choice != "1");
                                break;

                            case 3:
                                selectAllAndPrintBasicData(conn, Publisher.publishers);
                                Console.WriteLine("Enter the number corresponding with the publisher you wish to add the address to: ");
                                index = Convert.ToInt32(Console.ReadLine());
                                index = getRealID(Publisher.publishers, index);
                                currPub = Publisher.publishers[index - 1];
                                addressIndex = currPub.address;
                                currAdd = Address.addresses[addressIndex];
                                Console.Clear();
                                Console.WriteLine("Enter the city you wish to add: ");
                                city = Console.ReadLine();
                                Console.Clear();
                                Console.WriteLine("Enter the street address you wish to add: ");
                                street = Console.ReadLine();
                                Console.Clear();
                                Console.WriteLine("Enter the zipcode you wish to add: ");
                                zip = Console.ReadLine();
                                Console.Clear();
                                query = $"CALL updateAddress({index},'{city}','{street}','{zip}'); CALL searchPub({index});";
                                Console.Clear();

                                Console.WriteLine($"The address will change from" +
                                $"\n\tCITY: {currAdd.city}\tSTREET: {currAdd.street}\tZIP: {currAdd.zip}" +
                                $"\nto\tCITY: {city}\tSTREET: {street}\tZIP: {zip}" +
                                $"\nDo you wish to approve of these changes, type 1, to discard type 0:");
                                choice = Console.ReadLine();
                                switch (choice)
                                {
                                    case "1":
                                        // build command string
                                        //Execute it
                                        cmd = new MySqlCommand(query, conn);
                                        conn.Open();
                                        cmd.ExecuteNonQuery();
                                        conn.Close();
                                        break;

                                    case "0":
                                        break;

                                    default:
                                        Console.WriteLine("Invalid choice try again");
                                        break;
                                }

                                break;

                            default:
                                Console.WriteLine("invalid choice, try again, press any key to try again...");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                        }
                    } while (validchoice);

                    Console.Clear();

                    break;

                default:
                    Console.WriteLine("invalid datatype");
                    break;
            }

        }

        public static void delete<T>(MySqlConnection conn, List<T> list)
        {
            string query;
            int index;
            string keyword;
            MySqlCommand cmd;
            MySqlDataReader reader;
            switch (typeof(T).ToString())
            {
                case "ConnectToSQLdatabase.Game":
                    //print list of gamesid
                    selectAllAndPrintBasicData(conn, Game.games);
                    //have user select number
                    Console.WriteLine("Type the number of the game you wish to remove");
                    index = Convert.ToInt32(Console.ReadLine());
                    index = getRealID(list, index);
                    query = $"CALL removeDev({index})";
                    break;

                case "ConnectToSQLdatabase.Developer":
                    //print list of developers
                    selectAllAndPrintBasicData(conn, Developer.developers);
                    //have user select number
                    Console.WriteLine("Type the number of the game you wish to remove");
                    index = Convert.ToInt32(Console.ReadLine());
                    index = getRealID(list, index);


                    break;

                case "ConnectToSQLdatabase.Publisher":
                    //print list of publishers
                    selectAllAndPrintBasicData(conn, Publisher.publishers);
                    //have user select number
                    Console.WriteLine("Type the number of the publisher you wish to remove");
                    index = Convert.ToInt32(Console.ReadLine());
                    index = getRealID(list, index);

                    break;

                case "ConnectToSQLdatabase.Store":
                    //print list of storeid
                    selectAllAndPrintBasicData(conn, Store.stores);
                    //have user select number
                    Console.WriteLine("Type the number of the store you wish to remove");
                    index = Convert.ToInt32(Console.ReadLine());
                    index = getRealID(list, index);

                    break;

                case "ConnectToSQLdatabase.Tag":
                    //print list of tags
                    selectAllAndPrintBasicData(conn, Tag.tags);
                    //have user select number
                    Console.WriteLine("Type the number of the tag you wish to update");
                    index = Convert.ToInt32(Console.ReadLine());
                    index = getRealID(list, index);
                    break;

                case "ConnectToSQLdatabase.Rating":
                    //present list of gamesid
                    selectAllAndPrintBasicData(conn, Game.games);
                    searchAndPrintBasicData(conn, Rating.ratings);
                    Console.WriteLine("Type the number of the rating you wish to update: ");
                    index = Convert.ToInt32(Console.ReadLine());
                    index = getRealID(list, index);

                    break;

                case "ConnectToSQLdatabase.StoreHasGames":
                    searchAndPrintBasicData(conn, StoreHasGames.storehasgames);
                    //have user select number
                    Console.WriteLine("Type the number of the store you wish to remove the game from");
                    keyword = Console.ReadLine();
                    index = Convert.ToInt32(keyword);
                    index = getRealID(Tag.tags, index);
                    query = $"CALL removeGameFromStore({StoreHasGames.storehasgames[0].storeid},{index})";
                    cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    break;

                case "ConnectToSQLdatabase.GamesHasTags":
                    searchAndPrintBasicData(conn, GamesHasTags.gameshastags);
                    //have user select number
                    Console.WriteLine("Type the number of the store you wish to remove the game from");
                    keyword = Console.ReadLine();
                    index = Convert.ToInt32(keyword);
                    index = getRealID(Tag.tags, index);
                    query = $"CALL removeTagFromGame({GamesHasTags.gameshastags[0].tagid},{index})";
                    cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    break;

                default:
                    Console.WriteLine("invalid datatype");
                    break;
            }
        }



        public static void printBasicData<T>(List<T> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("There was nothing to show, press any button to continue...");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            int count = 1;
            switch (typeof(T).ToString())
            {
                case "ConnectToSQLdatabase.Game":
                    foreach (Game item in Game.games)
                    {
                        Console.WriteLine($"{count}. {item.name}");
                        count++;
                    }
                    break;
                case "ConnectToSQLdatabase.Developer":
                    foreach (Developer item in Developer.developers)
                    {
                        Console.WriteLine($"{count}. {item.name}");
                        count++;
                    }
                    break;
                case "ConnectToSQLdatabase.Publisher":
                    foreach (Publisher item in Publisher.publishers)
                    {
                        Console.WriteLine($"{count}. {item.name}");
                        count++;
                    }
                    break;
                case "ConnectToSQLdatabase.Store":
                    foreach (Store item in Store.stores)
                    {
                        Console.WriteLine($"{count}. {item.name}");
                        count++;
                    }
                    break;
                case "ConnectToSQLdatabase.Rating":
                    foreach (Rating item in Rating.ratings)
                    {
                        Console.WriteLine($"{count}. {item.review}");
                        count++;
                    }
                    break;
                case "ConnectToSQLdatabase.Tag":
                    foreach (Tag item in Tag.tags)
                    {
                        Console.WriteLine($"{count}. {item.name}");
                        count++;
                    }
                    break;
                case "ConnectToSQLdatabase.StoreHasGames":
                    foreach (StoreHasGames item in StoreHasGames.storehasgames)
                    {
                        Console.WriteLine($"{count}.\tStore:\t{Store.stores[item.storeid].name}");
                        count++;
                    }
                    break;

                case "ConnectToSQLdatabase.GamesHasTags":
                    foreach (GamesHasTags item in GamesHasTags.gameshastags)
                    {
                        Console.WriteLine($"{count}.\tGame:\t{Game.games[item.gameid].name}");
                        count++;
                    }
                    break;
                case "ConnectToSQLdatabase.Address":
                    foreach (Address item in Address.addresses)
                    {
                        Console.WriteLine($"{count}.\tCity:\t{item.city}\tStreet:\t{item.street}\tZip:\t{item.zip}");
                        count++;
                    }
                    break;
                default:
                    Console.WriteLine("invalid datatype");
                    break;

            }
        }
        public static void printAllData<T>(List<T> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("There was nothing to show, press any button to continue...");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            int count = 1;
            switch (typeof(T).ToString())
            {
                case "ConnectToSQLdatabase.Game":
                    foreach (Game item in Game.games)
                    {
                        //fix so it shows devchoice and pubchoice name instead of gameid
                        Console.WriteLine($"{count}.\tName:\t{item.name}\tMP:\t{item.multiplayer}\tRating:\t{item.rating}" +
                            $"\tAvgPrice:\t{item.avgPrice}\tReleaseDate:\t{item.relseaseDate}\tDeveloper:\t{item.developer}\tPublisher:\t{item.publisher}");
                        count++;
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "ConnectToSQLdatabase.Developer":
                    foreach (Developer item in Developer.developers)
                    {
                        //add address
                        Console.WriteLine($"{count}.\tName:\t{item.name}\tCountry:\t{item.country}");
                        count++;
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "ConnectToSQLdatabase.Publisher":
                    foreach (Publisher item in Publisher.publishers)
                    {
                        //add address
                        Console.WriteLine($"{count}.\tName:\t{item.name}\tCountry:\t{item.country}");
                        count++;
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "ConnectToSQLdatabase.Store":
                    foreach (Store item in Store.stores)
                    {
                        //add address
                        Console.WriteLine($"{count}.\tName:\t{item.name}");
                        count++;
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "ConnectToSQLdatabase.Rating":
                    foreach (Rating item in Rating.ratings)
                    {
                        //add gameid name
                        Console.WriteLine($"{count}.\tReview:\t{item.review}\tScore:\t{item.score}");
                        count++;
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "ConnectToSQLdatabase.Tag":
                    foreach (Tag item in Tag.tags)
                    {
                        //add gameid name
                        Console.WriteLine($"{count}.\tTag:\t{item.name}\tList of games:\t{item.gamelist}\tNumber of games\t{item.nbrOfGames}");
                        count++;
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "ConnectToSQLdatabase.StoreHasGames":
                    foreach (StoreHasGames item in StoreHasGames.storehasgames)
                    {
                        Console.WriteLine($"{count}.\tStore:\t{Store.stores[item.storeid].name}\tGames:");
                        count++;
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "ConnectToSQLdatabase.Address":
                    foreach (Address item in Address.addresses)
                    {
                        Console.WriteLine($"{count}.\tCity:\t{item.city}\tStreet:\t{item.street}\tZip:\t{item.zip}");
                        count++;
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    break;

                default:
                    Console.WriteLine("invalid datatype");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    break;

            }
        }

        public static int getRealID<T>(List<T> list, int index)
        {
            int selectedID = index - 1;
            switch (typeof(T).ToString())
            {
                case "ConnectToSQLdatabase.Game":
                    return selectedID = Game.games[selectedID].id;
                    break;
                case "ConnectToSQLdatabase.Developer":
                    return selectedID = Developer.developers[selectedID].id;
                    break;
                case "ConnectToSQLdatabase.Publisher":
                    return selectedID = Publisher.publishers[selectedID].id;
                    break;
                case "ConnectToSQLdatabase.Store":
                    return selectedID = Store.stores[selectedID].id;
                    break;
                case "ConnectToSQLdatabase.Rating":
                    return selectedID = Rating.ratings[selectedID].id;
                    break;
                case "ConnectToSQLdatabase.Tag":
                    return selectedID = Tag.tags[selectedID].id;
                    break;
                default:
                    Console.WriteLine("invalid datatype");
                    throw new Exception();
                    break;
            }
        }

        public static string login()
        {
            string pass = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    Console.Write("\b \b");
                    pass = pass[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    pass += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);
            return pass;
        }
        public static void timer()
        {
            for (int i = 30; i >= 0; i--)
            {
                Console.Write($"\rTry again in {i:00}");
                System.Threading.Thread.Sleep(1000);
            }
        }
    }

}
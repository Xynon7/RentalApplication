using System;
using System.Collections.Generic;
using System.Linq;
using RentalsApp.DBObjects;
using MySql;
using MySql.Data.MySqlClient;
using RentalApp.DBObjects;

namespace RentalsApp
{
    public class RASQLManager
    {
        public static RASQLManager sqlManagerInstance = new RASQLManager();
        public static User currentUser = null;

        private static string connectionString;
        private MySqlConnection mySqlConnection;

        string mySQLFormatDate = "yyyy-MM-dd HH:mm:ss";

        private RASQLManager ()
        {
            connectionString = "server=70.177.89.61;user=application;database=rentit;port=3306;password=easyPassword";
            mySqlConnection = new MySqlConnection(connectionString);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                mySqlConnection.Open();
                Console.WriteLine("MySQL connection succeeded.");
                mySqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("MySQL connection failed.");
                Console.WriteLine(ex.ToString());
            }
        }

        public List<Communication> GetMessagesSent(string username)
        {
            List<Communication> messageResults = new List<Communication>();

            Console.WriteLine("Connecting to MySQL...");
            mySqlConnection.Open();
            Console.WriteLine("MySQL connection succeeded.");

            string sqlQueryText = "SELECT * FROM communication WHERE sender_username = @Username";

            using (MySqlCommand sqlCommand = new MySqlCommand(sqlQueryText, mySqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@Username", username);

                using (MySqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        Communication result = new Communication();
                        result.sender = sqlDataReader[0].ToString();
                        result.receiver = sqlDataReader[1].ToString();
                        result.messageBody = sqlDataReader[3].ToString();
                        result.messageDateTime = DateTime.Parse(sqlDataReader[4].ToString()).Date;
                        result.messageDateTime.AddHours(DateTime.Parse(sqlDataReader[5].ToString()).Hour);
                        result.messageDateTime.AddMinutes(DateTime.Parse(sqlDataReader[5].ToString()).Minute);
                        result.messageDateTime.AddSeconds(DateTime.Parse(sqlDataReader[5].ToString()).Second);
                        messageResults.Add(result);
                    }
                }
            }

            return messageResults;
        }

        public List<Communication> GetMessagesReceived(string username)
        {
            List<Communication> messageResults = new List<Communication>();

            Console.WriteLine("Connecting to MySQL...");
            mySqlConnection.Open();
            Console.WriteLine("MySQL connection succeeded.");

            string sqlQueryText = "SELECT * FROM communication WHERE receiver_username = @Username";

            using (MySqlCommand sqlCommand = new MySqlCommand(sqlQueryText, mySqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@Username", username);

                using (MySqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        Communication result = new Communication();
                        result.sender = sqlDataReader[0].ToString();
                        result.receiver = sqlDataReader[1].ToString();
                        result.messageBody = sqlDataReader[3].ToString();
                        result.messageDateTime = DateTime.Parse(sqlDataReader[4].ToString()).Date;
                        result.messageDateTime.AddHours(DateTime.Parse(sqlDataReader[5].ToString()).Hour);
                        result.messageDateTime.AddMinutes(DateTime.Parse(sqlDataReader[5].ToString()).Minute);
                        result.messageDateTime.AddSeconds(DateTime.Parse(sqlDataReader[5].ToString()).Second);
                        messageResults.Add(result);
                    }
                }
            }
            mySqlConnection.Close();

            return messageResults;
        }

        internal List<Exchange> GetExchanges(string username)
        {
            throw new NotImplementedException();
        }

        public List<Location> GetLocations(string username)
        {
            List<Location> locationResults = new List<Location>();

            Console.WriteLine("Connecting to MySQL...");
            mySqlConnection.Open();
            Console.WriteLine("MySQL connection succeeded.");

            string sqlQueryText = "SELECT * FROM location WHERE username = @Username";

            using (MySqlCommand sqlCommand = new MySqlCommand(sqlQueryText, mySqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@Username", username);

                using (MySqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        Location result = new Location(sqlDataReader[1].ToString(), sqlDataReader[2].ToString(), sqlDataReader[3].ToString(), sqlDataReader[4].ToString());
                        locationResults.Add(result);
                    }
                }
            }
            mySqlConnection.Close();

            return locationResults;
        }

        public List<WishlistItem> GetWishlist(string username)
        {
            List<WishlistItem> wishlist = new List<WishlistItem>();

            Console.WriteLine("Connecting to MySQL...");
            mySqlConnection.Open();
            Console.WriteLine("MySQL connection succeeded.");

            string sqlQueryText = "SELECT * FROM wish_list WHERE username = @Username";

            using (MySqlCommand sqlCommand = new MySqlCommand(sqlQueryText, mySqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@Username", username);

                using (MySqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        WishlistItem result = new WishlistItem(sqlDataReader[1].ToString(), Decimal.Parse(sqlDataReader[2].ToString()), Decimal.Parse(sqlDataReader[3].ToString()));
                        wishlist.Add(result);
                    }
                }
            }
            mySqlConnection.Close();

            return wishlist;
        }

        public Item GetSpecificItem(int itemNum)
        {
            Item item = new Item();

            Console.WriteLine("Connecting to MySQL...");
            mySqlConnection.Open();
            Console.WriteLine("MySQL connection succeeded.");

            string sqlQueryText = "SELECT * FROM item WHERE item_number = @ItemNum";

            using (MySqlCommand sqlCommand = new MySqlCommand(sqlQueryText, mySqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@ItemNum", itemNum);

                using (MySqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        item.listingInfo = new ItemListing(sqlDataReader[1].ToString(), sqlDataReader[2].ToString(), sqlDataReader[3].ToString(), sqlDataReader[5].ToString(), Double.Parse(sqlDataReader[4].ToString()), DateTime.MinValue);
                        item.isAvailable = (bool)sqlDataReader[10];
                        item.availabilityDate = DateTime.Parse(sqlDataReader[10].ToString());
                    }
                }
            }
            mySqlConnection.Close();

            return item;
        }

        public List<Item> GetItemsByDescription(string description)
        {
            List<Item> items = new List<Item>();

            Console.WriteLine("Connecting to MySQL...");
            mySqlConnection.Open();
            Console.WriteLine("MySQL connection succeeded.");

            string sqlQueryText = "SELECT * FROM item WHERE item_description = @Description";

            using (MySqlCommand sqlCommand = new MySqlCommand(sqlQueryText, mySqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@Description", description);

                using (MySqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        Item item = new Item();
                        item.listingInfo = new ItemListing(sqlDataReader[1].ToString(), sqlDataReader[2].ToString(), sqlDataReader[3].ToString(), sqlDataReader[5].ToString(), Double.Parse(sqlDataReader[4].ToString()), DateTime.MinValue);
                        item.isAvailable = (bool)sqlDataReader[10];
                        item.availabilityDate = DateTime.Parse(sqlDataReader[10].ToString());
                        items.Add(item);
                    }
                }
            }
            mySqlConnection.Close();

            return items;
        }

        public Cart GetCart(string username)
        {
            Cart cartResult = null;

            Console.WriteLine("Connecting to MySQL...");
            mySqlConnection.Open();
            Console.WriteLine("MySQL connection succeeded.");

            string sqlQueryText = "SELECT * FROM cart WHERE username = @Username AND active_inactive = true";

            using (MySqlCommand sqlCommand = new MySqlCommand(sqlQueryText, mySqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@Username", username);

                using (MySqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        if (cartResult == null)
                        {
                            cartResult = new Cart();
                            cartResult.active = true;
                            cartResult.creationTime = DateTime.Parse(sqlDataReader[7].ToString()).Date;
                            cartResult.creationTime.AddHours(DateTime.Parse(sqlDataReader[8].ToString()).Hour);
                            cartResult.creationTime.AddMinutes(DateTime.Parse(sqlDataReader[8].ToString()).Minute);
                            cartResult.creationTime.AddSeconds(DateTime.Parse(sqlDataReader[8].ToString()).Second);
                            cartResult.itemList = new Dictionary<Item, int>();
                        }
                        Item itemBeingAdded = new Item();
                        itemBeingAdded.listingInfo = new ItemListing(sqlDataReader[1].ToString(), sqlDataReader[2].ToString(), sqlDataReader[3].ToString(), GetItemDescription(sqlDataReader[1].ToString()), Convert.ToDouble(sqlDataReader[5].ToString()), new DateTime());
                        cartResult.itemList.Add(itemBeingAdded, Convert.ToInt32(sqlDataReader[4].ToString()));
                        cartResult.totalCost += itemBeingAdded.listingInfo.costPerDay * cartResult.itemList[itemBeingAdded];
                    }
                }
            }
            mySqlConnection.Close();

            return cartResult;
        }

        public List<Invoice> GetInvoices(string username)
        {
            Dictionary<string, Invoice> invoiceResults = new Dictionary<string, Invoice>();

            Console.WriteLine("Connecting to MySQL...");
            mySqlConnection.Open();
            Console.WriteLine("MySQL connection succeeded.");

            string sqlQueryText = "SELECT * FROM communication WHERE receiver_username = @Username";

            using (MySqlCommand sqlCommand = new MySqlCommand(sqlQueryText, mySqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@Username", username);

                using (MySqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        if (invoiceResults.ContainsKey(sqlDataReader[5].ToString()))
                        {
                            Invoice newInvoice = new Invoice();
                            newInvoice.invoiceNum = sqlDataReader[5].ToString();
                            newInvoice.invoiceTime = DateTime.Parse(sqlDataReader[6].ToString()).Date;
                            newInvoice.invoiceTime.AddHours(DateTime.Parse(sqlDataReader[7].ToString()).Hour);
                            newInvoice.invoiceTime.AddMinutes(DateTime.Parse(sqlDataReader[7].ToString()).Minute);
                            newInvoice.invoiceTime.AddSeconds(DateTime.Parse(sqlDataReader[7].ToString()).Second);
                            newInvoice.cart = new Cart();
                            newInvoice.cart.active = true;
                            newInvoice.cart.creationTime = newInvoice.invoiceTime;
                            newInvoice.cart.itemList = new Dictionary<Item, int>();
                            invoiceResults.Add(sqlDataReader[5].ToString(), newInvoice);
                        }
                        Item itemBeingAdded = new Item();
                        itemBeingAdded.listingInfo = new ItemListing(sqlDataReader[1].ToString(), "", "", GetItemDescription(sqlDataReader[5].ToString()), Convert.ToDouble(sqlDataReader[5].ToString()), new DateTime());
                        invoiceResults[sqlDataReader[5].ToString()].cart.itemList.Add(itemBeingAdded, Convert.ToInt32(sqlDataReader[4].ToString()));
                        invoiceResults[sqlDataReader[5].ToString()].cart.totalCost += itemBeingAdded.listingInfo.costPerDay * invoiceResults[sqlDataReader[5].ToString()].cart.itemList[itemBeingAdded];
                    }
                }
            }
            mySqlConnection.Close();

            return invoiceResults.Values.ToList();
        }

        public Invoice GetSpecificInvoice(string invoiceNum)
        {
            Invoice invoiceResult = null;

            Console.WriteLine("Connecting to MySQL...");
            mySqlConnection.Open();
            Console.WriteLine("MySQL connection succeeded.");

            string sqlQueryText = "SELECT * FROM invoice WHERE invoice_number = @InvoiceNum";

            using (MySqlCommand sqlCommand = new MySqlCommand(sqlQueryText, mySqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@InvoiceNum", invoiceNum);

                using (MySqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        if (invoiceResult == null)
                        {
                            invoiceResult = new Invoice();
                            invoiceResult.invoiceNum = sqlDataReader[5].ToString();
                            invoiceResult.invoiceTime = DateTime.Parse(sqlDataReader[6].ToString()).Date;
                            invoiceResult.invoiceTime.AddHours(DateTime.Parse(sqlDataReader[7].ToString()).Hour);
                            invoiceResult.invoiceTime.AddMinutes(DateTime.Parse(sqlDataReader[7].ToString()).Minute);
                            invoiceResult.invoiceTime.AddSeconds(DateTime.Parse(sqlDataReader[7].ToString()).Second);
                            invoiceResult.cart = new Cart();
                            invoiceResult.cart.active = true;
                            invoiceResult.cart.creationTime = invoiceResult.invoiceTime;
                            invoiceResult.cart.itemList = new Dictionary<Item, int>();
                        }
                        Item itemBeingAdded = new Item();
                        itemBeingAdded.listingInfo = new ItemListing(sqlDataReader[1].ToString(), "", "", GetItemDescription(sqlDataReader[5].ToString()), Convert.ToDouble(sqlDataReader[5].ToString()), new DateTime());
                        invoiceResult.cart.itemList.Add(itemBeingAdded, Convert.ToInt32(sqlDataReader[4].ToString()));
                        invoiceResult.cart.totalCost += itemBeingAdded.listingInfo.costPerDay * invoiceResult.cart.itemList[itemBeingAdded];
                    }
                }
            }
            mySqlConnection.Close();

            return invoiceResult;
        }

        public List<Exchange> GetRenterExchanges(string username)
        {
            List<Exchange> exchangeResults = new List<Exchange>();

            Console.WriteLine("Connecting to MySQL...");
            mySqlConnection.Open();
            Console.WriteLine("MySQL connection succeeded.");

            string sqlQueryText = "SELECT * FROM exchanges WHERE renter_username = @Username";

            using (MySqlCommand sqlCommand = new MySqlCommand(sqlQueryText, mySqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@Username", username);

                using (MySqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        Exchange result = new Exchange();
                        result.renter = sqlDataReader[0].ToString();
                        result.lessor = sqlDataReader[1].ToString();
                        result.invoiceForExchange = GetSpecificInvoice(sqlDataReader[2].ToString());
                        result.location = sqlDataReader[4].ToString();
                        result.method = sqlDataReader[5].ToString();
                        result.time = DateTime.Parse(sqlDataReader[6].ToString()).Date;
                        result.time.AddHours(DateTime.Parse(sqlDataReader[7].ToString()).Hour);
                        result.time.AddMinutes(DateTime.Parse(sqlDataReader[7].ToString()).Minute);
                        result.time.AddSeconds(DateTime.Parse(sqlDataReader[7].ToString()).Second);
                        result.paymentComplete = Convert.ToBoolean(sqlDataReader[8].ToString());
                        exchangeResults.Add(result);
                    }
                }
            }
            mySqlConnection.Close();

            return exchangeResults;
        }

        public string GetItemDescription(string itemNum)
        {
            string descriptionResult = "";

            Console.WriteLine("Connecting to MySQL...");
            mySqlConnection.Open();
            Console.WriteLine("MySQL connection succeeded.");

            string sqlQueryText = "SELECT item_description FROM item_listing WHERE item_number = @ItemNumber";

            using (MySqlCommand sqlCommand = new MySqlCommand(sqlQueryText, mySqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@ItemNumber", itemNum);

                using (MySqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        descriptionResult = sqlDataReader[0].ToString();
                    }
                }
            }
            mySqlConnection.Close();

            return descriptionResult;
        }

        public bool ValidateLogin(string username, string password)
        {
            bool isValidLogin = false;

            Console.WriteLine("Connecting to MySQL...");
            mySqlConnection.Open();
            Console.WriteLine("MySQL connection succeeded.");

            string sqlQueryText = "SELECT * FROM rentit_user WHERE username = @Username AND user_password = @Password";

            using (MySqlCommand sqlCommand = new MySqlCommand(sqlQueryText, mySqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@Username", username);
                sqlCommand.Parameters.AddWithValue("@Password", password);

                using (MySqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        isValidLogin = true;
                        currentUser = new User(sqlDataReader[0].ToString(), sqlDataReader[2].ToString(), sqlDataReader[3].ToString(), sqlDataReader[4].ToString(), sqlDataReader[5].ToString(), DateTime.Parse(sqlDataReader[6].ToString()), sqlDataReader[7].ToString(), sqlDataReader[8].ToString(), sqlDataReader[9].ToString(), (bool)sqlDataReader[10], (bool)sqlDataReader[11], (bool)sqlDataReader[12]);
                    }
                }
            }
            mySqlConnection.Close();

            return isValidLogin;
        }


        /*
         * Creates a new account in the database.
         * Anything besides Username and Password (the first 2 args) is nullable. A default value will be inserted.
         */
        public bool CreateNewAccount(string username, string password, string gender, string phoneNumber, string stateId, string sSN, DateTime dOB, string firstName, string middleInitial, string lastName)
        {
            bool successful = false;

            if (username != null && password != null)
            {
                if (gender == null)
                {
                    gender = "Other";
                }
                if (phoneNumber == null)
                {
                    phoneNumber = "000-000-0000";
                }
                if (stateId == null)
                {
                    stateId = "0";
                }
                if (sSN == null)
                {
                    sSN = "000000000000";
                }
                if (dOB == null)
                {
                    dOB = DateTime.MinValue;
                }
                if (firstName == null)
                {
                    firstName = "Default";
                }
                if (middleInitial == null)
                {
                    middleInitial = "Default";
                }
                if (lastName == null)
                {
                    lastName = "Default";
                }

                try
                {
                    Console.WriteLine("Connecting to MySQL...");
                    mySqlConnection.Open();
                    Console.WriteLine("MySQL connection succeeded.");

                    using (MySqlCommand mySqlCommand = new MySqlCommand("INSERT INTO rentit_user VALUES(@Username, @Password, @Gender, @PhoneNumber, @StateId, @SSN, @DOB, @FirstName, @MiddleInitial, @LastName, 0, 0, 0, 0)"))
                    {
                        mySqlCommand.Parameters.AddWithValue("@Username", username);
                        mySqlCommand.Parameters.AddWithValue("@Password", password);
                        mySqlCommand.Parameters.AddWithValue("@Gender", gender);
                        mySqlCommand.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        mySqlCommand.Parameters.AddWithValue("@StateId", stateId);
                        mySqlCommand.Parameters.AddWithValue("@SSN", sSN);
                        mySqlCommand.Parameters.AddWithValue("@DOB", dOB);
                        mySqlCommand.Parameters.AddWithValue("@FirstName", firstName);
                        mySqlCommand.Parameters.AddWithValue("@MiddleInitial", middleInitial);
                        mySqlCommand.Parameters.AddWithValue("@LastName", lastName);

                        mySqlCommand.ExecuteNonQuery();
                    }

                    using (MySqlCommand mySqlCommand = new MySqlCommand("INSERT INTO receiver VALUES(@Username)"))
                    {
                        mySqlCommand.Parameters.AddWithValue("@Username", username);

                        mySqlCommand.ExecuteNonQuery();
                    }

                    using (MySqlCommand mySqlCommand = new MySqlCommand("INSERT INTO sender VALUES(@Username)"))
                    {
                        mySqlCommand.Parameters.AddWithValue("@Username", username);

                        mySqlCommand.ExecuteNonQuery();
                    }

                    using (MySqlCommand mySqlCommand = new MySqlCommand("INSERT INTO seeker VALUES(@Username)"))
                    {
                        mySqlCommand.Parameters.AddWithValue("@Username", username);

                        mySqlCommand.ExecuteNonQuery();
                    }

                    mySqlConnection.Close();
                    currentUser = new User(username, gender, phoneNumber, stateId, sSN, dOB, firstName, middleInitial, lastName, false, false, false);
                    successful = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Data insertion failed.");
                    Console.WriteLine(ex.ToString());
                }
            }

            return successful;
        }

        /*
         * Register as a renter in the database.
         */
        public bool RegisterRenter(string username)
        {
            bool successful = false;

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                mySqlConnection.Open();
                Console.WriteLine("MySQL connection succeeded.");

                using (MySqlCommand mySqlCommand = new MySqlCommand("INSERT INTO renter VALUES(@Username, 0, 0)"))
                {
                    mySqlCommand.Parameters.AddWithValue("@Username", currentUser.username);

                    mySqlCommand.ExecuteNonQuery();
                }

                mySqlConnection.Close();
                successful = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Data insertion failed.");
                Console.WriteLine(ex.ToString());
            }

            return successful;
        }


        /*
         * Register as a lessor in the database.
         * Anything besides Username and Password (the first 2 args) is nullable. A default value will be inserted.
         */
        public bool RegisterLessor(string username, string password, string gender, string phoneNumber, string stateId, string sSN, DateTime dOB, string firstName, string middleInitial, string lastName)
        {
            bool successful = false;

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                mySqlConnection.Open();
                Console.WriteLine("MySQL connection succeeded.");

                using (MySqlCommand mySqlCommand = new MySqlCommand("INSERT INTO lessor VALUES(@Username, 0, 0)"))
                {
                    mySqlCommand.Parameters.AddWithValue("@Username", currentUser.username);

                    mySqlCommand.ExecuteNonQuery();
                }

                mySqlConnection.Close();
                successful = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Data insertion failed.");
                Console.WriteLine(ex.ToString());
            }

            return successful;
        }

        /*
         * Creates a new location in the database.
         */
        public bool CreateLocation(string locationName, string address, string city, string state, string zipCode)
        {
            bool successful = false;

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                mySqlConnection.Open();
                Console.WriteLine("MySQL connection succeeded.");

                using (MySqlCommand mySqlCommand = new MySqlCommand("INSERT INTO location VALUES(@Username, @LocationName, @Address, @City, @State, @ZipCode)"))
                {
                    mySqlCommand.Parameters.AddWithValue("@Username", currentUser.username);
                    mySqlCommand.Parameters.AddWithValue("@LocationName", locationName);
                    mySqlCommand.Parameters.AddWithValue("@Address", address);
                    mySqlCommand.Parameters.AddWithValue("@City", city);
                    mySqlCommand.Parameters.AddWithValue("@State", state);
                    mySqlCommand.Parameters.AddWithValue("@ZipCode", zipCode);

                    mySqlCommand.ExecuteNonQuery();
                }

                mySqlConnection.Close();
                successful = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Data insertion failed.");
                Console.WriteLine(ex.ToString());
            }

            return successful;
        }

        public bool CreateCommunication(string receiverUsername, string body)
        {

            bool successful = false;

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                mySqlConnection.Open();
                Console.WriteLine("MySQL connection succeeded.");

                using (MySqlCommand mySqlCommand = new MySqlCommand("INSERT INTO communication VALUES(@Sender, @Receiver, DEFAULT, @Body, @Date, @Time)"))
                {
                    mySqlCommand.Parameters.AddWithValue("@Sender", currentUser.username);
                    mySqlCommand.Parameters.AddWithValue("@Receiver", receiverUsername);
                    mySqlCommand.Parameters.AddWithValue("@Body", body);
                    mySqlCommand.Parameters.AddWithValue("@Date", DateTime.Today.Date);
                    mySqlCommand.Parameters.AddWithValue("@Time", DateTime.Now.TimeOfDay);

                    mySqlCommand.ExecuteNonQuery();
                }

                mySqlConnection.Close();
                successful = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Data insertion failed.");
                Console.WriteLine(ex.ToString());
            }

            return successful;
        }

        public bool CreateOffenseReport(string offendingUsername, string stateId, int ssn, int category, string offense)
        {

            bool successful = false;

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                mySqlConnection.Open();
                Console.WriteLine("MySQL connection succeeded.");

                using (MySqlCommand mySqlCommand = new MySqlCommand("INSERT INTO offense_list VALUES(@OffendingUsername, @StateId, @SSN, @Date, @Time, @Category, @Offense)"))
                {
                    mySqlCommand.Parameters.AddWithValue("@OffendingUsername", offendingUsername);
                    mySqlCommand.Parameters.AddWithValue("@StateId", stateId);
                    mySqlCommand.Parameters.AddWithValue("@SSN", ssn);
                    mySqlCommand.Parameters.AddWithValue("@Date", DateTime.Today.Date);
                    mySqlCommand.Parameters.AddWithValue("@Time", DateTime.Now.TimeOfDay);
                    mySqlCommand.Parameters.AddWithValue("@Category", category);
                    mySqlCommand.Parameters.AddWithValue("@Offense", offense);

                    mySqlCommand.ExecuteNonQuery();
                }

                mySqlConnection.Close();
                successful = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Data insertion failed.");
                Console.WriteLine(ex.ToString());
            }

            return successful;
        }

        public bool CreateReport(string offendingUsername, string violation, string severity, DateTime violationDateTime, bool haveScreenshot, bool havePictures, bool havePoliceReport, bool haveAudio, int validity)
        {

            bool successful = false;

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                mySqlConnection.Open();
                Console.WriteLine("MySQL connection succeeded.");

                using (MySqlCommand mySqlCommand = new MySqlCommand("INSERT INTO offense_list VALUES(@ReportingUsername, DEFAULT, @Date, @Time, @OffendingUsername, @Violation, @Severity, @ViolationDate, @ViolationTime, @HaveScreenshot, @HavePictures, @HavePoliceReport, @HaveAudio, @Validity)"))
                {
                    mySqlCommand.Parameters.AddWithValue("@ReportingUsername", currentUser.username);
                    mySqlCommand.Parameters.AddWithValue("@Date", DateTime.Today.Date);
                    mySqlCommand.Parameters.AddWithValue("@Time", DateTime.Now.TimeOfDay);
                    mySqlCommand.Parameters.AddWithValue("@OffendingUsername", offendingUsername);
                    mySqlCommand.Parameters.AddWithValue("@Violation", violation);
                    mySqlCommand.Parameters.AddWithValue("@Severity", severity);
                    mySqlCommand.Parameters.AddWithValue("@ViolationDate", violationDateTime.Date);
                    mySqlCommand.Parameters.AddWithValue("@ViolationTime", violationDateTime.TimeOfDay);
                    mySqlCommand.Parameters.AddWithValue("@HaveScreenshot", haveScreenshot);
                    mySqlCommand.Parameters.AddWithValue("@HavePictures", havePictures);
                    mySqlCommand.Parameters.AddWithValue("@HavePoliceReport", havePoliceReport);
                    mySqlCommand.Parameters.AddWithValue("@HaveAudio", haveAudio);
                    mySqlCommand.Parameters.AddWithValue("@Validity", validity);

                    mySqlCommand.ExecuteNonQuery();
                }

                mySqlConnection.Close();
                successful = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Data insertion failed.");
                Console.WriteLine(ex.ToString());
            }

            return successful;
        }

        public bool CreatePayment(string paymentType, DateTime paymentTime, string cardInfo, string paymentInfo)
        {

            bool successful = false;

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                mySqlConnection.Open();
                Console.WriteLine("MySQL connection succeeded.");

                using (MySqlCommand mySqlCommand = new MySqlCommand("INSERT INTO payment VALUES(@Username, @PaymentType, @PaymentDate, @PaymentTime, @CardInfo, @PaymentInfo)"))
                {
                    mySqlCommand.Parameters.AddWithValue("@Username", currentUser.username);
                    mySqlCommand.Parameters.AddWithValue("@PaymentType", paymentType);
                    mySqlCommand.Parameters.AddWithValue("@PaymentDate", paymentTime.Date);
                    mySqlCommand.Parameters.AddWithValue("@PaymentTime", paymentTime.TimeOfDay);
                    mySqlCommand.Parameters.AddWithValue("@CardInfo", cardInfo);
                    mySqlCommand.Parameters.AddWithValue("@PaymentInfo", paymentInfo);

                    mySqlCommand.ExecuteNonQuery();
                }

                mySqlConnection.Close();
                successful = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Data insertion failed.");
                Console.WriteLine(ex.ToString());
            }

            return successful;
        }

        public bool CreateLessorRating(string lessorUsername, int payment, int communication, int onTime, int returnCondition, int interaction)
        {

            bool successful = false;

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                mySqlConnection.Open();
                Console.WriteLine("MySQL connection succeeded.");

                using (MySqlCommand mySqlCommand = new MySqlCommand("INSERT INTO payment VALUES(@RenterUsername, @LessorUsername, @Payment, @Communication, @OnTime, @ReturnCondition, @Interaction, @AverageRating)"))
                {
                    mySqlCommand.Parameters.AddWithValue("@RenterUsername", currentUser.username);
                    mySqlCommand.Parameters.AddWithValue("@LessorUsername", lessorUsername);
                    mySqlCommand.Parameters.AddWithValue("@Payment", payment);
                    mySqlCommand.Parameters.AddWithValue("@Communication", communication);
                    mySqlCommand.Parameters.AddWithValue("@OnTime", onTime);
                    mySqlCommand.Parameters.AddWithValue("@ReturnCondition", returnCondition);
                    mySqlCommand.Parameters.AddWithValue("@Interaction", interaction);

                    decimal average = (payment + communication + onTime + returnCondition + interaction) / 5;

                    mySqlCommand.Parameters.AddWithValue("@AverageRating", average);

                    mySqlCommand.ExecuteNonQuery();
                }

                mySqlConnection.Close();
                successful = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Data insertion failed.");
                Console.WriteLine(ex.ToString());
            }

            return successful;
        }

        public bool CreateRenterRating(string renterUsername, int exchangeNum, int itemCost, int deposit, int worksAsDescribed, int onTime, int communication, int interaction)
        {

            bool successful = false;

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                mySqlConnection.Open();
                Console.WriteLine("MySQL connection succeeded.");

                using (MySqlCommand mySqlCommand = new MySqlCommand("INSERT INTO payment VALUES(@RenterUsername, @LessorUsername, @ExchangeNum, @ItemCost, @Deposit, @WorksAsDescribed, @OnTime, @Communication, @Interaction, @AverageRating)"))
                {
                    mySqlCommand.Parameters.AddWithValue("@RenterUsername", renterUsername);
                    mySqlCommand.Parameters.AddWithValue("@LessorUsername", currentUser.username);
                    mySqlCommand.Parameters.AddWithValue("@ExchangeNum", exchangeNum);
                    mySqlCommand.Parameters.AddWithValue("@ItemCost", itemCost);
                    mySqlCommand.Parameters.AddWithValue("@Deposit", deposit);
                    mySqlCommand.Parameters.AddWithValue("@WorksAsDescribed", worksAsDescribed);
                    mySqlCommand.Parameters.AddWithValue("@OnTime", onTime);
                    mySqlCommand.Parameters.AddWithValue("@Communication", communication);
                    mySqlCommand.Parameters.AddWithValue("@ReturnCondition", deposit);
                    mySqlCommand.Parameters.AddWithValue("@Interaction", interaction);

                    decimal average = (itemCost + communication + onTime + deposit + interaction + worksAsDescribed) / 6;

                    mySqlCommand.Parameters.AddWithValue("@AverageRating", average);

                    mySqlCommand.ExecuteNonQuery();
                }

                mySqlConnection.Close();
                successful = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Data insertion failed.");
                Console.WriteLine(ex.ToString());
            }

            return successful;
        }

        /*
         * Changes the current user's Terms and Conditons acceptance status.
         */
        public bool ChangeAcceptedTC(bool acceptance)
        {

            bool successful = false;

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                mySqlConnection.Open();
                Console.WriteLine("MySQL connection succeeded.");

                using (MySqlCommand mySqlCommand = new MySqlCommand("UPDATE rentit_user SET agreed_terms_conditions = @Acceptance WHERE username = @Username"))
                {
                    mySqlCommand.Parameters.AddWithValue("@Username", currentUser.username);
                    mySqlCommand.Parameters.AddWithValue("@Acceptance", acceptance);

                    mySqlCommand.ExecuteNonQuery();
                }

                mySqlConnection.Close();
                successful = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Data update failed.");
                Console.WriteLine(ex.ToString());
            }

            return successful;
        }

        /*
         * Changes the current user's Privacy Policy acceptance status.
         */
        public bool ChangeAcceptedPP(bool acceptance)
        {

            bool successful = false;

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                mySqlConnection.Open();
                Console.WriteLine("MySQL connection succeeded.");

                using (MySqlCommand mySqlCommand = new MySqlCommand("UPDATE rentit_user SET agreed_privacy_policy = @Acceptance WHERE username = @Username"))
                {
                    mySqlCommand.Parameters.AddWithValue("@Username", currentUser.username);
                    mySqlCommand.Parameters.AddWithValue("@Acceptance", acceptance);

                    mySqlCommand.ExecuteNonQuery();
                }

                mySqlConnection.Close();
                successful = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Data update failed.");
                Console.WriteLine(ex.ToString());
            }

            return successful;
        }

        /*
         * Changes the current user's Standards Policy acceptance status.
         */
        public bool ChangeAcceptedSP(bool acceptance)
        {

            bool successful = false;

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                mySqlConnection.Open();
                Console.WriteLine("MySQL connection succeeded.");

                using (MySqlCommand mySqlCommand = new MySqlCommand("UPDATE rentit_user SET agreed_standards_policy = @Acceptance WHERE username = @Username"))
                {
                    mySqlCommand.Parameters.AddWithValue("@Username", currentUser.username);
                    mySqlCommand.Parameters.AddWithValue("@Acceptance", acceptance);

                    mySqlCommand.ExecuteNonQuery();
                }

                mySqlConnection.Close();
                successful = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Data update failed.");
                Console.WriteLine(ex.ToString());
            }

            return successful;
        }

        /*
         * Changes the current lessor's acceptance status.
         */
        public bool ChangeAcceptedLA(bool acceptance)
        {

            bool successful = false;

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                mySqlConnection.Open();
                Console.WriteLine("MySQL connection succeeded.");

                using (MySqlCommand mySqlCommand = new MySqlCommand("UPDATE lessor SET agreed_lessor = @Acceptance WHERE lessor_username = @Username"))
                {
                    mySqlCommand.Parameters.AddWithValue("@Username", currentUser.username);
                    mySqlCommand.Parameters.AddWithValue("@Acceptance", acceptance);

                    mySqlCommand.ExecuteNonQuery();
                }

                mySqlConnection.Close();
                successful = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Data update failed.");
                Console.WriteLine(ex.ToString());
            }

            return successful;
        }

        /*
         * Changes the current renter's acceptance status.
         */
        public bool ChangeAcceptedRA(bool acceptance)
        {

            bool successful = false;

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                mySqlConnection.Open();
                Console.WriteLine("MySQL connection succeeded.");

                using (MySqlCommand mySqlCommand = new MySqlCommand("SELECT agreed_renter FROM renter WHERE renter_username = @Username"))
                {
                    mySqlCommand.Parameters.AddWithValue("@Username", currentUser.username);

                    mySqlCommand.ExecuteNonQuery();
                }

                mySqlConnection.Close();
                successful = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Data update failed.");
                Console.WriteLine(ex.ToString());
            }

            return successful;
        }

        /*
         * Check the current lessor's acceptance status.
         */
        public bool CheckLessorAcceptance()
        {

            bool successful = false;

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                mySqlConnection.Open();
                Console.WriteLine("MySQL connection succeeded.");

                using (MySqlCommand mySqlCommand = new MySqlCommand("SELECT agreed_lessor FROM lessor WHERE lessor_username = @Username"))
                {
                    mySqlCommand.Parameters.AddWithValue("@Username", currentUser.username);

                    mySqlCommand.ExecuteNonQuery();
                }

                mySqlConnection.Close();
                successful = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Data update failed.");
                Console.WriteLine(ex.ToString());
            }

            return successful;
        }

        /*
         * Changes the current renter's acceptance status.
         */
        public bool CheckRenterAcceptance()
        {

            bool successful = false;

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                mySqlConnection.Open();
                Console.WriteLine("MySQL connection succeeded.");

                using (MySqlCommand mySqlCommand = new MySqlCommand("SELECT agreed_lessor FROM lessor WHERE lessor_username = @Username"))
                {
                    mySqlCommand.Parameters.AddWithValue("@Username", currentUser.username);

                    mySqlCommand.ExecuteNonQuery();
                }

                mySqlConnection.Close();
                successful = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Data update failed.");
                Console.WriteLine(ex.ToString());
            }

            return successful;
        }

        public SearchResult SearchForItems(string username, string itemNum, string brand, string type, string costPerDay, bool isAvailable, DateTime availabilityDate)
        {
            Console.WriteLine("Connecting to MySQL...");
            mySqlConnection.Open();
            Console.WriteLine("MySQL connection succeeded.");

            using (MySqlCommand cmd = new MySqlCommand("INSERT INTO analytics_events VALUES(DEFAULT, @Time, @SiteID, @CallLocation, @AssignmentID, @EventCategory, @EventAction, @EventLabel, @EventValue);", mySqlConnection))
            {
              /*  cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Time", analyticsEvent.Timestamp);
                cmd.Parameters.AddWithValue("@SiteID", analyticsEvent.SiteId);
                cmd.Parameters.AddWithValue("@AssignmentID", analyticsEvent.AssignmentId);
                cmd.Parameters.AddWithValue("@CallLocation", analyticsEvent.CallLocation);
                cmd.Parameters.AddWithValue("@EventCategory", analyticsEvent.EventCategory);
                cmd.Parameters.AddWithValue("@EventAction", analyticsEvent.EventAction);
                cmd.Parameters.AddWithValue("@EventLabel", analyticsEvent.EventLabel);
                cmd.Parameters.AddWithValue("@EventValue", analyticsEvent.EventValue);
                value = cmd.ExecuteNonQuery();   */
            }
            return null;
        } 

    }  
}
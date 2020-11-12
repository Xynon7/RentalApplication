using System;
using System.Collections.Generic;
using System.Linq;
using Java.Sql;
using MySql;
using MySql.Data.MySqlClient;
using RentalsApp.DBObjects;

namespace RentalsApp
{
    public class RASQLManager
    {
        public static RASQLManager sqlManagerInstance = new RASQLManager();

        private static string connectionString = "server=70.177.89.61;user=application;database=rentit;port=3306;password=easyPassword";
        private MySqlConnection mySqlConnection = new MySqlConnection(connectionString);

        string mySQLFormatDate = "yyyy-MM-dd HH:mm:ss";

        private RASQLManager ()
        {
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
                        result.messageDateTime = DateTime.Parse(sqlDataReader[3].ToString()).Date;
                        result.messageDateTime.AddHours(DateTime.Parse(sqlDataReader[4].ToString()).Hour);
                        result.messageDateTime.AddMinutes(DateTime.Parse(sqlDataReader[4].ToString()).Minute);
                        result.messageDateTime.AddSeconds(DateTime.Parse(sqlDataReader[4].ToString()).Second);
                        result.messageBody = sqlDataReader[5].ToString();
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
                        result.messageDateTime = DateTime.Parse(sqlDataReader[3].ToString()).Date;
                        result.messageDateTime.AddHours(DateTime.Parse(sqlDataReader[4].ToString()).Hour);
                        result.messageDateTime.AddMinutes(DateTime.Parse(sqlDataReader[4].ToString()).Minute);
                        result.messageDateTime.AddSeconds(DateTime.Parse(sqlDataReader[4].ToString()).Second);
                        result.messageBody = sqlDataReader[5].ToString();
                        messageResults.Add(result);
                    }
                }
            }
            mySqlConnection.Close();

            return messageResults;
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

            string sqlQueryText = "SELECT username, user_password FROM rentit_user WHERE username = @Username AND password = @Password";

            using (MySqlCommand sqlCommand = new MySqlCommand(sqlQueryText, mySqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@Username", username);
                sqlCommand.Parameters.AddWithValue("@Password", password);

                using (MySqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        isValidLogin = true;
                    }
                }
            }
            mySqlConnection.Close();

            return isValidLogin;
        }

        public SearchResult SearchForItems(string username, string itemNum, string brand, string type, string costPerDay, bool isAvailable, DateTime availabilityDate)
        {
            Console.WriteLine("Connecting to MySQL...");
            mySqlConnection.Open();
            Console.WriteLine("MySQL connection succeeded.");

            using (MySqlCommand cmd = new MySqlCommand("INSERT INTO analytics_events VALUES(DEFAULT, @Time, @SiteID, @CallLocation, @AssignmentID, @EventCategory, @EventAction, @EventLabel, @EventValue);", mySqlConnection))
            {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Time", analyticsEvent.Timestamp);
                cmd.Parameters.AddWithValue("@SiteID", analyticsEvent.SiteId);
                cmd.Parameters.AddWithValue("@AssignmentID", analyticsEvent.AssignmentId);
                cmd.Parameters.AddWithValue("@CallLocation", analyticsEvent.CallLocation);
                cmd.Parameters.AddWithValue("@EventCategory", analyticsEvent.EventCategory);
                cmd.Parameters.AddWithValue("@EventAction", analyticsEvent.EventAction);
                cmd.Parameters.AddWithValue("@EventLabel", analyticsEvent.EventLabel);
                cmd.Parameters.AddWithValue("@EventValue", analyticsEvent.EventValue);
                value = cmd.ExecuteNonQuery();
            }
        }

    }
}
using System;
using System.Collections.Generic;
using MySql;
using MySql.Data.MySqlClient;
using RentalsApp.DBObjects;

namespace RentalsApp
{
    public class RASQLManager
    {
        public static RASQLManager sqlManagerInstance = new RASQLManager();

        private static string connectionString = "server=70.177.89.61;user=application;database=world;port=3306;password=easyPassword";
        private MySqlConnection mySqlConnection = new MySqlConnection(connectionString);

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
            throw new NotImplementedException();
        }

        public List<Communication> GetMessagesReceived(string username)
        {
            throw new NotImplementedException();
        }

        public List<Location> GetLocations(string username)
        {
            throw new NotImplementedException();
        }

        public Cart GetCart(string username)
        {
            throw new NotImplementedException();
        }

        public List<Invoice> GetInvoices(string username)
        {
            throw new NotImplementedException();
        }

        public List<Exchange> GetExchanges(string username)
        {
            throw new NotImplementedException();
        }

        public SearchResult SearchForItems(string username, string itemNum, string brand, string type, string costPerDay, bool isAvailable, DateTime availabilityDate)
        {
            throw new NotImplementedException();
        }
    }
}
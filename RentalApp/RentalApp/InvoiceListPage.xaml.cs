using RentalsApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RentalApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InvoiceListPage : ContentPage
    {
        public InvoiceListPage()
        {
            InitializeComponent();
        }

        string invoiceList()
        {
            string user = RASQLManager.currentUser.username;
            string toReturn = "";
            List<RentalsApp.DBObjects.Invoice> listy;
            listy = RASQLManager.sqlManagerInstance.GetInvoices(user);
            
            foreach (RentalsApp.DBObjects.Invoice inv in listy)
            {
                RentalsApp.DBObjects.Cart InvoiceCart = inv.cart;
               string cost= InvoiceCart.totalCost.ToString();
                toReturn = toReturn + " " + inv.invoiceNum + " " + cost + "\n";
            }

            return toReturn;
        }
    }
}
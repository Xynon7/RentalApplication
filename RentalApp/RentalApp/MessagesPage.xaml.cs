
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RentalsApp;
using System;

namespace RentalApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MessagesPage : ContentPage
	{
		public string reciever, body;
		public string sentM, recM;
		public MessagesPage()
		{
			InitializeComponent();
			sentM = GetSent();
            if (sentM == "")
            {
				sentM = "No messages Sent";
            }
			sentDisplay.Text = sentM;
			
			recM = GetRec();
            if (recM == "")
            {
				recM = "No Messages Recieved";
            }
			
			recDisplay.Text = recM;
		}


		string GetSent()
		{
			List<RentalsApp.DBObjects.Communication> sentList;

			string user = RASQLManager.currentUser.username;

			sentList = RASQLManager.sqlManagerInstance.GetMessagesSent(user);

			string toReturn = "";

			foreach (RentalsApp.DBObjects.Communication messageSent in sentList)
			{
				toReturn = toReturn + "TO:" + messageSent.receiver + " " + messageSent.messageBody + "\n";
			}
			return toReturn;

		}

		string GetRec()
		{
			List<RentalsApp.DBObjects.Communication> recList;

			string user = RASQLManager.currentUser.username;

			recList = RASQLManager.sqlManagerInstance.GetMessagesReceived(user);

			string toReturn = "";

			foreach (RentalsApp.DBObjects.Communication messageRec in recList)
			{
				toReturn = toReturn + "From:" + messageRec.sender + " " + messageRec.messageBody + "\n";
			}
			return toReturn;
		}
		void OnRecCompleted(object sender, EventArgs e)
		{
			reciever = ((Entry)sender).Text;
		}

		void OnBodyCompleted(object sender, EventArgs e)
		{
			body = ((Entry)sender).Text;
		}

		async void OnSendClicked(object sender, EventArgs e)
		{

			bool success = RASQLManager.sqlManagerInstance.CreateCommunication(reciever, body);

			if (success)
			{
				await Navigation.PushAsync(new MessagesPage());
			}
			else
			{
				await Navigation.PushAsync(new ErrorPage());
			}

		}

		async void OnCancelClicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}

		async void OnHomeClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new HomePage());
		}
	}
}
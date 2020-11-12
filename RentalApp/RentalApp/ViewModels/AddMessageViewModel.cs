using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
namespace RentalApp.ViewModels
{
    class AddMessageViewModel : INotifyPropertyChanged
    {
        public string sender;
        public string receiver;
        public DateTime messageDateTime;
        public string messageBody;

        public string Sender
        {
            get { return sender; }
            set
            {
                sender = value;
            }
        }

        public string Receiver
        {
            get { return receiver; }
            set
            {
                receiver = value;
            }
        }

        public DateTime MessageDatetime
        {
            get { return messageDateTime; }
            set
            {
                messageDateTime = value;
            }
        }

        public string MessageBody
        {
            get { return messageBody; }
            set
            {
                messageBody = value;
            }
        }

        public Command AddMessageCommand { get; }

        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }



        public AddMessageViewModel()
        {
            AddMessageCommand = new Command(execute: () =>
           {
               AddMessage();
           });
        }

        public void AddMessage()
        {

        }



    }
}

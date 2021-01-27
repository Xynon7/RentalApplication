using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RentalApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchPage : ContentPage
	{
        public string type;
		public SearchPage ()
		{
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
        async void OnUploadClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page1());
        }
        async void OnFilterClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page2());
        }

        void OnTypeCompleted(object sender, EventArgs e)
        {
            type = ((Entry)sender).Text;
        }

        async void OnViewResultsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ResultsPage(type));
        }
    }
}
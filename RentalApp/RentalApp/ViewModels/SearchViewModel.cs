
using Xamarin.Forms;

namespace RentalApp.ViewModels
{
    public class SearchViewModel : ContentPage
	{
		public SearchViewModel ()
		{
			Content = new StackLayout {
				Children = {
					new Label { Text = "Welcome to Xamarin.Forms!" }
				}
			};
		}
	}
}

using Xamarin.Forms;

namespace RentalApp.ViewModels
{
    public class Page1 : ContentPage
	{
		public Page1 ()
		{
			Content = new StackLayout {
				Children = {
					new Label { Text = "Welcome to Xamarin.Forms!" }
				}
			};
		}
	}
}
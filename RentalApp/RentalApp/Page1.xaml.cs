//using Plugin.Media.Abstractions;
//using Plugin.Media;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RentalApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
		public Page1 ()
		{
            InitializeComponent();
        }

     /*   private async void OnAddPhotoClicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if(!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No Camera avaliable", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(
                new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    SaveToAlbum = true,
                });

            if (file == null)
                return;


            PathLabel.Text = file.AlbumPath;

            MainImage.Source = ImageSource.FromStream(() =>
              {
                  var stream = file.GetStream();
                  file.Dispose();
                  return stream;
              });
        } */
	}
}
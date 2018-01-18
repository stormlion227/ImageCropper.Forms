using Plugin.Media;
using Plugin.Media.Abstractions;
using Stormlion.ImageCropper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Test
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            CrossMedia.Current.Initialize();
        }

        protected async void OnClickedShow(object sender, EventArgs e)
        {
            ImageCropper.Current.PageTitle = "Test Title";

            ImageCropper.Current.CropShape = ImageCropper.CropShapeType.Oval;

            ImageCropper.Current.AspectRatioX = 2;
            ImageCropper.Current.AspectRatioY = 3;
            
            ImageCropper.Current.Show(this, null, (s) => {
                Device.BeginInvokeOnMainThread(() =>
                {
                    imageView.Source = ImageSource.FromFile(s);
                    Debug.WriteLine(s);
                });
            });
        }
    }
}

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
            new ImageCropper()
            {
//                PageTitle = "Test Title",
//                AspectRatioX = 1,
                //AspectRatioY = 1,
//                CropShape = ImageCropper.CropShapeType.Oval,
                Success = (imageFile) =>
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        imageView.Source = ImageSource.FromFile(imageFile);
                    });
                }
            }.Show(this);
        }
    }
}

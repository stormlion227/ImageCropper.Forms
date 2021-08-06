using Plugin.Media;
using Stormlion.ImageCropper;
using System;
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

        protected async void OnClickedRectangle(object sender, EventArgs e)
        {
            new ImageCropper()
            {
                //                PageTitle = "Test Title",
                //                AspectRatioX = 1,
                //                AspectRatioY = 1,
                Success = (croppingResultList) =>
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        imageView.Source = ImageSource.FromFile(croppingResultList[0].ImagePath);
                        string imagePath = croppingResultList[0].ImagePath;
                        string imageDate = croppingResultList[0].OriginalPictureDate;
                    });
                }
            }.Show(this);
        }

        private void OnClickedCircle(object sender, EventArgs e)
        {
            new ImageCropper()
            {
                CropShape = ImageCropper.CropShapeType.Oval,
                Success = (croppingResultList) =>
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        imageView.Source = ImageSource.FromFile(croppingResultList[0].ImagePath);
                    });
                }
            }.Show(this);
        }
    }
}

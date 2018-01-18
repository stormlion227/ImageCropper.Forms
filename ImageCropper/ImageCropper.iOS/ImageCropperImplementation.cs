using Bind_TOCropViewController;
using Foundation;
using Plugin.Media.Abstractions;
using Stormlion.ImageCropper.iOS;
using System.IO;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(ImageCropperImplementation))]
namespace Stormlion.ImageCropper.iOS
{
    public class ImageCropperImplementation : IImageCropperWrapper
    {
        public void ShowFromFile(string imageFile)
        {
            UIImage image = UIImage.FromFile(imageFile);
            
            TOCropViewController cropViewController = new TOCropViewController(image);

            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(cropViewController, true, null);
        }
    }
}
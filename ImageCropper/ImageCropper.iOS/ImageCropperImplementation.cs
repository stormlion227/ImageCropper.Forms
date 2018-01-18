using Bind_TOCropViewController;

using Stormlion.ImageCropper.iOS;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(ImageCropperImplementation))]
namespace Stormlion.ImageCropper.iOS
{
    public class ImageCropperImplementation : IImageCropperWrapper
    {
        public void Show()
        {
            UIImage image = UIImage.FromBundle("sample1");
            
            TOCropViewController cropViewController = new TOCropViewController(image);

            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(cropViewController, true, null);
        }
    }
}
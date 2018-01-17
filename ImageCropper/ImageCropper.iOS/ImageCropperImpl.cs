using Bind_TOCropViewController;
using Stormlion.ImageCropper;
using Stormlion.ImageCropper.iOS;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(ImageCropperImpl))]
namespace Stormlion.ImageCropper.iOS
{
    public class ImageCropperImpl : IImageCropper
    {
        public void ShowImageCropper(ImageCropper.CroppingStyle croppingStyle, ImageCropper.AspectRatioPreset aspectRatioPreset)
        {
            UIImage image = UIImage.FromBundle("sample1");

            TOCropViewController cropViewController;

            switch(croppingStyle)
            {
                case ImageCropper.CroppingStyle.Circular:
                    cropViewController = new TOCropViewController(TOCropViewCroppingStyle.Circular, image);
                    break;
                default:
                    cropViewController = new TOCropViewController(image);
                    break;
            }

            switch(aspectRatioPreset)
            {
                case ImageCropper.AspectRatioPreset.Square:
                    cropViewController.AspectRatioPreset = TOCropViewControllerAspectRatioPreset.Square;
                    break;
                case ImageCropper.AspectRatioPreset.AspectRatioPreset3x2:
                    cropViewController.AspectRatioPreset = TOCropViewControllerAspectRatioPreset.TOCropViewControllerAspectRatioPreset3x2;
                    break;
                case ImageCropper.AspectRatioPreset.AspectRatioPreset5x3:
                    cropViewController.AspectRatioPreset = TOCropViewControllerAspectRatioPreset.TOCropViewControllerAspectRatioPreset5x3;
                    break;
                case ImageCropper.AspectRatioPreset.AspectRatioPreset4x3:
                    cropViewController.AspectRatioPreset = TOCropViewControllerAspectRatioPreset.TOCropViewControllerAspectRatioPreset4x3;
                    break;
                case ImageCropper.AspectRatioPreset.AspectRatioPreset5x4:
                    cropViewController.AspectRatioPreset = TOCropViewControllerAspectRatioPreset.TOCropViewControllerAspectRatioPreset5x4;
                    break;
                case ImageCropper.AspectRatioPreset.AspectRatioPreset7x5:
                    cropViewController.AspectRatioPreset = TOCropViewControllerAspectRatioPreset.TOCropViewControllerAspectRatioPreset7x5;
                    break;
                case ImageCropper.AspectRatioPreset.AspectRatioPreset16x9:
                    cropViewController.AspectRatioPreset = TOCropViewControllerAspectRatioPreset.TOCropViewControllerAspectRatioPreset16x9;
                    break;
            }

            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(cropViewController, true, null);
        }
    }
}
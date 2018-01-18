using Stormlion.ImageCropper;
using Com.Theartofdev.Edmodo.Cropper;
using Plugin.CurrentActivity;
using Stormlion.ImageCropper.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(ImageCropperImplementation))]
namespace Stormlion.ImageCropper.Droid
{
    public class ImageCropperImplementation : IImageCropperWrapper
    {
        public void Show()
        {
            CropImage.Activity().Start(CrossCurrentActivity.Current.Activity);
        }
    }
}
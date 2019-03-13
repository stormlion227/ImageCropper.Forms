using System;
using Com.Theartofdev.Edmodo.Cropper;
using Android.App;
using Android.Content;
using Xamarin.Forms;

namespace Stormlion.ImageCropper.Droid
{
    public class Platform
    {
        public static void Init()
        {
            DependencyService.Register<IImageCropperWrapper, ImageCropperImplementation>();
        }

        public static async void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (requestCode == CropImage.CropImageActivityRequestCode)
            {
                CropImage.ActivityResult result = CropImage.GetActivityResult(data);

                // small delay
                await System.Threading.Tasks.Task.Delay(TimeSpan.FromMilliseconds(100));
                if (resultCode == Result.Ok)
                {
                    ImageCropper.Current.Success?.Invoke(result.Uri.Path);
                }
                else if ((int)resultCode == (int)(CropImage.CropImageActivityResultErrorCode))
                {
                    ImageCropper.Current.Faiure?.Invoke();
                }
            }
        }
    }
}
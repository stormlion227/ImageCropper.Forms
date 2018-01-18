using Com.Theartofdev.Edmodo.Cropper;
using Plugin.CurrentActivity;
using Stormlion.ImageCropper.Droid;
using System.Diagnostics;
using Xamarin.Forms;
using System;

[assembly: Dependency(typeof(ImageCropperImplementation))]
namespace Stormlion.ImageCropper.Droid
{
    public class ImageCropperImplementation : IImageCropperWrapper
    {
        public void ShowFromFile(string imageFile)
        {
            try
            {
                CropImage.ActivityBuilder activityBuilder = CropImage.Activity(Android.Net.Uri.FromFile(new Java.IO.File(imageFile)));

                if(ImageCropper.Current.CropShape == ImageCropper.CropShapeType.Oval)
                {
                    activityBuilder.SetCropShape(CropImageView.CropShape.Oval);
                }
                else
                {
                    activityBuilder.SetCropShape(CropImageView.CropShape.Rectangle);
                }

                if(ImageCropper.Current.AspectRatioX > 0 && ImageCropper.Current.AspectRatioY > 0)
                {
                    activityBuilder.SetFixAspectRatio(true);
                    activityBuilder.SetAspectRatio(ImageCropper.Current.AspectRatioX, ImageCropper.Current.AspectRatioY);
                }
                else
                {
                    activityBuilder.SetFixAspectRatio(false);
                }

                if(!string.IsNullOrWhiteSpace(ImageCropper.Current.PageTitle))
                {
                    activityBuilder.SetActivityTitle(ImageCropper.Current.PageTitle);
                }

                activityBuilder.Start(CrossCurrentActivity.Current.Activity);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            
        }
    }
}
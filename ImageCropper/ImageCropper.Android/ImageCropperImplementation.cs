using Com.Theartofdev.Edmodo.Cropper;
using Plugin.CurrentActivity;
using Stormlion.ImageCropper.Droid;
using System.Diagnostics;
using Xamarin.Forms;
using System;

namespace Stormlion.ImageCropper.Droid
{
    public class ImageCropperImplementation : IImageCropperWrapper
    {
        public void ShowFromFile(ImageCropper imageCropper, string imageFile)
        {
            try
            {
                CropImage.ActivityBuilder activityBuilder = CropImage.Activity(Android.Net.Uri.FromFile(new Java.IO.File(imageFile)));

                if(imageCropper.CropShape == ImageCropper.CropShapeType.Oval)
                {
                    activityBuilder.SetCropShape(CropImageView.CropShape.Oval);
                }
                else
                {
                    activityBuilder.SetCropShape(CropImageView.CropShape.Rectangle);
                }

                if(imageCropper.AspectRatioX > 0 && imageCropper.AspectRatioY > 0)
                {
                    activityBuilder.SetFixAspectRatio(true);
                    activityBuilder.SetAspectRatio(imageCropper.AspectRatioX, imageCropper.AspectRatioY);
                }
                else
                {
                    activityBuilder.SetFixAspectRatio(false);
                }

                if(!string.IsNullOrWhiteSpace(imageCropper.PageTitle))
                {
                    activityBuilder.SetActivityTitle(imageCropper.PageTitle);
                }

                activityBuilder.Start(CrossCurrentActivity.Current.Activity);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            
        }

        public byte[] GetBytes(string imageFile)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = System.IO.Path.Combine(documentsPath, imageFile);
            return System.IO.File.ReadAllBytes(filePath);
        }
    }
}
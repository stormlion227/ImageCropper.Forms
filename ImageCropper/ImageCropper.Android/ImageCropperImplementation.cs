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
                CropImage.Activity(Android.Net.Uri.FromFile(new Java.IO.File(imageFile))).Start(CrossCurrentActivity.Current.Activity);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            
        }
    }
}
using Com.Theartofdev.Edmodo.Cropper;
using System.Diagnostics;
using System;
using System.Collections.Generic;

namespace Stormlion.ImageCropper.Droid
{
    public class ImageCropperImplementation : IImageCropperWrapper
    {
        public void ShowFromFile(ImageCropper imageCropper, List<ImageProperties> imagesCroppingList)
        {
            try
            {
                CropImage.ActivityBuilder activityBuilder;

                foreach (var imageFile in imagesCroppingList)
                {
                    activityBuilder = CropImage.Activity(Android.Net.Uri.FromFile(new Java.IO.File(imageFile.ImagePath)));

                    if (imageCropper.CropShape == ImageCropper.CropShapeType.Oval)
                    {
                        activityBuilder.SetCropShape(CropImageView.CropShape.Oval);
                    }
                    else
                    {
                        activityBuilder.SetCropShape(CropImageView.CropShape.Rectangle);
                    }

                    if (imageCropper.AspectRatioX > 0 && imageCropper.AspectRatioY > 0)
                    {
                        activityBuilder.SetFixAspectRatio(true);
                        activityBuilder.SetAspectRatio(imageCropper.AspectRatioX, imageCropper.AspectRatioY);
                    }
                    else
                    {
                        activityBuilder.SetFixAspectRatio(false);
                    }

                    if (!string.IsNullOrWhiteSpace(imageCropper.PageTitle))
                    {
                        activityBuilder.SetActivityTitle(imageCropper.PageTitle);
                    }

                    activityBuilder.Start(Xamarin.Essentials.Platform.CurrentActivity);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

        }
    }
}
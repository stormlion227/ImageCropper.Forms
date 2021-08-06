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
            if (data == null)
            {
                ImageCropper.Current.indexCounter++;
                return;
            }

            else
            {
                if (requestCode == CropImage.CropImageActivityRequestCode)
                {
                    string originalFileCreationDate = string.Empty;

                    originalFileCreationDate = ImageCropper.Current.
                        BeforeCroppingList[ImageCropper.Current.
                        indexCounter].OriginalPictureDate;

                    CropImage.ActivityResult result = CropImage.GetActivityResult(data);

                    if (result != null)
                    {
                        ImageCropper.Current.CroppingResultList.Add(new ImageProperties()
                        {
                            ImagePath = result.Uri.Path,
                            OriginalPictureDate = originalFileCreationDate
                        });

                        ImageCropper.Current.indexCounter++;

                        // small delay
                        await System.Threading.Tasks.Task.Delay(TimeSpan.FromMilliseconds(100));

                        if (resultCode == Result.Ok)
                        {
                            if (ImageCropper.Current.indexCounter == ImageCropper.Current.BeforeCroppingList.Count)
                            {
                                ImageCropper.Current.Success?.Invoke(ImageCropper.Current.CroppingResultList);
                            }
                        }
                        else if ((int)resultCode == (int)(CropImage.CropImageActivityResultErrorCode))
                        {
                            ImageCropper.Current.Faiure?.Invoke();
                        }
                    }
                    else
                    {
                        ImageCropper.Current.Faiure?.Invoke();
                        return;
                    }
                }
            }
        }
    }
}
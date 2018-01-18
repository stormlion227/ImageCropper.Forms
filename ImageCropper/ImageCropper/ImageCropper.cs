using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Stormlion.ImageCropper
{
    public class ImageCropper
    {
        public static ImageCropper Current { get; } = new ImageCropper();

        public string SelectSourceTitle { get; set; } = "Select source";

        public string TakePhotoTitle { get; set; } = "Take Photo";

        public string PhotoLibraryTitle { get; set; } = "Photo Library";

        public Action<string> Success { get; set; }

        public Action Faiure { get; set; }

        public async void Show(Page page, string imageFile = null, Action<string> success = null, Action failure = null)
        {
            Success = success;
            Faiure = failure;

            if(imageFile == null)
            {
                await CrossMedia.Current.Initialize();

                MediaFile file;

                string action = await page.DisplayActionSheet(SelectSourceTitle, "Cancel", null, TakePhotoTitle, PhotoLibraryTitle);
                if (action == TakePhotoTitle)
                {
                    if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                    {
                        await page.DisplayAlert("No Camera", ":( No camera available.", "OK");
                        Faiure?.Invoke();
                        return;
                    }

                     file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions());
                }
                else if(action == PhotoLibraryTitle)
                {
                    if(!CrossMedia.Current.IsPickPhotoSupported)
                    {
                        await page.DisplayAlert("Error", "This device is not supported to pick photo.", "OK");
                        Faiure?.Invoke();
                        return;
                    }

                    file = await CrossMedia.Current.PickPhotoAsync();
                }
                else
                {
                    Faiure?.Invoke();
                    return;
                }

                if (file == null)
                {
                    Faiure?.Invoke();
                    return;
                }

                imageFile = file.Path;
            }

            DependencyService.Get<IImageCropperWrapper>().ShowFromFile(imageFile);
        }
    }
}

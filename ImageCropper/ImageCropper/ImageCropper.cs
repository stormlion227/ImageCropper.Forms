using Plugin.Media;
using Plugin.Media.Abstractions;
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

        public async void Show(Page page, string imageFile = null)
        {
            if(imageFile == null)
            {
                await CrossMedia.Current.Initialize();

                MediaFile file;

                string action = await page.DisplayActionSheet(SelectSourceTitle, "Cancel", null, TakePhotoTitle, PhotoLibraryTitle);
                if (action == TakePhotoTitle)
                {
                    if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                    {
                        page.DisplayAlert("No Camera", ":( No camera available.", "OK");
                        return;
                    }

                     file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions());
                }
                else if(action == PhotoLibraryTitle)
                {
                    if(!CrossMedia.Current.IsPickPhotoSupported)
                    {
                        page.DisplayAlert("Error", "This device is not supported to pick photo.", "OK");
                        return;
                    }

                    file = await CrossMedia.Current.PickPhotoAsync();
                }
                else
                {
                    return;
                }

                if (file == null)
                {
                    return;
                }

                imageFile = file.Path;
            }

            DependencyService.Get<IImageCropperWrapper>().ShowFromFile(imageFile);
        }
    }
}

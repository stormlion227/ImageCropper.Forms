using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Stormlion.ImageCropper
{
    public class ImageCropper
    {
        public static ImageCropper Current { get; set; }

        public ImageCropper()
        {
            Current = this;
        }

        public enum CropShapeType
        {
            Rectangle,
            Oval
        };


        public CropShapeType CropShape { get; set; } = CropShapeType.Rectangle;

        public int AspectRatioX { get; set; } = 0;

        public int AspectRatioY { get; set; } = 0;

        public string PageTitle { get; set; } = null;

        public string SelectSourceTitle { get; set; } = "Select source";

        public string TakePhotoTitle { get; set; } = "Take Photo";

        public string PhotoLibraryTitle { get; set; } = "Photo Library";

        public string CancelButtonTitle { get; set; } = "Cancel";        
        public string DestructiveButtonTitle { get; set; } = null;
        public PhotoSize ImageSize { get; set; } = PhotoSize.Full;
        public int ImageCompressionQuality { get; set; } = 100;

        public Action<string> Success { get; set; }

        public Action Faiure { get; set; }

        public async void Show(Page page, string imageFile = null)
        {
            MediaFile file = null;
            if (imageFile == null)
            {
                await CrossMedia.Current.Initialize();

                string action = await page.DisplayActionSheet(SelectSourceTitle, CancelButtonTitle, DestructiveButtonTitle,
                    TakePhotoTitle, PhotoLibraryTitle);
                if (action == TakePhotoTitle)
                {
                    if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                    {
                        await page.DisplayAlert("No Camera", ":( No camera available.", "OK");
                        Faiure?.Invoke();
                        return;
                    }

                    file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                    {
                        PhotoSize = ImageSize,
                        CompressionQuality = ImageCompressionQuality,
                    });
                }
                else if (action == PhotoLibraryTitle)
                {
                    if (!CrossMedia.Current.IsPickPhotoSupported)
                    {
                        await page.DisplayAlert("Error", "This device is not supported to pick photo.", "OK");
                        Faiure?.Invoke();
                        return;
                    }

                    file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
                        {SaveMetaData = true, CompressionQuality = 100});
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

            // small delay
            await Task.Delay(TimeSpan.FromMilliseconds(100));
            DependencyService.Get<IImageCropperWrapper>().ShowFromFile(this, imageFile);

            // dispose media file
            file?.Dispose();
        }

        public byte[] GetBytes(string imageFile)
        {
            return DependencyService.Get<IImageCropperWrapper>().GetBytes(imageFile);
        }
    }
}

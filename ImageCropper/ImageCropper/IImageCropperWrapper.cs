using Plugin.Media.Abstractions;

namespace Stormlion.ImageCropper
{
    public interface IImageCropperWrapper
    {
        void ShowFromFile(ImageCropper imageCropper, string imageFile);
    }
}

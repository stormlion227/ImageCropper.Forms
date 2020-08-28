using System.Collections.Generic;

namespace Stormlion.ImageCropper
{
    public interface IImageCropperWrapper
    {
        void ShowFromFile(ImageCropper imageCropper, List<ImageProperties> imagesCroppingList);
    }
}
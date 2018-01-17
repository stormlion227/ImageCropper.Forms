using System;
using System.Collections.Generic;
using System.Text;

namespace Stormlion.ImageCropper
{
    public interface IImageCropper
    {
        void ShowImageCropper(ImageCropper.CroppingStyle croppingStyle, ImageCropper.AspectRatioPreset aspectRatioPreset);
    }
}

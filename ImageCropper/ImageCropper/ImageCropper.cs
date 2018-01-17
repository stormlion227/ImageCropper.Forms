using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Stormlion.ImageCropper
{
    public class ImageCropper
    {
        public enum CroppingStyle
        {
            Default,
            Circular
        }

        public enum AspectRatioPreset
        {
            Original,
            Square,
            AspectRatioPreset3x2,
            AspectRatioPreset5x3,
            AspectRatioPreset4x3,
            AspectRatioPreset5x4,
            AspectRatioPreset7x5,
            AspectRatioPreset16x9,
            Custom
        }

        public CroppingStyle Cropping { get; set; } = CroppingStyle.Default;

        public AspectRatioPreset AspectRatio { get; set; } = AspectRatioPreset.Original;

        public void Show()
        {
            IImageCropper i = DependencyService.Get<IImageCropper>();

            i.ShowImageCropper(Cropping, AspectRatio);
        }
    }
}

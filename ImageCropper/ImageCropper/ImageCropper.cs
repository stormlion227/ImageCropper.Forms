using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Stormlion.ImageCropper
{
    public class ImageCropper
    {
        public static void Show()
        {
            DependencyService.Get<IImageCropperWrapper>().Show();
        }
    }
}

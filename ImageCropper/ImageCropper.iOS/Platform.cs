
using Xamarin.Forms;

namespace Stormlion.ImageCropper.iOS
{
    public class Platform
    {
        public static void Init()
        {
            DependencyService.Register<ImageCropperImplementation>();
        }
    }
}
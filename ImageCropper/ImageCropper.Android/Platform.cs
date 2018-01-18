
using Xamarin.Forms;

namespace Stormlion.ImageCropper.Droid
{
    public class Platform
    {
        public static void Init()
        {
            DependencyService.Register<ImageCropperImplementation>();
        }
    }
}
using Bind_TOCropViewController;

using Foundation;
using Stormlion.ImageCropper;
using Stormlion.ImageCropper.iOS;
using System;
using System.Diagnostics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ImageCropperPage), typeof(ImageCropperRenderer))]
namespace Stormlion.ImageCropper.iOS
{
    public class ImageCropperRenderer : PageRenderer
    {
        byte[] Image;
        bool IsShown;
        public bool DidCrop;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            ImageCropperPage page = base.Element as ImageCropperPage;
            Image = page.Image;
            DidCrop = page.DidCrop;
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            try
            {
                if(!IsShown)
                {
                    IsShown = true;

                    UIImage image = new UIImage(NSData.FromArray(Image));
                    Image = null;

                    TOCropViewController picker = new TOCropViewController(image);
                    //picker.Delegate = this;

                    PresentViewController(picker, false, null);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            try
            {
                ImageCropperPage page = base.Element as ImageCropperPage;
                //page.DidCrop = selector.DidCrop;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
using Bind_TOCropViewController;
using CoreGraphics;
using Foundation;
using Plugin.Media.Abstractions;
using Stormlion.ImageCropper.iOS;
using System;
using System.Diagnostics;
using System.IO;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(ImageCropperImplementation))]
namespace Stormlion.ImageCropper.iOS
{
    public class ImageCropperImplementation : IImageCropperWrapper
    {
        protected static ImageCropperDelegate imageCropperDelegate = new ImageCropperDelegate();

        public void ShowFromFile(string imageFile)
        {
            UIImage image = UIImage.FromFile(imageFile);
            
            TOCropViewController cropViewController = new TOCropViewController(image);
            cropViewController.Delegate = imageCropperDelegate;

            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(cropViewController, true, null);
        }

    }

    public class ImageCropperDelegate : TOCropViewControllerDelegate
    {
        public override void DidCropToImage(TOCropViewController cropViewController, UIImage image, CGRect cropRect, nint angle)
        {
            Finalize(image);
        }

        public override void DidCropToCircularImage(TOCropViewController cropViewController, UIImage image, CGRect cropRect, nint angle)
        {
            Finalize(image);
        }

        public override void DidFinishCancelled(TOCropViewController cropViewController, bool cancelled)
        {
            ImageCropper.Current.Faiure?.Invoke();
            UIApplication.SharedApplication.KeyWindow.RootViewController.DismissViewController(true, null);
        }

        void Finalize(UIImage image)
        {
            string documentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string jpgFilename = System.IO.Path.Combine(documentsDirectory, Guid.NewGuid().ToString() + ".jpg");
            NSData imgData = image.AsJPEG();
            NSError err = null;
            if (imgData.Save(jpgFilename, false, out err))
            {
                Debug.WriteLine("saved as " + jpgFilename);
                ImageCropper.Current.Success?.Invoke(jpgFilename);
            }
            else
            {
                Debug.WriteLine("NOT saved as " + jpgFilename + " because" + err.LocalizedDescription);
                ImageCropper.Current.Faiure?.Invoke();
            }
            UIApplication.SharedApplication.KeyWindow.RootViewController.DismissViewController(true, null);
        }
    }
}
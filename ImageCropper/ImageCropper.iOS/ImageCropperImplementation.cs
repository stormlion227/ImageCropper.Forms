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
        public void ShowFromFile(string imageFile)
        {
            UIImage image = UIImage.FromFile(imageFile);

            TOCropViewController cropViewController;

            if(ImageCropper.Current.CropShape == ImageCropper.CropShapeType.Oval)
            {
                cropViewController = new TOCropViewController(TOCropViewCroppingStyle.Circular, image);
            }
            else
            {
                cropViewController = new TOCropViewController(image);
            }

            if(ImageCropper.Current.AspectRatioX > 0 && ImageCropper.Current.AspectRatioY > 0)
            {
                cropViewController.AspectRatioPreset = TOCropViewControllerAspectRatioPreset.Custom;
                cropViewController.CustomAspectRatio = new CGSize(ImageCropper.Current.AspectRatioX, ImageCropper.Current.AspectRatioY);
            }

            //cropViewController.Delegate = this;

            cropViewController.OnDidCropToRect = (outImage, cropRect, angle) =>
            {
                Finalize(outImage);
            };

            cropViewController.OnDidCropToCircleImage = (outImage, cropRect, angle) =>
            {
                Finalize(outImage);
            };

            cropViewController.OnDidFinishCancelled = (cancelled) =>
            {
                ImageCropper.Current.Faiure?.Invoke();
                UIApplication.SharedApplication.KeyWindow.RootViewController.DismissViewController(true, null);
            };

            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(cropViewController, true, null);

            if (!string.IsNullOrWhiteSpace(ImageCropper.Current.PageTitle) && cropViewController.TitleLabel != null)
            {
                UILabel titleLabel = cropViewController.TitleLabel;
                titleLabel.Text = ImageCropper.Current.PageTitle;
            }
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
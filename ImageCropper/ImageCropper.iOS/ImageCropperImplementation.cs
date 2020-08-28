using Bind_TOCropViewController;
using CoreGraphics;
using Foundation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using UIKit;

namespace Stormlion.ImageCropper.iOS
{
    public class ImageCropperImplementation : IImageCropperWrapper
    {
        public void ShowFromFile(ImageCropper imageCropper, List<ImageProperties> imagesCroppingList)
        {
            try
            {
                TOCropViewController cropViewController;

                var temporalList = imagesCroppingList;

                foreach (var imageFile in temporalList)
                {
                    UIImage image = UIImage.FromFile(imageFile.ImagePath);

                    cropViewController = imageCropper.CropShape == ImageCropper.CropShapeType.Oval ? new TOCropViewController(TOCropViewCroppingStyle.Circular, image) : new TOCropViewController(image);

                    if (imageCropper.AspectRatioX > 0 && imageCropper.AspectRatioY > 0)
                    {
                        cropViewController.AspectRatioPreset = TOCropViewControllerAspectRatioPreset.Custom;
                        cropViewController.ResetAspectRatioEnabled = false;
                        cropViewController.AspectRatioLockEnabled = true;
                        cropViewController.CustomAspectRatio = new CGSize(imageCropper.AspectRatioX, imageCropper.AspectRatioY);
                    }

                    cropViewController.ModalPresentationStyle = UIModalPresentationStyle.FullScreen;

                    cropViewController.OnDidCropToRect = (outImage, cropRect, angle) =>
                    {
                        int tempIndex = temporalList.FindIndex(x => x.ImagePath.Equals(imageFile.ImagePath) && x.OriginalPictureDate.Equals(imageFile.OriginalPictureDate));

                        temporalList.RemoveAt(tempIndex);

                        Finalize(imageCropper, outImage, imageFile.OriginalPictureDate, temporalList);
                        UIApplication.SharedApplication.KeyWindow.RootViewController.DismissViewController(true, null);

                        if (temporalList.Count > 0)
                            ShowFromFile(imageCropper, temporalList);

                        if (temporalList.Count == 0 && imageCropper.CroppingResultList.Count > 0)
                            FinishCroppingTask(imageCropper);
                    };

                    cropViewController.OnDidCropToCircleImage = (outImage, cropRect, angle) =>
                    {
                        Finalize(imageCropper, outImage, imageFile.OriginalPictureDate, temporalList);
                    };

                    cropViewController.OnDidFinishCancelled = (cancelled) =>
                    {
                        int tempIndex = temporalList.FindIndex(x => x.ImagePath.Equals(imageFile.ImagePath) && x.OriginalPictureDate.Equals(imageFile.OriginalPictureDate));

                        temporalList.RemoveAt(tempIndex);

                        UIApplication.SharedApplication.KeyWindow.RootViewController.DismissViewController(true, null);

                        if (temporalList.Count > 0)
                            ShowFromFile(imageCropper, temporalList);

                        if (temporalList.Count == 0 && imageCropper.CroppingResultList.Count > 0)
                            FinishCroppingTask(imageCropper);
                    };
                    UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(cropViewController, true, null);

                    if (!string.IsNullOrWhiteSpace(imageCropper.PageTitle) && cropViewController.TitleLabel != null)
                    {
                        UILabel titleLabel = cropViewController.TitleLabel;
                        titleLabel.Text = imageCropper.PageTitle;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static async void Finalize(ImageCropper imageCropper, UIImage image, string imageCreationDate, List<ImageProperties> imagePropertiesList)
        {
            string documentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string jpgFilename = System.IO.Path.Combine(documentsDirectory, Guid.NewGuid().ToString() + ".jpg");
            NSData imgData = image.AsJPEG();
            NSError err;

            imageCropper.CroppingResultList.Add(new ImageProperties()
            {
                ImagePath = jpgFilename,
                OriginalPictureDate = imageCreationDate
            });

            // small delay
            await System.Threading.Tasks.Task.Delay(TimeSpan.FromMilliseconds(100));

            if (!imgData.Save(jpgFilename, false, out err))
            {
                Debug.WriteLine("NOT saved as " + jpgFilename + " because" + err.LocalizedDescription);
                imageCropper.Faiure?.Invoke();
            }
            UIApplication.SharedApplication.KeyWindow.RootViewController.DismissViewController(true, null);
        }

        private static async void FinishCroppingTask(ImageCropper imageCropper)
        {
            // small delay
            await System.Threading.Tasks.Task.Delay(TimeSpan.FromMilliseconds(100));

            imageCropper.Success?.Invoke(imageCropper.CroppingResultList);
        }
    }
}
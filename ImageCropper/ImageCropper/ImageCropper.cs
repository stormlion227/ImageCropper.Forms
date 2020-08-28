using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Stormlion.ImageCropper
{
    public class ImageCropper
    {
        public static ImageCropper Current { get; set; }

        public ImageCropper()
        {
            Current = this;
        }

        public enum CropShapeType
        {
            Rectangle,
            Oval
        };

        public CropShapeType CropShape { get; set; } = CropShapeType.Rectangle;

        public int AspectRatioX { get; set; } = 0;

        public int AspectRatioY { get; set; } = 0;

        public string PageTitle { get; set; } = null;

        public string SelectSourceTitle { get; set; } = "Select source";

        public string TakePhotoTitle { get; set; } = "Camera";

        public string PhotoLibraryTitle { get; set; } = "Gallery";

        public string CancelButtonTitle { get; set; } = "Cancel";

        public string originalPicDate { get; set; }

        public int indexCounter { get; set; } = 0;

        public List<ImageProperties> BeforeCroppingList;

        public List<ImageProperties> CroppingResultList { get; set; } = new List<ImageProperties>();

        /// <summary>
        /// T1: List of Image cropped paths and Original Image Source Date of Creation.
        /// </summary>
        public Action<IList<ImageProperties>> Success { get; set; }

        public Action Faiure { get; set; }

        public PickMediaOptions PickMediaOptions { get; set; } = new PickMediaOptions
        {
            PhotoSize = PhotoSize.Large,
        };

        public StoreCameraMediaOptions StoreCameraMediaOptions { get; set; } = new StoreCameraMediaOptions();

        public async void Show(Page page, List<string> imageFiles = null)
        {
            try
            {
                if (imageFiles == null)
                {
                    await CrossMedia.Current.Initialize();

                    MediaFile file;
                    List<MediaFile> files = null;

                    CroppingResultList.Clear();

                    string action = await page.DisplayActionSheet(SelectSourceTitle, CancelButtonTitle, null, TakePhotoTitle, PhotoLibraryTitle);
                    if (action == TakePhotoTitle)
                    {
                        if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                        {
                            await page.DisplayAlert("Error", "This device does not have camera available.", "OK");
                            Faiure?.Invoke();
                            return;
                        }

                        file = await CrossMedia.Current.TakePhotoAsync(StoreCameraMediaOptions);

                        if (file != null)
                        {
                            files = new List<MediaFile>();

                            files.Add(file);

                            BeforeCroppingList = new List<ImageProperties>();

                            BeforeCroppingList.Add(new ImageProperties()
                            {
                                ImagePath = file.Path,
                                OriginalPictureDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
                            });
                        }
                        else
                        {
                            Faiure?.Invoke();
                            return;
                        }
                    }
                    else if (action == PhotoLibraryTitle)
                    {
                        try
                        {
                            if (!CrossMedia.Current.IsPickPhotoSupported)
                            {
                                await page.DisplayAlert("Error", "This device is not supported to pick photo.", "OK");
                                Faiure?.Invoke();
                                return;
                            }

                            PickMediaOptions.SaveMetaData = true;

                            files = await CrossMedia.Current.PickPhotosAsync(PickMediaOptions);

                            if (files.Count > 0)
                            {
                                BeforeCroppingList = new List<ImageProperties>();

                                foreach (var item in files)
                                {
                                    Stream currentStream = item.GetStream();
                                    var currentPictureData = ExifLib.ExifReader.ReadJpeg(currentStream);
                                    string CurrentPictureDate = currentPictureData.DateTimeOriginal;
                                    originalPicDate = String.Empty;

                                    if (CurrentPictureDate != null)
                                    {
                                        string pictureDate = CurrentPictureDate.
                                        Substring(startIndex: 0, 10).Replace(":", "/");
                                        string pictureTime = CurrentPictureDate.Substring(startIndex: 11);
                                        originalPicDate = $"{pictureDate} {pictureTime}";
                                    }
                                    else
                                    {
                                        originalPicDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                                    }

                                    BeforeCroppingList.Add(new ImageProperties()
                                    {
                                        ImagePath = item.Path,
                                        OriginalPictureDate = originalPicDate
                                    });
                                }
                            }
                            else
                            {
                                Faiure?.Invoke();
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                            files = null;
                        }
                    }
                    else
                    {
                        Faiure?.Invoke();
                        return;
                    }

                    if (files == null)
                    {
                        Faiure?.Invoke();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            // small delay
            await Task.Delay(TimeSpan.FromMilliseconds(100));
            DependencyService.Get<IImageCropperWrapper>().ShowFromFile(this, BeforeCroppingList);
        }
    }

    public class ImageProperties
    {
        public string ImagePath { get; set; }
        public string OriginalPictureDate { get; set; }
    }

}
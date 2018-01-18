using Com.Theartofdev.Edmodo.Cropper;

using System.Linq;
using Android.Content;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;
using System.IO;
using Stormlion.ImageCropper.Droid;
using Stormlion.ImageCropper;

[assembly: ExportRenderer(typeof(ImageCropperPage), typeof(ImageCropperPageRenderer))]
namespace Stormlion.ImageCropper.Droid
{
    public class ImageCropperPageRenderer : PageRenderer
    {
        public ImageCropperPageRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            //Com.Theartofdev.Edmodo.Cropper. v = new CropOverlayView(Context);

            ImageCropperPage page = Element as ImageCropperPage;
            if(page != null)
            {
                var cropImageView = new CropImageView(Context);
                cropImageView.LayoutParameters = new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
                Bitmap bitmp = BitmapFactory.DecodeByteArray(page.Image, 0, page.Image.Length);
                cropImageView.SetImageBitmap(bitmp);

                var stackLayout = new StackLayout { Children = { cropImageView } };

                var rotateButton = new Xamarin.Forms.Button { Text = "Rotate" };

                rotateButton.Clicked += (sender, ex) =>
                {
                    cropImageView.RotateImage(90);
                };
                stackLayout.Children.Add(rotateButton);

                /*

                var finishButton = new Xamarin.Forms.Button { Text = "Finished" };
                finishButton.Clicked += (sender, ex) =>
                {
                    Bitmap cropped = cropImageView.CroppedImage;
                    using (MemoryStream memory = new MemoryStream())
                    {
                        cropped.Compress(Bitmap.CompressFormat.Png, 100, memory);
                        App.CroppedImage = memory.ToArray();
                    }
                    page.DidCrop = true;
                    page.Navigation.PopModalAsync();
                };

                stackLayout.Children.Add(finishButton);
                */

                page.Content = stackLayout;
            }

        }
    }
}
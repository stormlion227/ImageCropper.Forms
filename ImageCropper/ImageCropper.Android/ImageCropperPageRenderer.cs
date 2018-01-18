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
        CropImageView cropView;

        public ImageCropperPageRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            ImageCropperPage page = Element as ImageCropperPage;
            if (page != null)
            {


                cropView = new CropImageView(Context);

                cropView.LayoutParameters = new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);

                Bitmap bitmp = BitmapFactory.DecodeByteArray(page.Image, 0, page.Image.Length);

                cropView.SetImageBitmap(bitmp);

                AddView(cropView);

                /*

                Grid grid = new Grid();

                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });

                //var stackLayout = new StackLayout { Children = { cropImageView }};
                grid.Children.Add(cropImageView, 0, 0);
                
                var rotateButton = new Xamarin.Forms.Button { Text = "Rotate" };

                rotateButton.VerticalOptions = LayoutOptions.End;

                rotateButton.Clicked += (sender, ex) =>
                {
                    cropImageView.RotateImage(90);
                };
                //stackLayout.Children.Add(rotateButton);
                grid.Children.Add(rotateButton, 0, 1);

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

                page.Content = grid;
                */
            }
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);

            var msw = MeasureSpec.MakeMeasureSpec(r - l, MeasureSpecMode.Exactly);
            var msh = MeasureSpec.MakeMeasureSpec(b - t, MeasureSpecMode.Exactly);
            cropView.Measure(msw, msh);
            cropView.Layout(0, 0, r - l, b - t);
        }

    }
}

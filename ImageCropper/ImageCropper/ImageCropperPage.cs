using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Stormlion.ImageCropper
{
	public class ImageCropperPage : ContentPage
	{
        public byte[] Image;
        public Action RefreshAction;
        public bool DidCrop = false;

		public ImageCropperPage (byte[] imageAsByte, Action refreshAction)
		{
            NavigationPage.SetHasNavigationBar(this, false);
            BackgroundColor = Color.Black;
            Image = imageAsByte;

            RefreshAction = refreshAction;
		}

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            if(DidCrop)
            {
                RefreshAction.Invoke();
            }
        }
    }
}
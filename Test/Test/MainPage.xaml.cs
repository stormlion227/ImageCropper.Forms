using Stormlion.ImageCropper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Test
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        protected void OnClickedShow(object sender, EventArgs e)
        {
            new ImageCropper()
            {
                Cropping = ImageCropper.CroppingStyle.Circular
            }.Show();
        }

    }
}

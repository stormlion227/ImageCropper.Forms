# ImageCropper.Forms

Xamarin.Forms(.Net Standard) library that allows you to crop and rotate image/photo.

[![NuGet](https://img.shields.io/nuget/v/ImageCropper.Forms.svg)](https://www.nuget.org/packages/ImageCropper.Forms/)

Supports Android, iOS.
* Android library from : https://github.com/ArthurHub/Android-Image-Cropper
* iOS library from : https://github.com/TimOliver/TOCropViewController

## Features

* Cropping image.
* Rotating image.
* Aspect ratio.
* Circle/Rectangle shape.

## Support Platforms

* iOS 8+
* Android

## Screen-Shots

<img src="ScreenShots/IMG_0001.png"/>

## Usage

* Install [Xamarin.Android.Support.Exif (>=26.0.2)](https://www.nuget.org/packages/Xamarin.Android.Support.Exif/) in Android project.
* Install the [nuget package](https://www.nuget.org/packages/ShapeControl.Forms/) in portable and all platform specific projects.
* This plugin uses the [MediaPlugin](https://github.com/jamesmontemagno/MediaPlugin/blob/master/README.md). Be sure to complete the full setup this plugin. Please fully read through the [Current Activity Plugin Documentation](https://github.com/jamesmontemagno/MediaPlugin/blob/master/README.md).

#### Android

In MainActivity.cs file

```
	Stormlion.ImageCropper.Droid.Platform.Init();

	global::Xamarin.Forms.Forms.Init(this, bundle);
```
```
    protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
    {
        base.OnActivityResult(requestCode, resultCode, data);

        Stormlion.ImageCropper.Droid.Platform.OnActivityResult(requestCode, resultCode, data);
    }
```

#### iOS

In AppDelegate.cs file

```
	Stormlion.ImageCropper.iOS.Platform.Init();
```

#### Show ImageCropper page.
```
    new ImageCropper()
    {
        Success = (imageFile) =>
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                imageView.Source = ImageSource.FromFile(imageFile);
            });
        }
    }.Show(this);
```

#### Properties

* PageTitle
* AspectRatioX
* AspectRatioY
* CropShape
* Initial image can be set in Show function.

## Contributions

Contributions are welcome!

If you find a bug want a feature added please report it to [facebook](https://www.facebook.com/ShapeControlForms-158408391455712/).

If you want to contribute code please file an issue, create a branch, and file a pull request.

### Contributors

* **[Marko Rothstein](https://www.facebook.com/profile.php?id=100014026622428)**

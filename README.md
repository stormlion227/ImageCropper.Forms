# ImageCropper.Forms

Xamarin.Forms plugin to crop and rotate photos.

[![NuGet](https://img.shields.io/nuget/v/ImageCropper.Forms.svg)](https://www.nuget.org/packages/ImageCropper.Forms/)

Supports Android and iOS.
* Android library from : https://github.com/ArthurHub/Android-Image-Cropper
* iOS library from : https://github.com/TimOliver/TOCropViewController

## Features

* Cropping image.
* Rotating image.
* Aspect ratio.
* Circle/Rectangle shape.

## Screen-Shots

### Android
<img src="ScreenShots/Android_Rectangle.gif" alt="Crop/Rotate image(Rectangle/Android)"/> <img src="ScreenShots/Android_Circle.gif" alt="Crop/Rotate image(Circle/Android)"/>

### iOS
<img src="ScreenShots/iOS_Rectangle.gif" alt="Crop/Rotate image(Rectangle/iOS)"/> <img src="ScreenShots/iOS_Circle.gif" alt="Crop/Rotate image(Circle/iOS)" />

## Setup

* Install [Xamarin.Android.Support.Exif (>=26.0.2)](https://www.nuget.org/packages/Xamarin.Android.Support.Exif/) in Android project. (I've tried to add this to dependency package in .nuspec file, but I had some trouble. If you have experience with this, please contribute.)
* Install the [nuget package](https://www.nuget.org/packages/ShapeControl.Forms/) in portable and all platform specific projects.
* This plugin uses the [MediaPlugin](https://github.com/jamesmontemagno/MediaPlugin/blob/master/README.md). Be sure to complete the full setup this plugin. Please fully read through the [MediaPlugin description](https://github.com/jamesmontemagno/MediaPlugin/blob/master/README.md).

### Android

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

### iOS

In AppDelegate.cs file

```
	Stormlion.ImageCropper.iOS.Platform.Init();
```
## Usage

### Show ImageCropper page.
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
### Show it with additional parameters.
```
    new ImageCropper()
    {
        PageTitle = "Test Title",
        AspectRatioX = 1,
        AspectRatioY = 1,
	CropShape = ImageCropper.CropShapeType.Oval,
        Success = (imageFile) =>
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                imageView.Source = ImageSource.FromFile(imageFile);
            });
        }
    }.Show(this);
```
### Show it with a image
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
    }.Show(this, imageFileName);
```
### Properties
* PageTitle
* AspectRatioX
* AspectRatioY
* CropShape
* Initial image can be set in Show function.

## Contributions
Contributions are welcome!

## Contributors
* **[Marko Rothstein](https://www.facebook.com/profile.php?id=100014026622428)**

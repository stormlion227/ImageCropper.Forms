using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using Bind_TOCropViewController;
using UIKit;

namespace Bind_TOCropViewController
{
    // @interface TOActivityCroppedImageProvider : UIActivityItemProvider
    [BaseType(typeof(UIActivityItemProvider))]
    interface TOActivityCroppedImageProvider
    {
        // @property (readonly, nonatomic) UIImage * _Nonnull image;
        [Export("image")]
        UIImage Image { get; }

        // @property (readonly, nonatomic) CGRect cropFrame;
        [Export("cropFrame")]
        CGRect CropFrame { get; }

        // @property (readonly, nonatomic) NSInteger angle;
        [Export("angle")]
        nint Angle { get; }

        // @property (readonly, nonatomic) BOOL circular;
        [Export("circular")]
        bool Circular { get; }

        // -(instancetype _Nonnull)initWithImage:(UIImage * _Nonnull)image cropFrame:(CGRect)cropFrame angle:(NSInteger)angle circular:(BOOL)circular;
        [Export("initWithImage:cropFrame:angle:circular:")]
        IntPtr Constructor(UIImage image, CGRect cropFrame, nint angle, bool circular);
    }

    // @interface TOCroppedImageAttributes : NSObject
    [BaseType(typeof(NSObject))]
    interface TOCroppedImageAttributes
    {
        // @property (readonly, nonatomic) NSInteger angle;
        [Export("angle")]
        nint Angle { get; }

        // @property (readonly, nonatomic) CGRect croppedFrame;
        [Export("croppedFrame")]
        CGRect CroppedFrame { get; }

        // @property (readonly, nonatomic) CGSize originalImageSize;
        [Export("originalImageSize")]
        CGSize OriginalImageSize { get; }

        // -(instancetype)initWithCroppedFrame:(CGRect)croppedFrame angle:(NSInteger)angle originalImageSize:(CGSize)originalSize;
        [Export("initWithCroppedFrame:angle:originalImageSize:")]
        IntPtr Constructor(CGRect croppedFrame, nint angle, CGSize originalSize);
    }

    // @interface TOCropViewControllerTransitioning : NSObject <UIViewControllerAnimatedTransitioning>
    [BaseType(typeof(NSObject))]
    interface TOCropViewControllerTransitioning : IUIViewControllerAnimatedTransitioning
    {
        // @property (assign, nonatomic) BOOL isDismissing;
        [Export("isDismissing")]
        bool IsDismissing { get; set; }

        // @property (nonatomic, strong) UIImage * _Nullable image;
        [NullAllowed, Export("image", ArgumentSemantic.Strong)]
        UIImage Image { get; set; }

        // @property (nonatomic, strong) UIView * _Nullable fromView;
        [NullAllowed, Export("fromView", ArgumentSemantic.Strong)]
        UIView FromView { get; set; }

        // @property (nonatomic, strong) UIView * _Nullable toView;
        [NullAllowed, Export("toView", ArgumentSemantic.Strong)]
        UIView ToView { get; set; }

        // @property (assign, nonatomic) CGRect fromFrame;
        [Export("fromFrame", ArgumentSemantic.Assign)]
        CGRect FromFrame { get; set; }

        // @property (assign, nonatomic) CGRect toFrame;
        [Export("toFrame", ArgumentSemantic.Assign)]
        CGRect ToFrame { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(void) prepareForTransitionHandler;
        [NullAllowed, Export("prepareForTransitionHandler", ArgumentSemantic.Copy)]
        Action PrepareForTransitionHandler { get; set; }

        // -(void)reset;
        [Export("reset")]
        void Reset();
    }

    // @interface CropRotate (UIImage)
    [Category]
    [BaseType(typeof(UIImage))]
    interface UIImage_CropRotate
    {
        // -(UIImage * _Nonnull)croppedImageWithFrame:(CGRect)frame angle:(NSInteger)angle circularClip:(BOOL)circular;
        [Export("croppedImageWithFrame:angle:circularClip:")]
        UIImage CroppedImageWithFrame(CGRect frame, nint angle, bool circular);
    }

    // @protocol TOCropViewDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface TOCropViewDelegate
    {
        // @required -(void)cropViewDidBecomeResettable:(TOCropView * _Nonnull)cropView;
        [Abstract]
        [Export("cropViewDidBecomeResettable:")]
        void CropViewDidBecomeResettable(TOCropView cropView);

        // @required -(void)cropViewDidBecomeNonResettable:(TOCropView * _Nonnull)cropView;
        [Abstract]
        [Export("cropViewDidBecomeNonResettable:")]
        void CropViewDidBecomeNonResettable(TOCropView cropView);
    }

    // @interface TOCropView : UIView
    [BaseType(typeof(UIView))]
    interface TOCropView
    {
        // @property (readonly, nonatomic, strong) UIImage * _Nonnull image;
        [Export("image", ArgumentSemantic.Strong)]
        UIImage Image { get; }

        // @property (readonly, assign, nonatomic) TOCropViewCroppingStyle croppingStyle;
        [Export("croppingStyle", ArgumentSemantic.Assign)]
        TOCropViewCroppingStyle CroppingStyle { get; }

        // @property (readonly, nonatomic, strong) TOCropOverlayView * _Nonnull gridOverlayView;
        [Export("gridOverlayView", ArgumentSemantic.Strong)]
        TOCropOverlayView GridOverlayView { get; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        TOCropViewDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<TOCropViewDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (assign, nonatomic) BOOL cropBoxResizeEnabled;
        [Export("cropBoxResizeEnabled")]
        bool CropBoxResizeEnabled { get; set; }

        // @property (readonly, nonatomic) BOOL canBeReset;
        [Export("canBeReset")]
        bool CanBeReset { get; }

        // @property (readonly, nonatomic) CGRect cropBoxFrame;
        [Export("cropBoxFrame")]
        CGRect CropBoxFrame { get; }

        // @property (readonly, nonatomic) CGRect imageViewFrame;
        [Export("imageViewFrame")]
        CGRect ImageViewFrame { get; }

        // @property (assign, nonatomic) UIEdgeInsets cropRegionInsets;
        [Export("cropRegionInsets", ArgumentSemantic.Assign)]
        UIEdgeInsets CropRegionInsets { get; set; }

        // @property (assign, nonatomic) BOOL simpleRenderMode;
        [Export("simpleRenderMode")]
        bool SimpleRenderMode { get; set; }

        // @property (assign, nonatomic) BOOL internalLayoutDisabled;
        [Export("internalLayoutDisabled")]
        bool InternalLayoutDisabled { get; set; }

        // @property (assign, nonatomic) CGSize aspectRatio;
        [Export("aspectRatio", ArgumentSemantic.Assign)]
        CGSize AspectRatio { get; set; }

        // @property (assign, nonatomic) BOOL aspectRatioLockEnabled;
        [Export("aspectRatioLockEnabled")]
        bool AspectRatioLockEnabled { get; set; }

        // @property (assign, nonatomic) BOOL resetAspectRatioEnabled;
        [Export("resetAspectRatioEnabled")]
        bool ResetAspectRatioEnabled { get; set; }

        // @property (readonly, nonatomic) BOOL cropBoxAspectRatioIsPortrait;
        [Export("cropBoxAspectRatioIsPortrait")]
        bool CropBoxAspectRatioIsPortrait { get; }

        // @property (assign, nonatomic) NSInteger angle;
        [Export("angle")]
        nint Angle { get; set; }

        // @property (assign, nonatomic) BOOL croppingViewsHidden;
        [Export("croppingViewsHidden")]
        bool CroppingViewsHidden { get; set; }

        // @property (assign, nonatomic) CGRect imageCropFrame;
        [Export("imageCropFrame", ArgumentSemantic.Assign)]
        CGRect ImageCropFrame { get; set; }

        // @property (assign, nonatomic) BOOL gridOverlayHidden;
        [Export("gridOverlayHidden")]
        bool GridOverlayHidden { get; set; }

        // -(instancetype _Nonnull)initWithImage:(UIImage * _Nonnull)image;
        [Export("initWithImage:")]
        IntPtr Constructor(UIImage image);

        // -(instancetype _Nonnull)initWithCroppingStyle:(TOCropViewCroppingStyle)style image:(UIImage * _Nonnull)image;
        [Export("initWithCroppingStyle:image:")]
        IntPtr Constructor(TOCropViewCroppingStyle style, UIImage image);

        // -(void)performInitialSetup;
        [Export("performInitialSetup")]
        void PerformInitialSetup();

        // -(void)setSimpleRenderMode:(BOOL)simpleMode animated:(BOOL)animated;
        [Export("setSimpleRenderMode:animated:")]
        void SetSimpleRenderMode(bool simpleMode, bool animated);

        // -(void)prepareforRotation;
        [Export("prepareforRotation")]
        void PrepareforRotation();

        // -(void)performRelayoutForRotation;
        [Export("performRelayoutForRotation")]
        void PerformRelayoutForRotation();

        // -(void)resetLayoutToDefaultAnimated:(BOOL)animated;
        [Export("resetLayoutToDefaultAnimated:")]
        void ResetLayoutToDefaultAnimated(bool animated);

        // -(void)setAspectRatio:(CGSize)aspectRatio animated:(BOOL)animated;
        [Export("setAspectRatio:animated:")]
        void SetAspectRatio(CGSize aspectRatio, bool animated);

        // -(void)rotateImageNinetyDegreesAnimated:(BOOL)animated;
        [Export("rotateImageNinetyDegreesAnimated:")]
        void RotateImageNinetyDegreesAnimated(bool animated);

        // -(void)rotateImageNinetyDegreesAnimated:(BOOL)animated clockwise:(BOOL)clockwise;
        [Export("rotateImageNinetyDegreesAnimated:clockwise:")]
        void RotateImageNinetyDegreesAnimated(bool animated, bool clockwise);

        // -(void)setGridOverlayHidden:(BOOL)gridOverlayHidden animated:(BOOL)animated;
        [Export("setGridOverlayHidden:animated:")]
        void SetGridOverlayHidden(bool gridOverlayHidden, bool animated);

        // -(void)setCroppingViewsHidden:(BOOL)hidden animated:(BOOL)animated;
        [Export("setCroppingViewsHidden:animated:")]
        void SetCroppingViewsHidden(bool hidden, bool animated);

        // -(void)setBackgroundImageViewHidden:(BOOL)hidden animated:(BOOL)animated;
        [Export("setBackgroundImageViewHidden:animated:")]
        void SetBackgroundImageViewHidden(bool hidden, bool animated);

        // -(void)moveCroppedContentToCenterAnimated:(BOOL)animated;
        [Export("moveCroppedContentToCenterAnimated:")]
        void MoveCroppedContentToCenterAnimated(bool animated);
    }

    // @interface TOCropToolbar : UIView
    [BaseType(typeof(UIView))]
    interface TOCropToolbar
    {
        // @property (assign, nonatomic) CGFloat statusBarHeightInset;
        [Export("statusBarHeightInset")]
        nfloat StatusBarHeightInset { get; set; }

        // @property (assign, nonatomic) UIEdgeInsets backgroundViewOutsets;
        [Export("backgroundViewOutsets", ArgumentSemantic.Assign)]
        UIEdgeInsets BackgroundViewOutsets { get; set; }

        // @property (readonly, nonatomic, strong) UIButton * _Nonnull doneTextButton;
        [Export("doneTextButton", ArgumentSemantic.Strong)]
        UIButton DoneTextButton { get; }

        // @property (readonly, nonatomic, strong) UIButton * _Nonnull doneIconButton;
        [Export("doneIconButton", ArgumentSemantic.Strong)]
        UIButton DoneIconButton { get; }

        // @property (copy, nonatomic) NSString * _Nonnull doneTextButtonTitle;
        [Export("doneTextButtonTitle")]
        string DoneTextButtonTitle { get; set; }

        // @property (readonly, nonatomic, strong) UIButton * _Nonnull cancelTextButton;
        [Export("cancelTextButton", ArgumentSemantic.Strong)]
        UIButton CancelTextButton { get; }

        // @property (readonly, nonatomic, strong) UIButton * _Nonnull cancelIconButton;
        [Export("cancelIconButton", ArgumentSemantic.Strong)]
        UIButton CancelIconButton { get; }

        // @property (copy, nonatomic) NSString * _Nonnull cancelTextButtonTitle;
        [Export("cancelTextButtonTitle")]
        string CancelTextButtonTitle { get; set; }

        // @property (readonly, nonatomic, strong) UIButton * _Nonnull rotateCounterclockwiseButton;
        [Export("rotateCounterclockwiseButton", ArgumentSemantic.Strong)]
        UIButton RotateCounterclockwiseButton { get; }

        // @property (readonly, nonatomic, strong) UIButton * _Nonnull resetButton;
        [Export("resetButton", ArgumentSemantic.Strong)]
        UIButton ResetButton { get; }

        // @property (readonly, nonatomic, strong) UIButton * _Nonnull clampButton;
        [Export("clampButton", ArgumentSemantic.Strong)]
        UIButton ClampButton { get; }

        // @property (readonly, nonatomic, strong) UIButton * _Nullable rotateClockwiseButton;
        [NullAllowed, Export("rotateClockwiseButton", ArgumentSemantic.Strong)]
        UIButton RotateClockwiseButton { get; }

        // @property (readonly, nonatomic) UIButton * _Nonnull rotateButton;
        [Export("rotateButton")]
        UIButton RotateButton { get; }

        // @property (copy, nonatomic) void (^ _Nullable)(void) cancelButtonTapped;
        [NullAllowed, Export("cancelButtonTapped", ArgumentSemantic.Copy)]
        Action CancelButtonTapped { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(void) doneButtonTapped;
        [NullAllowed, Export("doneButtonTapped", ArgumentSemantic.Copy)]
        Action DoneButtonTapped { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(void) rotateCounterclockwiseButtonTapped;
        [NullAllowed, Export("rotateCounterclockwiseButtonTapped", ArgumentSemantic.Copy)]
        Action RotateCounterclockwiseButtonTapped { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(void) rotateClockwiseButtonTapped;
        [NullAllowed, Export("rotateClockwiseButtonTapped", ArgumentSemantic.Copy)]
        Action RotateClockwiseButtonTapped { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(void) clampButtonTapped;
        [NullAllowed, Export("clampButtonTapped", ArgumentSemantic.Copy)]
        Action ClampButtonTapped { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(void) resetButtonTapped;
        [NullAllowed, Export("resetButtonTapped", ArgumentSemantic.Copy)]
        Action ResetButtonTapped { get; set; }

        // @property (assign, nonatomic) BOOL clampButtonGlowing;
        [Export("clampButtonGlowing")]
        bool ClampButtonGlowing { get; set; }

        // @property (readonly, nonatomic) CGRect clampButtonFrame;
        [Export("clampButtonFrame")]
        CGRect ClampButtonFrame { get; }

        // @property (assign, nonatomic) BOOL clampButtonHidden;
        [Export("clampButtonHidden")]
        bool ClampButtonHidden { get; set; }

        // @property (assign, nonatomic) BOOL rotateCounterclockwiseButtonHidden;
        [Export("rotateCounterclockwiseButtonHidden")]
        bool RotateCounterclockwiseButtonHidden { get; set; }

        // @property (assign, nonatomic) BOOL rotateClockwiseButtonHidden;
        [Export("rotateClockwiseButtonHidden")]
        bool RotateClockwiseButtonHidden { get; set; }

        // @property (assign, nonatomic) BOOL resetButtonEnabled;
        [Export("resetButtonEnabled")]
        bool ResetButtonEnabled { get; set; }

        // @property (readonly, nonatomic) CGRect doneButtonFrame;
        [Export("doneButtonFrame")]
        CGRect DoneButtonFrame { get; }
    }

    // @protocol TOCropViewControllerDelegate <NSObject>
    [Model]
    [BaseType(typeof(NSObject))]
    interface TOCropViewControllerDelegate
    {
        // @optional -(void)cropViewController:(TOCropViewController * _Nonnull)cropViewController didCropImageToRect:(CGRect)cropRect angle:(NSInteger)angle;
        [Export("cropViewController:didCropImageToRect:angle:")]
        void DidCropImageToRect(TOCropViewController cropViewController, CGRect cropRect, nint angle);

        // @optional -(void)cropViewController:(TOCropViewController * _Nonnull)cropViewController didCropToImage:(UIImage * _Nonnull)image withRect:(CGRect)cropRect angle:(NSInteger)angle;
        [Export("cropViewController:didCropToImage:withRect:angle:")]
        void DidCropToImage(TOCropViewController cropViewController, UIImage image, CGRect cropRect, nint angle);

        // @optional -(void)cropViewController:(TOCropViewController * _Nonnull)cropViewController didCropToCircularImage:(UIImage * _Nonnull)image withRect:(CGRect)cropRect angle:(NSInteger)angle;
        [Export("cropViewController:didCropToCircularImage:withRect:angle:")]
        void DidCropToCircularImage(TOCropViewController cropViewController, UIImage image, CGRect cropRect, nint angle);

        // @optional -(void)cropViewController:(TOCropViewController * _Nonnull)cropViewController didFinishCancelled:(BOOL)cancelled;
        [Export("cropViewController:didFinishCancelled:")]
        void DidFinishCancelled(TOCropViewController cropViewController, bool cancelled);
    }

    // @interface TOCropViewController : UIViewController
    [BaseType(typeof(UIViewController))]
    interface TOCropViewController
    {
        // @property (readonly, nonatomic) UIImage * _Nonnull image;
        [Export("image")]
        UIImage Image { get; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        TOCropViewControllerDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<TOCropViewControllerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (assign, nonatomic) BOOL showActivitySheetOnDone;
        [Export("showActivitySheetOnDone")]
        bool ShowActivitySheetOnDone { get; set; }

        // @property (readonly, nonatomic, strong) TOCropView * _Nonnull cropView;
        [Export("cropView", ArgumentSemantic.Strong)]
        TOCropView CropView { get; }

        // @property (assign, nonatomic) CGRect imageCropFrame;
        [Export("imageCropFrame", ArgumentSemantic.Assign)]
        CGRect ImageCropFrame { get; set; }

        // @property (assign, nonatomic) NSInteger angle;
        [Export("angle")]
        nint Angle { get; set; }

        // @property (readonly, nonatomic, strong) TOCropToolbar * _Nonnull toolbar;
        [Export("toolbar", ArgumentSemantic.Strong)]
        TOCropToolbar Toolbar { get; }

        // @property (readonly, nonatomic) TOCropViewCroppingStyle croppingStyle;
        [Export("croppingStyle")]
        TOCropViewCroppingStyle CroppingStyle { get; }

        // @property (assign, nonatomic) TOCropViewControllerAspectRatioPreset aspectRatioPreset;
        [Export("aspectRatioPreset", ArgumentSemantic.Assign)]
        TOCropViewControllerAspectRatioPreset AspectRatioPreset { get; set; }

        // @property (assign, nonatomic) CGSize customAspectRatio;
        [Export("customAspectRatio", ArgumentSemantic.Assign)]
        CGSize CustomAspectRatio { get; set; }

        // @property (readonly, nonatomic) UILabel * _Nullable titleLabel;
        [NullAllowed, Export("titleLabel")]
        UILabel TitleLabel { get; }

        // @property (copy, nonatomic) NSString * _Nullable doneButtonTitle;
        [NullAllowed, Export("doneButtonTitle")]
        string DoneButtonTitle { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable cancelButtonTitle;
        [NullAllowed, Export("cancelButtonTitle")]
        string CancelButtonTitle { get; set; }

        // @property (assign, nonatomic) BOOL aspectRatioLockDimensionSwapEnabled;
        [Export("aspectRatioLockDimensionSwapEnabled")]
        bool AspectRatioLockDimensionSwapEnabled { get; set; }

        // @property (assign, nonatomic) BOOL aspectRatioLockEnabled;
        [Export("aspectRatioLockEnabled")]
        bool AspectRatioLockEnabled { get; set; }

        // @property (assign, nonatomic) BOOL resetAspectRatioEnabled;
        [Export("resetAspectRatioEnabled")]
        bool ResetAspectRatioEnabled { get; set; }

        // @property (assign, nonatomic) TOCropViewControllerToolbarPosition toolbarPosition;
        [Export("toolbarPosition", ArgumentSemantic.Assign)]
        TOCropViewControllerToolbarPosition ToolbarPosition { get; set; }

        // @property (assign, nonatomic) BOOL rotateClockwiseButtonHidden;
        [Export("rotateClockwiseButtonHidden")]
        bool RotateClockwiseButtonHidden { get; set; }

        // @property (assign, nonatomic) BOOL rotateButtonsHidden;
        [Export("rotateButtonsHidden")]
        bool RotateButtonsHidden { get; set; }

        // @property (assign, nonatomic) BOOL aspectRatioPickerButtonHidden;
        [Export("aspectRatioPickerButtonHidden")]
        bool AspectRatioPickerButtonHidden { get; set; }

        // @property (nonatomic, strong) NSArray * _Nullable activityItems;
        [NullAllowed, Export("activityItems", ArgumentSemantic.Strong)]
        //[Verify(StronglyTypedNSArray)]
        NSObject[] ActivityItems { get; set; }

        // @property (nonatomic, strong) NSArray<UIActivity *> * _Nullable applicationActivities;
        [NullAllowed, Export("applicationActivities", ArgumentSemantic.Strong)]
        UIActivity[] ApplicationActivities { get; set; }

        // @property (nonatomic, strong) NSArray<UIActivityType> * _Nullable excludedActivityTypes;
        [NullAllowed, Export("excludedActivityTypes", ArgumentSemantic.Strong)]
        string[] ExcludedActivityTypes { get; set; }

        // @property (nonatomic, strong) void (^ _Nullable)(BOOL) onDidFinishCancelled;
        [NullAllowed, Export("onDidFinishCancelled", ArgumentSemantic.Strong)]
        Action<bool> OnDidFinishCancelled { get; set; }

        // @property (nonatomic, strong) void (^ _Nullable)(CGRect, NSInteger) onDidCropImageToRect;
        [NullAllowed, Export("onDidCropImageToRect", ArgumentSemantic.Strong)]
        Action<CGRect, nint> OnDidCropImageToRect { get; set; }

        // @property (nonatomic, strong) void (^ _Nullable)(UIImage * _Nonnull, CGRect, NSInteger) onDidCropToRect;
        [NullAllowed, Export("onDidCropToRect", ArgumentSemantic.Strong)]
        Action<UIImage, CGRect, nint> OnDidCropToRect { get; set; }

        // @property (nonatomic, strong) void (^ _Nullable)(UIImage * _Nonnull, CGRect, NSInteger) onDidCropToCircleImage;
        [NullAllowed, Export("onDidCropToCircleImage", ArgumentSemantic.Strong)]
        Action<UIImage, CGRect, nint> OnDidCropToCircleImage { get; set; }

        // -(instancetype _Nonnull)initWithImage:(UIImage * _Nonnull)image;
        [Export("initWithImage:")]
        IntPtr Constructor(UIImage image);

        // -(instancetype _Nonnull)initWithCroppingStyle:(TOCropViewCroppingStyle)style image:(UIImage * _Nonnull)image;
        [Export("initWithCroppingStyle:image:")]
        IntPtr Constructor(TOCropViewCroppingStyle style, UIImage image);

        // -(void)resetCropViewLayout;
        [Export("resetCropViewLayout")]
        void ResetCropViewLayout();

        // -(void)setAspectRatioPreset:(TOCropViewControllerAspectRatioPreset)aspectRatioPreset animated:(BOOL)animated;
        [Export("setAspectRatioPreset:animated:")]
        void SetAspectRatioPreset(TOCropViewControllerAspectRatioPreset aspectRatioPreset, bool animated);

        // -(void)presentAnimatedFromParentViewController:(UIViewController * _Nonnull)viewController fromView:(UIView * _Nullable)fromView fromFrame:(CGRect)fromFrame setup:(void (^ _Nullable)(void))setup completion:(void (^ _Nullable)(void))completion;
        [Export("presentAnimatedFromParentViewController:fromView:fromFrame:setup:completion:")]
        void PresentAnimatedFromParentViewController(UIViewController viewController, [NullAllowed] UIView fromView, CGRect fromFrame, [NullAllowed] Action setup, [NullAllowed] Action completion);

        // -(void)presentAnimatedFromParentViewController:(UIViewController * _Nonnull)viewController fromImage:(UIImage * _Nullable)image fromView:(UIView * _Nullable)fromView fromFrame:(CGRect)fromFrame angle:(NSInteger)angle toImageFrame:(CGRect)toFrame setup:(void (^ _Nullable)(void))setup completion:(void (^ _Nullable)(void))completion;
        [Export("presentAnimatedFromParentViewController:fromImage:fromView:fromFrame:angle:toImageFrame:setup:completion:")]
        void PresentAnimatedFromParentViewController(UIViewController viewController, [NullAllowed] UIImage image, [NullAllowed] UIView fromView, CGRect fromFrame, nint angle, CGRect toFrame, [NullAllowed] Action setup, [NullAllowed] Action completion);

        // -(void)dismissAnimatedFromParentViewController:(UIViewController * _Nonnull)viewController toView:(UIView * _Nullable)toView toFrame:(CGRect)frame setup:(void (^ _Nullable)(void))setup completion:(void (^ _Nullable)(void))completion;
        [Export("dismissAnimatedFromParentViewController:toView:toFrame:setup:completion:")]
        void DismissAnimatedFromParentViewController(UIViewController viewController, [NullAllowed] UIView toView, CGRect frame, [NullAllowed] Action setup, [NullAllowed] Action completion);

        // -(void)dismissAnimatedFromParentViewController:(UIViewController * _Nonnull)viewController withCroppedImage:(UIImage * _Nullable)image toView:(UIView * _Nullable)toView toFrame:(CGRect)frame setup:(void (^ _Nullable)(void))setup completion:(void (^ _Nullable)(void))completion;
        [Export("dismissAnimatedFromParentViewController:withCroppedImage:toView:toFrame:setup:completion:")]
        void DismissAnimatedFromParentViewController(UIViewController viewController, [NullAllowed] UIImage image, [NullAllowed] UIView toView, CGRect frame, [NullAllowed] Action setup, [NullAllowed] Action completion);
    }

    // @interface TOCropOverlayView : UIView
    [BaseType(typeof(UIView))]
    interface TOCropOverlayView
    {
        // @property (assign, nonatomic) BOOL gridHidden;
        [Export("gridHidden")]
        bool GridHidden { get; set; }

        // @property (assign, nonatomic) BOOL displayHorizontalGridLines;
        [Export("displayHorizontalGridLines")]
        bool DisplayHorizontalGridLines { get; set; }

        // @property (assign, nonatomic) BOOL displayVerticalGridLines;
        [Export("displayVerticalGridLines")]
        bool DisplayVerticalGridLines { get; set; }

        // -(void)setGridHidden:(BOOL)hidden animated:(BOOL)animated;
        [Export("setGridHidden:animated:")]
        void SetGridHidden(bool hidden, bool animated);
    }

    // @interface TOCropScrollView : UIScrollView
    [BaseType(typeof(UIScrollView))]
    interface TOCropScrollView
    {
        // @property (copy, nonatomic) void (^ _Nullable)(void) touchesBegan;
        [NullAllowed, Export("touchesBegan", ArgumentSemantic.Copy)]
        Action TouchesBegan { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(void) touchesCancelled;
        [NullAllowed, Export("touchesCancelled", ArgumentSemantic.Copy)]
        Action TouchesCancelled { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(void) touchesEnded;
        [NullAllowed, Export("touchesEnded", ArgumentSemantic.Copy)]
        Action TouchesEnded { get; set; }
    }
}

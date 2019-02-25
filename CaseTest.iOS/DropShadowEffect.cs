using CaseTest.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("Case")]
[assembly: ExportEffect(typeof(DropShadowEffect), nameof(DropShadowEffect))]

namespace CaseTest.iOS
{
    public class DropShadowEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var view = Control as UIView ?? Container as UIView;
            if (view != null)
            {
                view.Layer.ShadowColor = UIColor.Black.CGColor;
                view.Layer.ShadowRadius = 1.0f;
                view.Layer.ShadowOffset = new CoreGraphics.CGSize(1, 1);
                view.Layer.ShadowOpacity = 0.3f;
            }
        }

        protected override void OnDetached()
        {
        }
    }
}

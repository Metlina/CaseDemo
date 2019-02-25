using CaseTest.Controls;
using CaseTest.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MultiLineBreakLabel), typeof(MultiLineBreakLabelRenderer))]

namespace CaseTest.iOS.Renderers
{
    public class MultiLineBreakLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (!(Element is MultiLineBreakLabel label) || Control == null)
            {
                return;
            }

            Control.Lines = label.MineMaxLines;
        }
    }
}

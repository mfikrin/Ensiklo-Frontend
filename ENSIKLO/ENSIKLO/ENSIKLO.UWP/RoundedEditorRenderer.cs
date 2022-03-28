using ENSIKLO.UWP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(ENSIKLO.Renderers.RoundedEditor), typeof(RoundedEditorRenderer))]
namespace ENSIKLO.UWP
{
    public class RoundedEditorRenderer : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Windows.UI.Xaml.ResourceDictionary dic = new Windows.UI.Xaml.ResourceDictionary();
                dic.Source = new Uri("ms-appx:///RoundedEditorRes.xaml");
                Control.Style = dic["RoundedEditorStyle"] as Windows.UI.Xaml.Style;
            }
        }
    }
}
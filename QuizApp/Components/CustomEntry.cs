using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace CustomRenderer.iOS
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected void OnElementChanged (ElementChangedEventArgs<Entry> e)
        {
            base.onElementChanged(e);

        }
    }
}

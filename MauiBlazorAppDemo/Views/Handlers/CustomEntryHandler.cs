using MauiBlazorAppDemo.Views.CustomControls;
using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBlazorAppDemo.Views.Handlers
{
    public class CustomEntryHandler
    {
        public void RemoveEntryUnderline()
        {
#if ANDROID
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoUnderline", (h, v) =>
            {
                if (v is CustomEntry)
                {

                    h.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.Transparent);

                }
            });
#endif
#if WINDOWS
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(IView.Background), (h, v) =>
            {
                if (v is CustomEntry)
                {

                    h.PlatformView.BorderBrush = Colors.Transparent.ToPlatform();
                }
            });
#endif
        }
    }
}

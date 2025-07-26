using Microsoft.Maui.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;
using XamarinAudioPlayer.Control;

namespace XamarinAudioPlayer.Platforms.iOS
{
    internal class MySliderHandler : ViewHandler<MyCustomSlider, UISlider>
    {
        
        protected override UISlider CreatePlatformView()
        {
            return new UISlider();
        }
        protected override void ConnectHandler(UISlider platformView)
        {
            base.ConnectHandler(platformView);
            // Additional setup if needed
        }
        protected override void DisconnectHandler(UISlider platformView)
        {
            base.DisconnectHandler(platformView);
            // Cleanup if needed
        }
        public static void MapValue(MySliderHandler handler, MyCustomSlider slider)
        {
            handler.PlatformView.Value = (float)slider.Value;
        }
        
        public static void MapMinimum(MySliderHandler handler, MyCustomSlider slider)
        {
            handler.PlatformView.MinValue = (float)slider.Minimum;
        }
        public static void MapMaximum(MySliderHandler handler, MyCustomSlider slider)
        {
            handler.PlatformView.MaxValue = (float)slider.Maximum;
        }
        public MySliderHandler(IPropertyMapper mapper, CommandMapper? commandMapper = null) : base(mapper, commandMapper)
        {

        }
    }
}

using Microsoft.Maui.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;
using XamarinAudioPlayer.Control;

namespace XamarinAudioPlayer
{
    internal class MySliderHandler : SliderHandler
    {

        public MySliderHandler() : base()
        {
            // Optional: Add custom logic here
        }
        
        protected override UISlider CreatePlatformView()
        {
            base.CreatePlatformView();
            var slider = new UISlider();
            // Hide the thumb by setting a transparent image
            slider.SetThumbImage(new UIImage(), UIControlState.Normal);
            // Create and return a custom UISlider instance
            return slider;
        }
       
    }
}

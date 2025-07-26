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
            return new UISlider();
        }
       
    }
}

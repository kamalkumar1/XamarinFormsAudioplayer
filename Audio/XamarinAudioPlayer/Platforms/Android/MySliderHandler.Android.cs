using Android.Widget;
using Google.Android.Material.Slider;
using Microsoft.Maui.Handlers;
using System;
using XamarinAudioPlayer.Control;

namespace XamarinAudioPlayer
{
    public class MySliderHandler : SliderHandler
    {
        public MySliderHandler(IPropertyMapper mapper, CommandMapper? commandMapper = null) : base(mapper, commandMapper)
        {
        }
        public MySliderHandler() : base()
        {
            // Optional: Add custom logic here
        }

        protected override SeekBar CreatePlatformView()
        {
            var nativeSlider = base.CreatePlatformView();

            return nativeSlider;
        }

    }
}
using Android.Widget;
using Google.Android.Material.Slider;
using Microsoft.Maui.Handlers;
using System;
using XamarinAudioPlayer.Control;

namespace XamarinAudioPlayer
{
    public class KKSliderHandler : SliderHandler
    {
        public KKSliderHandler(IPropertyMapper mapper, CommandMapper? commandMapper = null) : base(mapper, commandMapper)
        {
        }
        public KKSliderHandler() : base()
        {
            // Optional: Add custom logic here
        }

        protected override SeekBar CreatePlatformView()
        {
            var nativeSlider = base.CreatePlatformView();
            nativeSlider.SetThumb(null); // Hide the thumb by setting it to null

            return nativeSlider;
        }

    }
}
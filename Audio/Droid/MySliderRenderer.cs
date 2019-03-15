using Android.Widget;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using System.ComponentModel;
using Android.Graphics;
using CustomSliderDemo;
using CustomSliderDemo.Droid;
using Audio;
using Xamarin.Android;
using System;
using Audio.Droid;
using Android.Content;
using Android.Views;

[assembly: ExportRenderer(typeof(CustomSlider), typeof(MySliderRenderer))]
namespace CustomSliderDemo.Droid
{
    public class MySliderRenderer : SliderRenderer, SeekBar.IOnSeekBarChangeListener
    {
        public MySliderRenderer(Context context) : base(context)
        {

        }

        private CustomSlider view;
        SeekBar _seekBar;
        Slider _slider;

        protected override void OnElementChanged(ElementChangedEventArgs<Slider> e)
        {
            base.OnElementChanged(e);

            base.OnElementChanged(e);
            if (e.OldElement != null || e.NewElement == null)
                return;


            //_seekBar = Control as SeekBar;
            //if (_seekBar == null)
            //{
            //    return;
            //}
            //_slider = Element as Slider;
            //if (_slider == null)
            //{
            //    return;
            //}
           //var slider = (Audio.CustomSlider)e.NewElement;
            //Control.Max = (int)(slider.Maximum - slider.Minimum);
           // Control.Progress = (int)(slider.Value - slider.Minimum);
            //Control.Max = (int)_slider.Maximum;
            //view = (CustomSlider)Element;

            //view = (CustomSlider)Element;
            //Control.Max = view.Maximum;
            // _seekBar.Max = (int)_slider.Maximum;
            Control.SetOnSeekBarChangeListener(this);
           // Control.Touch += Control_Touch;
            // Control.ProgressChanged += Control_ProgressChanged;
            //Control.Max = (int)Element.Maximum;

        }

        public void OnProgressChanged(SeekBar seekBar, int progress, bool fromUser)
        {
            Console.WriteLine("curentSliderValue:"+seekBar.Progress);
            //Control.Progress = (int)((_slider.Value - _slider.Minimum) / (_slider.Maximum - _slider.Minimum) * 1000.0);

            //Console.WriteLine("MaxProgress:" + seekBar.Max);
            // AudioFile.getobject(progress);
            // if (fromUser)
            // {
            //  _textView.Text = string.Format("SeekBar value to {0}", seekBar.Progress);
            //}
        }
        public void OnStartTrackingTouch(SeekBar seekBar)
        {
            System.Diagnostics.Debug.WriteLine("Tracking changes.");
            // Console.WriteLine(seekBar.Progress);

        }
        public void OnStopTrackingTouch(SeekBar seekBar)
        {
            System.Diagnostics.Debug.WriteLine(seekBar.Max);
           // Console.WriteLine("Progress1:" + (int)((_slider.Value - _slider.Minimum) / (_slider.Maximum - _slider.Minimum) * 1000.0));
            Console.WriteLine(seekBar.Progress);
            var nums = (int)seekBar.Progress;
          
            //var slider = (Audio.CustomSlider)Element;
           // slider.Value = seekBar.Progress;
            AudioFile.getobject(nums);
        }
    }
}
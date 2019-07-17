using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using static Xamarin.Forms.Device;

namespace Audio
{
    public partial class AudioPage : ContentPage
    {

        public AudioPage()
        {
            InitializeComponent();
            lblcurrent.Text = "0.0";
            SetupAuidoFile();
            MessagingCenter.Send(this, "Hi", "John");

        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            var dialer = DependencyService.Get<AudioInterface>();
            if (dialer != null)
                dialer.RemoveNotification();
        }
        public void SetupAuidoFile()
        {
            var dialer = DependencyService.Get<AudioInterface>();
            if (dialer != null)
            {
                dialer.PositionChanged += Dialer_PositionChanged;
                dialer.SetUpAudio();
                lblTotalCount.Text  = (string) dialer.GetTotaltime();
                customSlider.Maximum = Convert.ToDouble(dialer.MediaTotalDuration());
              
            }
        }

        void PlayClick(object sender, System.EventArgs e)
        {

            var dialer = DependencyService.Get<AudioInterface>();
            if (dialer != null)
            {
                //Setuptimer();

                dialer.Play();
            }
        }
        void PauseClick(object sender, System.EventArgs e)
        {
            var dialer = DependencyService.Get<AudioInterface>();
            if (dialer != null)
                dialer.Pause();
        }
        void RestartClick(object sender, System.EventArgs e)
        {
            var dialer = DependencyService.Get<AudioInterface>();
            if (dialer != null)
                dialer.Restart();
            lblcurrent.Text = "0.0";
        }
        void OnSliderValueChanged(object sender, ValueChangedEventArgs eventArgs)
        {
            Debug.WriteLine("ConsoleTimer:" + eventArgs.NewValue);
           // customSlider.Value = eventArgs.NewValue;
        }
        void Dialer_PositionChanged(object sender, EventArgs e)
        {
            var dicitionary = sender as Dictionary<string, object>;
            lblcurrent.Text = (string)dicitionary["CurrentText"];
            customSlider.Value =Convert.ToDouble(dicitionary["CurrentDuration"]);
        }

    }
}

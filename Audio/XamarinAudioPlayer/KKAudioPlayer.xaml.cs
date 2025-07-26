using XamarinAudioPlayer;
using System.Diagnostics;
using XamarinAudioPlayer.Interface;
#if ANDROID
using XamarinAudioPlayer.Platforms.Android;
#endif
namespace XamarinAudioPlayer;

public partial class KKAudioPlayer : ContentPage
{
    private KKAudioFile _audioFile; // Fix for CS8618: Declare _audioFile as nullable or initialize it in the constructor.

    public KKAudioPlayer()
    {
        InitializeComponent();
        _audioFile = new KKAudioFile(); // Initialize _audioFile to avoid CS8618.
        lblcurrent.Text = "0.0";
        SetupAuidoFile();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        if (_audioFile != null)
            _audioFile.RemoveNotification();
    }

    public void SetupAuidoFile()
    {
        if (_audioFile != null)
        {

            _audioFile.SetUpAudio("TestAuidoSong", "mp3");
            _audioFile.PositionChanged += Dialer_PositionChanged;
            lblTotalCount.Text = (string)_audioFile.GetTotaltime();
            customSlider.Maximum = Convert.ToDouble(_audioFile.MediaTotalDuration());
        }
    }

    void PlayClick(object sender, System.EventArgs e)
    {
        if (_audioFile != null)
        {
            _audioFile.Play();
        }
    }

    void PauseClick(object sender, System.EventArgs e)
    {
        if (_audioFile != null)
            _audioFile.Pause();
    }

    void RestartClick(object sender, System.EventArgs e)
    {
        if (_audioFile != null)
            _audioFile.Restart();
        lblcurrent.Text = "0.0";
    }

    void OnSliderValueChanged(object sender, ValueChangedEventArgs eventArgs)
    {
        Debug.WriteLine("ConsoleTimer:" + eventArgs.NewValue);
    }

    private void Dialer_PositionChanged(object sender, EventArgs e) // Fix for CS1520: Add 'void' return type.
    {
        var dictionary = sender as Dictionary<string, object>;
        if (dictionary != null)
        {
            lblcurrent.Text = (string)dictionary["CurrentText"];
            customSlider.Value = Convert.ToDouble(dictionary["CurrentDuration"]);
        }
    }
}
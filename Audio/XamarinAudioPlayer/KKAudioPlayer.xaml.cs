using XamarinAudioPlayer;
using System.Diagnostics;
using XamarinAudioPlayer.Interface;
using XamarinAudioPlayer.ViewModel;
using XamarinAudioPlayer.Model;
#if ANDROID
using XamarinAudioPlayer.Platforms.Android;
#elif IOS
using XamarinAudioPlayer.Platforms.iOS;
#endif
namespace XamarinAudioPlayer;

public partial class KKAudioPlayer : ContentPage
{
    private KKAudioFile _audioFile; // Fix for CS8618: Declare _audioFile as nullable or initialize it in the constructor.

    public KKAudioPlayer()
    {
        InitializeComponent();
        _audioFile = new KKAudioFile(); 
        lblcurrent.Text = "0.0";
        SetupAuidoFile();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        if (_audioFile != null)
        {
            _audioFile.PositionChanged -= Slider_PositionChanged;
            // To Remove all the audio setup and event handlers from the memory
            _audioFile.RemoveAudioSetup();
        }
           
    }
    /// <summary>
    /// Sets up the audio file with the specified filename and type.
    /// </summary>
    public void SetupAuidoFile()
    {
        if (_audioFile != null)
        {
            //Set the audio file name and type here
            _audioFile.SetUpAudio("TestAudioSong", "mp3");
            // Subscribe to the PositionChanged event current audio position
            _audioFile.PositionChanged += Slider_PositionChanged;
            // Get the total playing time of the audio file
            lblTotalCount.Text = (string)_audioFile.GetTotalTime();
            // Set the total playing time of the audio file as the maximum value of the slider
            customSlider.Maximum = Convert.ToDouble(_audioFile.MediaTotalDuration());
        }
    }
    /// <summary>
    /// Play button click event handler to start playing the audio file.
    /// </summary>
    void PlayClick(object sender, System.EventArgs e)
    {
        if (_audioFile != null)
        {
            _audioFile.Play();
        }
    }
    /// <summary>
    /// Pause button click event handler to pause the audio file playback.
    /// </summary>
    void PauseClick(object sender, System.EventArgs e)
    {
        if (_audioFile != null)
            _audioFile.Pause();
    }
    /// <summary>
    /// Restart button click event handler to restart the audio file playback.
    /// </summary>
    void RestartClick(object sender, System.EventArgs e)
    {
        if (_audioFile != null)
            _audioFile.Restart();
        lblcurrent.Text = "0.0";
    }
    /// <summary>
    /// Update the slider value and current play time in label based on the current play time of the audio file.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Slider_PositionChanged(object sender, EventArgs e)
    {
        if (sender is KKAudioPlayTime playTime)
        {
            lblcurrent.Text = playTime.CurrentPlayTime.ToString();
            customSlider.Value = Convert.ToDouble(playTime.SliderValue);
        }
    }
}
using XamarinAudioPlayer;
using System.Diagnostics;
using XamarinAudioPlayer.Interface;
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
            _audioFile.SetUpAudio("TestAuidoSong", "mp3");
            // Subscribe to the PositionChanged event current audio position
            _audioFile.PositionChanged += Dialer_PositionChanged;
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
    /// Slider value changed event handler.
    /// </summary>
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
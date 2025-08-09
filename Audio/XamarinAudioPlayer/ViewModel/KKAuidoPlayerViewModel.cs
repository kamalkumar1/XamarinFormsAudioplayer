using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XamarinAudioPlayer.Model;
#if ANDROID
using XamarinAudioPlayer.Platforms.Android;
#elif IOS
using XamarinAudioPlayer.Platforms.iOS;
#endif

namespace XamarinAudioPlayer.ViewModel
{
    internal class KKAuidoPlayerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;


        public ICommand PlayCommand { get; }


        private string totalPlayTime;
        public string TotalPlayTime
        {
            get => totalPlayTime;
            set
            {
                if (totalPlayTime != value)
                {
                    totalPlayTime = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TotalPlayTime)));
                }
            }
        }

        private string currentPlayTime;
        public string CurrentPlayTime
        {
            get => currentPlayTime;
            set
            {
                if (currentPlayTime != value)
                {
                    currentPlayTime = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentPlayTime)));
                }
            }
        }

        private string fileName;
        public string FileName
        {
            get => fileName;
            set
            {
                if (fileName != value)
                {
                    fileName = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FileName)));
                }
            }
        }

        private string fileType;
        public string FileType
        {
            get => fileType;
            set
            {
                if (fileType != value)
                {
                    fileType = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FileType)));
                }
            }
        }
        public string? PlayImageName { get; set; }
        public string? PauseImageName { get; set; }
        private string? playAndPauseImageName;
        public string? PlayAndPauseImageName
        {
            get => playAndPauseImageName;
            set
            {
                if (playAndPauseImageName != value)
                {
                    playAndPauseImageName = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PlayAndPauseImageName)));
                }
            }
        }
        private double currentPlayTimeFontSize;
        public double CurrentPlayTimeFontSize
        {
            get => currentPlayTimeFontSize;
            set
            {
                if (Math.Abs(currentPlayTimeFontSize - value) > 0.001)
                {
                    currentPlayTimeFontSize = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentPlayTimeFontSize)));
                }
            }
        }
        private double endPlayTimeFontSize;
        public double EndPlayTimeFontSize
        {
            get => endPlayTimeFontSize;
            set
            {
                if (Math.Abs(endPlayTimeFontSize - value) > 0.001)
                {
                    endPlayTimeFontSize = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EndPlayTimeFontSize)));
                }
            }
        }
        private double sliderMaximum;
        public double SliderMaximum
        {
            get => sliderMaximum;
            set
            {
                if (Math.Abs(sliderMaximum - value) > 0.001)
                {
                    sliderMaximum = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SliderMaximum)));
                }
            }
        }
        private double sliderValue;
        public double SliderValue
        {
            get => sliderValue;
            set
            {
                if (Math.Abs(sliderValue - value) > 0.001)
                {
                    sliderValue = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SliderValue)));
                }
            }
        }
        public Color minimumTrackColors;
        public Color MinimumTrackColors
        {
            get => minimumTrackColors;
            set
            {
                if (minimumTrackColors != value)
                {
                    minimumTrackColors = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MinimumTrackColors)));
                }
            }
        }
        public Color maximumTrackColors;
        public Color MaximumTrackColors
        {
            get => maximumTrackColors;
            set
            {
                if (maximumTrackColors != value)
                {
                    maximumTrackColors = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MaximumTrackColors)));
                }
            }
        }
        public Color endtimeTextColor;
        public Color EndPlayTimeTextColor
        {
            get => endtimeTextColor;
            set
            {
                if (endtimeTextColor != value)
                {
                    endtimeTextColor = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EndPlayTimeTextColor)));
                }
            }
        }
        public Color currenttimeTextColor;
        public Color CurrentPlayTimeTextColor
        {
            get => currenttimeTextColor;
            set
            {
                if (currenttimeTextColor != value)
                {
                    currenttimeTextColor = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentPlayTimeTextColor)));
                }
            }
        }
      
        KKAudioFile _kKAudioFile;


        public KKAuidoPlayerViewModel()
        {
            PlayCommand = new Command(OnPlay);
            _kKAudioFile = new KKAudioFile();
            _kKAudioFile.PositionChanged += OnAudioFilePositionChanged;
            _kKAudioFile.IsAudioCompleted += OnAudioFileCompleted;
        }
        /// <summary>
        /// This method is called when the audio file playback is completed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnAudioFileCompleted(object? sender, EventArgs e)
        {
            playAndPauseImageName = PlayImageName;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PlayAndPauseImageName)));
        }
        /// <summary>
        /// This method is called when the audio file play time get's changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnAudioFilePositionChanged(object? sender, EventArgs e)
        {
            if (sender is KKAudioPlayTime playTime)
            {
                CurrentPlayTime = (string)playTime.CurrentPlayTime;
                SliderValue = Convert.ToDouble(playTime.SliderValue);
            }
        }
        public void SetFileNameAndType()
        {
            PlayAndPauseImageName = PlayImageName; // Reset to PlayImageName when setting new file
            _kKAudioFile.SetUpAudio(FileName, FileType);
            TotalPlayTime = _kKAudioFile.GetTotalTime()?.ToString() ?? "0.00";
            SliderMaximum = Convert.ToDouble(_kKAudioFile.MediaTotalDuration());
            CurrentPlayTime = "0.00";
        }
        public void RemoveAudioSetup()
        {
            _kKAudioFile.PositionChanged -= OnAudioFilePositionChanged;
            _kKAudioFile.IsAudioCompleted -= OnAudioFileCompleted;
            _kKAudioFile.RemoveAudioSetup();
        }

        private void OnPlay()
        {
            // TODO: Add play logic
            if (_kKAudioFile != null)
            {
                if (_kKAudioFile.IsPlaying())
                {
                    _kKAudioFile.Pause();
                    PlayAndPauseImageName = PlayImageName; // Change to PlayImageName when paused
                }
                else
                {
                    // Restart if not playing
                    _kKAudioFile.Play();
                    PlayAndPauseImageName = PauseImageName;
                }

                // Update the current play time
            }
        }

    }
}

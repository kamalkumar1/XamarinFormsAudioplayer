using XamarinAudioPlayer.ViewModel;

namespace XamarinAudioPlayer;

public partial class KKAudioPlayerView : ContentView
{
    public static readonly BindableProperty AudioNameProperty =
        BindableProperty.Create(
            nameof(AudioName),
            typeof(string),
            typeof(KKAudioPlayerView),
            default(string));

    public string AudioName
    {
        get => (string)GetValue(AudioNameProperty);
        set => SetValue(AudioNameProperty, value);
    }

    public static readonly BindableProperty FileTypeProperty =
        BindableProperty.Create(
            nameof(FileType),
            typeof(string),
            typeof(KKAudioPlayerView),
            default(string));

    public string FileType
    {
        get => (string)GetValue(FileTypeProperty);
        set => SetValue(FileTypeProperty, value);
    }
    public static readonly BindableProperty PlayImageNameProperty =
        BindableProperty.Create(
            nameof(PlayImageName),
            typeof(string),
            typeof(KKAudioPlayerView),
            default(string));

    public string PlayImageName
    {
        get => (string)GetValue(PlayImageNameProperty);
        set => SetValue(PlayImageNameProperty, value);
    }

    public static readonly BindableProperty PauseImageNameProperty =
        BindableProperty.Create(
            nameof(PauseImageName),
            typeof(string),
            typeof(KKAudioPlayerView),
            default(string));

    public string PauseImageName
    {
        get => (string)GetValue(PauseImageNameProperty);
        set => SetValue(PauseImageNameProperty, value);
    }
    public static readonly BindableProperty CurrentPlayTimeFontSizeProperty =
        BindableProperty.Create(
            nameof(CurrentPlayTimeFontSize),
            typeof(double),
            typeof(KKAudioPlayerView),
            14.0);

    public double CurrentPlayTimeFontSize
    {
        get => (double)GetValue(CurrentPlayTimeFontSizeProperty);
        set => SetValue(CurrentPlayTimeFontSizeProperty, value);
    }
    public static readonly BindableProperty EndPlayTimeFontSizeProperty =
        BindableProperty.Create(
            nameof(EndPlayTimeFontSize),
            typeof(double),
            typeof(KKAudioPlayerView),
            14.0);

    public double EndPlayTimeFontSize
    {
        get => (double)GetValue(EndPlayTimeFontSizeProperty);
        set => SetValue(EndPlayTimeFontSizeProperty, value);
    }
    public static readonly BindableProperty CurrentPlayTimeTextColorProperty =
        BindableProperty.Create(
            nameof(CurrentPlayTimeTextColor),
            typeof(Color),
            typeof(KKAudioPlayerView),
            Colors.Black);

    public Color CurrentPlayTimeTextColor
    {
        get => (Color)GetValue(CurrentPlayTimeTextColorProperty);
        set => SetValue(CurrentPlayTimeTextColorProperty, value);
    }

    public static readonly BindableProperty EndPlayTimeTextColorProperty =
        BindableProperty.Create(
            nameof(EndPlayTimeTextColor),
            typeof(Color),
            typeof(KKAudioPlayerView),
            Colors.Black);

    public Color EndPlayTimeTextColor
    {
        get => (Color)GetValue(EndPlayTimeTextColorProperty);
        set => SetValue(EndPlayTimeTextColorProperty, value);
    }
    public Color MaximumSliderTrackColor
    {
        get => (Color)GetValue(MaximumSliderTrackColorProperty);
        set => SetValue(MaximumSliderTrackColorProperty, value);
    }
    public static readonly BindableProperty MaximumSliderTrackColorProperty =
        BindableProperty.Create(
            nameof(MaximumSliderTrackColor),
            typeof(Color),
            typeof(KKAudioPlayerView),
            Colors.LightGray);
    public Color MinimumSliderTrackColor
    {
        get => (Color)GetValue(MinimumSliderTrackColorProperty);
        set => SetValue(MinimumSliderTrackColorProperty, value);
    }
    public static readonly BindableProperty MinimumSliderTrackColorProperty =
        BindableProperty.Create(
            nameof(MinimumSliderTrackColor),
            typeof(Color),
            typeof(KKAudioPlayerView),
            Colors.DarkGray);

    private KKAuidoPlayerViewModel ViewModel;

    public KKAudioPlayerView()
    {
        InitializeComponent();
        BindingContext = new KKAuidoPlayerViewModel();
        ViewModel = (KKAuidoPlayerViewModel)BindingContext;
        Loaded += (s, e) => { ViewModel.SetFileNameAndType(); };
        Unloaded += (s, e) => { ViewModel.RemoveAudioSetup(); };
    }
    protected override void OnParentSet()
    {
        base.OnParentSet();
    }

    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();
    }

    protected override void OnPropertyChanged(string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
        // Optimize property updates by using a switch statement
        if (propertyName == null)
        {
            // Update all properties if propertyName is null
            ViewModel.FileName = AudioName;
            ViewModel.FileType = FileType;
            ViewModel.PlayImageName = PlayImageName;
            ViewModel.PauseImageName = PauseImageName;
            ViewModel.CurrentPlayTimeFontSize = CurrentPlayTimeFontSize;
            ViewModel.EndPlayTimeFontSize = EndPlayTimeFontSize;
            ViewModel.CurrentPlayTimeTextColor = CurrentPlayTimeTextColor;
            ViewModel.EndPlayTimeTextColor = EndPlayTimeTextColor;
            ViewModel.MaximumTrackColors = MaximumSliderTrackColor;
            ViewModel.MinimumTrackColors = MinimumSliderTrackColor;
        }
        else
        {
            switch (propertyName)
            {
            case nameof(AudioName):
                ViewModel.FileName = AudioName;
                break;
            case nameof(FileType):
                ViewModel.FileType = FileType;
                break;
            case nameof(PlayImageName):
                ViewModel.PlayImageName = PlayImageName;
                break;
            case nameof(PauseImageName):
                ViewModel.PauseImageName = PauseImageName;
                break;
            case nameof(CurrentPlayTimeFontSize):
                ViewModel.CurrentPlayTimeFontSize = CurrentPlayTimeFontSize;
                break;
            case nameof(EndPlayTimeFontSize):
                ViewModel.EndPlayTimeFontSize = EndPlayTimeFontSize;
                break;
            case nameof(CurrentPlayTimeTextColor):
                ViewModel.CurrentPlayTimeTextColor = CurrentPlayTimeTextColor;
                break;
            case nameof(EndPlayTimeTextColor):
                ViewModel.EndPlayTimeTextColor = EndPlayTimeTextColor;
                break;
            case nameof(MaximumSliderTrackColor):
                ViewModel.MaximumTrackColors = MaximumSliderTrackColor;
                break;
            case nameof(MinimumSliderTrackColor):
                ViewModel.MinimumTrackColors = MinimumSliderTrackColor;
                break;
            }
        }
    }

    protected override void OnHandlerChanged()
    {
        base.OnHandlerChanged();
        // Called when the handler (platform renderer) is set or changed
    }
}
using XamarinAudioPlayer.ViewModel;

namespace XamarinAudioPlayer
{
    public partial class MainPage : ContentPage
    {
       
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }

    }

}

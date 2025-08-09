using XamarinAudioPlayer.ViewModel;
namespace XamarinAudioPlayer
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPageViewModel));
            Routing.RegisterRoute(nameof(KKAudioPage), typeof(KKAudioPageViewModel));
        }
    }
}

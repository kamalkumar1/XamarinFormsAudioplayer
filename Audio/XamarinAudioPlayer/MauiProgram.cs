
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.PlatformConfiguration;
using XamarinAudioPlayer.Control;
using XamarinAudioPlayer.Interface;
using XamarinAudioPlayer.ViewModel;

namespace XamarinAudioPlayer
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder()

                .UseMauiApp<App>()
                .ConfigureMauiHandlers(handler =>
                {

                    handler.AddHandler(typeof(MyCustomSlider), typeof(XamarinAudioPlayer.MySliderHandler));

                })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
              //  builder.Services.AddSingleton<MainPageViewModel, IMainPageInterface>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

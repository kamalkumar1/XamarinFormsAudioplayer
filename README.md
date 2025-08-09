#XamarinAudioPlayer.Forms.kk developed using MAUI.
https://www.nuget.org/packages/XamarinAudioPlayer.Forms.kk/

## Overview
XamarinAudioPlayer.Forms.kk is a **MAUI**  library supports playing audio files from both the app's bundled resources and the device's local file system.
## 📦 Installation

Install via NuGet:

```sh
dotnet add package XamarinAudioPlayer.Forms.kk

## Features
- Read Audio files from the app's bundled resources.
- Read Audio files from the device's local file system.
- Cross-platform support (**Android & iOS**).
- Smooth UI experience with **MAUI**.
- It has predefined Audio Player Controls for easy integration.
- It has progress control to show the audio file play time.
- It has play, pause, stop to control for the audio.

## DOCUEMNTAION 
 # To Implement the predefined Audio Player View, you can follow the steps below:
   1. Add the `XamarinAudioPlayer.Forms.kk` NuGet package to your MAUI project.
   2. Add the your mp3 file inside the Resource -> Raw folder of your MAUI project.
   3. Create a new page or use an existing one where you want to display the audio player.
   4. Inherit the `XamarinAudioPlayerLibary` in your xaml namespace, for example:
      ```xml
      xmlns:cs="clr-namespace:XamarinAudioPlayerLibary.View;assembly=XamarinAudioPlayerLibary"
      ```
    6. Add this line code in you  inside the configure handler handler in maui program.cs file:
    ```csharp
          .ConfigureMauiHandlers(handlers =>
     	{
     		// Register custom handlers if needed
     		handlers.AddHandler(typeof(KKCustomSlider), typeof(XamarinAudioPlayer.KKSliderHandler));
     	})
 ```
   5.Add the 'KKAudioPlayerView' control to your XAML page where you want the audio player to appear:
      ```xml
      
      <cs:KKAudioPlayerView 
            EndPlayTimeTextColor="Red"
            CurrentPlayTimeTextColor="Blue"
            MaximumSliderTrackColor="Green"
            MinimumSliderTrackColor="LightGreen"
            EndPlayTimeFontSize ="14"
            CurrentPlayTimeFontSize="14"
            PlayImageName="play"
            PauseImageName="pause" 
            FileType="mp3" 
            AudioName="TestAudioSong" />
            
      ```
## To desing the your own Audio Player View, you can use the following steps:
   1. Add the `XamarinAudioPlayer.Forms.kk` NuGet package to your MAUI project.
   2. Add the your mp3 file inside the Resource -> Raw folder of your MAUI project.
   3. Create a new page or use an existing one where you want to display the audio player.
   4. Inherit the `XamarinAudioPlayerLibary` in your xaml namespace, for example:
      ```xml
      xmlns:cs="clr-namespace:XamarinAudioPlayerLibary.View;assembly=XamarinAudioPlayerLibary"
      ```
   5. In your xamal add the slider,play, pause, stop button and other controls as per your design.
   6. In your code behind, you can use the `KKAudioFile` class to control the audio playback. For example:
   7. Add the following code in your code behind file (e.g., MainPage.xaml.cs):
  
     ```csharp
         using XamarinAudioPlayerLibary.ViewModel;
         #if ANDROID
         using XamarinAudioPlayer.Platforms.Android;
         #elif IOS
         using XamarinAudioPlayer.Platforms.iOS;
         #endif

         public partial class yourcalssname : ContentPage
         {
             private KKAudioFile _audioFile;
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
         }
          ```
## Repository Details
1.Get the full working code from the repository.
1. Clone the repository:
   ```sh
   git clone https://github.com/kamalkumar1/XamarinFormsAudioplayer/tree/develop
Author
Kamal Kumar Senior Mobile Application Developer Open-source contributor|iOS(objective-c, Swift) | MAUI & Xamarin expert 📫 LinkedIn




#XamarinAudioPlayer.Forms.kk developed using MAUI.
https://www.nuget.org/packages/XamarinAudioPlayer.Forms.kk/

## Overview
XamarinAudioPlayer.Forms.kk is a **MAUI**  library supports playing audio files from both the app's bundled resources and the device's local file system.
## 📦 Installation

Install via NuGet:

```sh
dotnet add package XamarinAudioPlayer.Forms.kk

## Features
-It has .NET10 Supprot
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
   5. Inherit the `XamarinAudioPlayerLibary` in your xaml namespace, for example:
```
xmlns:cs="clr-namespace:XamarinAudioPlayerLibary.View;assembly=XamarinAudioPlayerLibary"
```
   5. Add the 'KKAudioPlayerView' control to your XAML page where you want the audio player to appear:
 ```
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
 6.Add all related configuration Android.Manifeast file and ios Plist.

 7.Check out repository for the working code. Check the code from the below given repository and Check branch .NET10_upgrade it has working sample.


## Repository Details
1.Get the full working code from the repository.
1. Clone the repository:
   ```sh
   git clone https://github.com/kamalkumar1/XamarinFormsAudioplayer/tree/develop
Author
Kamal Kumar Senior Mobile Application Developer Open-source contributor|iOS(objective-c, Swift,SWIFTUI) | MAUI & Xamarin expert 📫 LinkedIn

##OUTPUT Image
##ios
![GitHub Logo](https://raw.githubusercontent.com/kamalkumar1/XamarinFormsAudioplayer/net10_upgrade/Screenshot_1764873668.png)
##Android
Simulator Screenshot - iPhone 17 - 2025-12-05 at 00.08.17.png




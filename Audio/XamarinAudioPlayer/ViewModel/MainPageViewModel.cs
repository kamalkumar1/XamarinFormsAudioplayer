using System;
using System.ComponentModel;

namespace XamarinAudioPlayer.ViewModel;

public class MainPageViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public Command CreateYourOwnPlayerCommand { get; }
    public Command InBuildCommand { get; }
    public MainPageViewModel()
    {
        CreateYourOwnPlayerCommand = new Command(OnConteviewCommandExecuted);
        InBuildCommand = new Command(OnInBuildCommandExecuted);
    }

    private void OnInBuildCommandExecuted()
    {
        // Add logic for InBuildCommand here
        // For example, navigate to the in-built audio player page
         Application.Current.MainPage.Navigation.PushAsync(new KKAudioPlayer());
    }

    private void OnConteviewCommandExecuted()
    {
        // Add logic for ConteviewCommand here
          Application.Current.MainPage.Navigation.PushAsync(new KKAudioPage());
          
    }
}

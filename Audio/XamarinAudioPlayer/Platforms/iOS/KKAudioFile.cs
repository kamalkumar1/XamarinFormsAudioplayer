using System;
using UIKit;
using AVFoundation;
using Foundation;
using CoreMedia;
using System.Collections.Generic;
using CoreFoundation;
using XamarinAudioPlayer.Interface;
using System.Diagnostics;
namespace XamarinAudioPlayer.Platforms.iOS
{
    public class KKAudioFile : IAudioInterface
    {
        AVPlayer? Player;
        private NSObject? FinishNotification;
        private NSObject? TimeObserver;
        private const int NSEC_PER_SEC = 1000000000;

        public event EventHandler? PositionChanged;

        public KKAudioFile()
        {
        }
        public object GetTotalTime()
        {
            var totalduration = Player?.CurrentItem.Asset.Duration.Seconds;
            var totaltime = Convert.ToInt64(totalduration);
            var mintutes = totaltime / 60;
            var seconds = totaltime % 60;
            var durationText = mintutes + ":" + seconds;
            return durationText;
        }
        public object MediaTotalDuration()
        {

            if (Player != null)
            {
                return Player?.CurrentItem.Asset.Duration.Seconds;
            }
            else
            {
                return 0.0;
            }

        }
        public object PlayerCurrentTime()
        {
            var totalduration = Player?.CurrentTime.Seconds;
            var totaltime = Convert.ToInt64(totalduration);
            var minutes = totaltime / 60;
            var seconds = totaltime % 60;
            var strSeconds = "";
            if (seconds.ToString().Length == 1)
            {
                strSeconds = "0" + seconds;
            }
            else
            {
                strSeconds = seconds.ToString();
            }
            var totalTime = minutes.ToString() + ":" + strSeconds;
            return totalTime;
        }
        public void SetUpAudio(string filename, string filetype)
        {
            AVAudioSession.SharedInstance().SetCategory(AVAudioSessionCategory.Playback);
            var path = NSBundle.MainBundle.PathForResource(filename, filetype);
            //  NSError err;  
            var urls = NSUrl.FromFilename(path);
            if (urls != null)
            {
                Player = AVPlayer.FromUrl(urls);
                Debug.WriteLine(Player.CurrentItem.Asset.Duration);
                FinishNotification = NSNotificationCenter.DefaultCenter.AddObserver(AVPlayerItem.DidPlayToEndTimeNotification, HandleNotification);

            }
            else
            {
                Debug.WriteLine("NotValidPath");
            }

        }
        private void AddTimeObserverToPlayer()
        {
            if (TimeObserver != null)
            {
                Debug.WriteLine("TimeObserver != null");
                return;
            }

            if (Player == null)
            {
                Debug.WriteLine("Player == null");
                return;
            }

            if (Player.CurrentItem == null)
            {
                Debug.WriteLine("Player.CurrentItem == null");
                return;
            }

            if (Player.CurrentItem.Status != AVPlayerItemStatus.ReadyToPlay)
            {
                Debug.WriteLine("Player.CurrentItem.Status != AVPlayerItemStatus.ReadyToPlay");
                return;
            }

            TimeObserver = Player.AddPeriodicTimeObserver(CMTime.FromSeconds(1, 1),DispatchQueue.MainQueue, delegate{
                GetCurrentTime();
            });

        }
        void GetCurrentTime()
        {
            if (PositionChanged != null)
            {
                var EmployeeList = new Dictionary<string, object>();
                EmployeeList.Add("CurrentDuration", Player.CurrentTime.Seconds);
                EmployeeList.Add("CurrentText", (string)PlayerCurrentTime());
                PositionChanged(EmployeeList, EventArgs.Empty);
            }

        }

        private void RemoveTimeObserverFromPlayer()
        {
            if (TimeObserver != null)
                Player?.RemoveTimeObserver(TimeObserver);

            TimeObserver = null;
        }
        private void HandleNotification(NSNotification notification)
        {
            Player?.Seek(CoreMedia.CMTime.Zero);
        }
        public void RemoveAudioSetup()
        {
            if (Player != null)
            {
                if (FinishNotification != null)
                {
                    NSNotificationCenter.DefaultCenter.RemoveObserver(FinishNotification);
                    FinishNotification = null;
                }
                RemoveTimeObserverFromPlayer();
                Player.Dispose();
                Player = null;
                TimeObserver = null;
                PositionChanged = null;
            }
        }
        public void Play()
        {
            if (Player?.CurrentItem.Status == AVPlayerItemStatus.ReadyToPlay)
            {
                Player.Play();
                AddTimeObserverToPlayer();
            }

        }

        public void Pause()
        {
            Player?.Pause();
        }

        public void Restart()
        {
            // StopTimer();
            if (Player?.CurrentItem.Status == AVPlayerItemStatus.ReadyToPlay)
            {
                Player.Seek(CoreMedia.CMTime.Zero);
                Player.Play();
                if (TimeObserver == null)
                {
                    AddTimeObserverToPlayer();
                }
            }

        }

        public  void getobject(double values)
        {
            long vOut = Convert.ToInt64(values);
            CMTime time = new CMTime(vOut, 1);
            Player.Seek(time);
            Player.Play();

        }
    }
}
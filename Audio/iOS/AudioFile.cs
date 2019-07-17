using System;
using Xamarin.Forms;
using Audio.iOS;
using UIKit;
using AVFoundation;
using Foundation;
using CoreMedia;
using System.Collections.Generic;
using CoreFoundation;

[assembly: Dependency(typeof(AudioFile))]
namespace Audio.iOS
{

    public class AudioFile : AudioInterface
    {
        static AVPlayer player;
        private NSObject finishNotification;
        private NSObject timeObserver;
        private const int NSEC_PER_SEC = 1000000000;
        // public void delegate po
        static public NSTimer timer;
        public event EventHandler PositionChanged;

        public object GetTotaltime()
        {
            var totalduration = player.CurrentItem.Asset.Duration.Seconds;
            var totaltime = Convert.ToInt64(totalduration);
            var mintutes = totaltime / 60;
            var seconds = totaltime % 60;
            var durationText = mintutes + ":" + seconds;
            return durationText; ;
        }
        public object MediaTotalDuration()
        {

            if(player!=null)
            {
                return player.CurrentItem.Asset.Duration.Seconds;
            }
            else
            {
                return 0.0;
            }

        }
        public object PlayerCurrettime()
        {
            var totalduration = player.CurrentTime.Seconds;
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
        public void SetUpAudio()
        {
            Console.WriteLine("MethodCalled");

            AVAudioSession.SharedInstance().SetCategory(AVAudioSessionCategory.Playback);
            var path = NSBundle.MainBundle.PathForResource("KARTKA", "mp3");
            //  NSError err;  
            var urls = NSUrl.FromFilename(path);
            if(urls!=null)
            {
                player = AVPlayer.FromUrl(urls);
                Console.WriteLine(player.CurrentItem.Asset.Duration);
                finishNotification = NSNotificationCenter.DefaultCenter.AddObserver(AVPlayerItem.DidPlayToEndTimeNotification, HandleNotification);

            }
            else
            {
                Console.WriteLine("NotValidPath");
            }

        }
        private void AddTimeObserverToPlayer()
        {
            if (timeObserver != null)
            {
                Console.WriteLine("timeObserver != null");
                return;
            }

            if (player == null)
            {
                Console.WriteLine("Player == null");
                return;
            }

            if (player.CurrentItem == null)
            {
                Console.WriteLine("Player.CurrentItem == null");
                return;
            }

            if (player.CurrentItem.Status != AVPlayerItemStatus.ReadyToPlay)
            {
                Console.WriteLine("Player.CurrentItem.Status != AVPlayerItemStatus.ReadyToPlay");
                return;
            }

            timeObserver = player.AddPeriodicTimeObserver(CMTime.FromSeconds(1, 1),
                                                           DispatchQueue.MainQueue,
                                                           delegate
                                                           {
                                                               if (PositionChanged != null)
                                                               {
                                                                   var EmployeeList = new Dictionary<string, object>();
                                                                   EmployeeList.Add("CurrentDuration", player.CurrentTime.Seconds);
                                                                   EmployeeList.Add("CurrentText", (string)PlayerCurrettime());
                                                                   PositionChanged(EmployeeList, EventArgs.Empty);
                                                               }
                                                           });

        }

        private void RemoveTimeObserverFromPlayer()
        {
            if (timeObserver != null)
                player.RemoveTimeObserver(timeObserver);

            timeObserver = null;
        }

        void HandleAction(NSTimer obj)
        {
            if (PositionChanged != null)
            {
                var EmployeeList = new Dictionary<string, object>();
                EmployeeList.Add("CurrentDuration", player.CurrentTime.Seconds);
                EmployeeList.Add("CurrentText", (string)PlayerCurrettime());
                PositionChanged(EmployeeList, EventArgs.Empty);
            }

        }

        private void HandleNotification(NSNotification notification)
        {
            player.Seek(CoreMedia.CMTime.Zero);

        }
        public void RemoveNotification()
        {
            NSNotificationCenter.DefaultCenter.RemoveObserver(finishNotification);
            RemoveTimeObserverFromPlayer();
        }
        public void Play()
        {
            // startTimer();
            if (player.CurrentItem.Status == AVPlayerItemStatus.ReadyToPlay)
            {
                player.Play();
                AddTimeObserverToPlayer();
            }

        }

        public void Pause()
        {
            // StopTimer();
            player.Pause();
        }

        public void Restart()
        {
            // StopTimer();
            if (player.CurrentItem.Status == AVPlayerItemStatus.ReadyToPlay)
            {
                player.Seek(CoreMedia.CMTime.Zero);
                player.Play();
                if (timeObserver == null)
                {
                    AddTimeObserverToPlayer();  
                }
            }

        }
      
        public static void getobject(double values)
        {
            long vOut = Convert.ToInt64(values);
            CMTime time = new CMTime(vOut, 1);
            player.Seek(time);
            player.Play();

        }
    }
}

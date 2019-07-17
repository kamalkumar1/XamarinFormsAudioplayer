using System;
using Android.OS;
using Android.Media;
using Android.Content;
using Android.Media.Session;
using Xamarin.Forms;
using Audio.Droid;
using Android.Runtime;
using Java.Lang;
using System.Collections.Generic;

[assembly: Dependency(typeof(AudioFile))]
namespace Audio.Droid
{
    public class AudioFile:AudioInterface
    {
        static MediaPlayer player;
        Android.Content.Res.AssetFileDescriptor afd = null;

        public Handler handlers;

        public event EventHandler PositionChanged;
        public Runnable runnable;
        //Runnable runnable = new Runnable();

        public object GetTotaltime()
        {
            int minutes = player.Duration / 1000 / 60;
            int seconds = player.Duration / 1000 % 60;
            var totalTime = minutes.ToString() + ":" + seconds;
            return totalTime ;
        }
        public object MediaTotalDuration()
        {
            if (player != null) {
                return  player.Duration;
            }
            else
            {
                return 0.0;
            }

        }
        public object PlayerCurrettime()
        {
            int minutes = player.CurrentPosition / 1000 / 60;
            int seconds = player.CurrentPosition / 1000 % 60;
            var strSeconds = "";
            if(seconds.ToString().Length == 1)
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
        public void Pause()
        {
                player.Pause();
        }

        public void Play()
        {
            player.Start();
            handlers = new Handler();
            PlayCycle();
        }
        public void Restart()
        {
            if (player != null)
            {
                player.Reset();
                player.SetDataSource(afd.FileDescriptor, afd.StartOffset, afd.Length);
                player.Prepare();
                player.Start();
                handlers = new Handler();
                PlayCycle();

            }
        }

        public void SetUpAudio()
        {
            try
            {
                player = new MediaPlayer();
                afd = global::Android.App.Application.Context.Assets.OpenFd("KARTKA.mp3");
                player.SetDataSource(afd.FileDescriptor, afd.StartOffset, afd.Length);
                player.Completion += Player_SeekComplete;
                player.Info += Player_Info;
                player.Prepare();

            }
            catch (System.Exception ex)
            {

                Console.WriteLine(ex);
            }
        }
        public void RemoveNotification()
        {
            
        }

        public void PlayCycle()
        {
            Console.WriteLine(player.CurrentPosition);
            if (PositionChanged != null)
                if (player.CurrentPosition > 0)
                {
                    var EmployeeList = new Dictionary<string, object>();
                    EmployeeList.Add("CurrentDuration", player.CurrentPosition);
                    EmployeeList.Add("CurrentText", (string)PlayerCurrettime());
                    PositionChanged(EmployeeList, EventArgs.Empty);
                }
            if (player.IsPlaying)
            {
                runnable = new Runnable(delegate
                {
                    PlayCycle();

                });
                handlers.PostDelayed(runnable, 1000);

            }
        }
       

        void Player_Info(object sender, MediaPlayer.InfoEventArgs e)
        {

        }


        void Player_SeekComplete(object sender, EventArgs e)
        {
 
            player.Stop();
        }


        public void SlidePlay(double value)
        {
            
        }
        public static void getobject(int values)
        {
            //Console.WriteLine("console5:"+ values);
            if (player.IsPlaying)
            {
                var user = player.Duration / 1000 * values;
                Console.WriteLine("Write:" + user);
                player.SeekTo(user);

            }else{
                player.SeekTo(values);
                player.Start();
            }
           

        }

        public bool OnInfo(MediaPlayer mp, [GeneratedEnum] MediaInfo what, int extra)
        {
            
            return true;
            
        }

        public void Dispose()
        {
            
        }
        public System.String milliSecondsToTimer(long milliseconds)
        {
            System.String finalTimerString = "";
            System.String secondsString = "";

            // Convert total duration into time
            int hours = (int)(milliseconds / (1000 * 60 * 60));
            int minutes = (int)(milliseconds % (1000 * 60 * 60)) / (1000 * 60);
            int seconds = (int)((milliseconds % (1000 * 60 * 60)) % (1000 * 60) / 1000);
            // Add hours if there
            if (hours > 0)
            {
                finalTimerString = hours + ":";
            }

            // Prepending 0 to seconds if it is one digit
            if (seconds < 10)
            {
                secondsString = "0" + seconds;
            }
            else
            {
                secondsString = "" + seconds;
            }

            finalTimerString = finalTimerString + minutes + ":" + secondsString;

            // return timer string
            return finalTimerString;
        }
    }
}

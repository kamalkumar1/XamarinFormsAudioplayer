using System;
using Android.OS;
using Android.Media;
using Android.Runtime;
using Java.Lang;
using Android.Content.Res;
using XamarinAudioPlayer.Interface;

namespace XamarinAudioPlayer.Platforms.Android
{

    internal class KKAudioFile : IAudioInterface
    {
         MediaPlayer? Player;
         AssetFileDescriptor? afd = null;
        public Handler? handlers;
        public event EventHandler? PositionChanged;
        public Runnable? Runnable;
        public KKAudioFile()
        {

        }
        public object GetTotalTime()
        {
            int minutes = Player?.Duration / 1000 / 60 ?? 0;
            int seconds = Player?.Duration / 1000 % 60 ?? 0;
            var totalTime = minutes.ToString() + ":" + seconds;
            return totalTime;
        }
        public object MediaTotalDuration()
        {
            return Player?.Duration ?? 0.0;
        }
        public object PlayerCurrentTime()
        {
            int minutes = Player?.CurrentPosition / 1000 / 60 ?? 0;
            int seconds = Player?.CurrentPosition / 1000 % 60 ?? 0;
            var strSeconds = string.Empty;
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
        public void Pause()
        {
            Player?.Pause();
        }

        public void Play()
        {
            Player?.Start();
            handlers = new Handler();
            PlayCycle();
        }
        public void Restart()
        {
            if (Player != null)
            {
                Player.Reset();
                Player.SetDataSource(afd.FileDescriptor, afd.StartOffset, afd.Length);
                Player.Prepare();
                Player.Start();
                handlers = new Handler();
                PlayCycle();

            }
        }
        public void SetUpAudio(string filename, string filetype)
        {
            try
            {
                Player = new MediaPlayer();
                afd = global::Android.App.Application.Context.Assets.OpenFd(filename + "." + filetype);
                Player.SetDataSource(afd.FileDescriptor, afd.StartOffset, afd.Length);
                Player.Completion += Player_SeekComplete;
                Player.Info += Player_Info;
                Player.Prepare();

            }
            catch (System.Exception ex)
            {

                Console.WriteLine(ex);
            }
        }
        public void RemoveAudioSetup()
        {
            if (Player != null)
            {
                Player.Completion -= Player_SeekComplete;
                Player.Info -= Player_Info;
                Player.Release();
                handlers?.RemoveCallbacks(Runnable);
                PositionChanged = null;
                handlers = null;
                Runnable = null;
                Player = null;
                afd?.Close();
                afd = null;
            }
        }

        public void PlayCycle()
        {
            Console.WriteLine(Player?.CurrentPosition);
            if (PositionChanged != null)
                if (Player?.CurrentPosition > 0)
                {
                    var playDetail = new Dictionary<string, object>();
                    playDetail.Add("CurrentDuration", Player.CurrentPosition);
                    playDetail.Add("CurrentText", (string)PlayerCurrentTime());
                    PositionChanged(playDetail, EventArgs.Empty);
                }
            if (Player?.IsPlaying == true)
            {
                Runnable = new Runnable(delegate
                {
                    PlayCycle();

                });
                handlers?.PostDelayed(Runnable, 1000);

            }
        }
        void Player_Info(object sender, MediaPlayer.InfoEventArgs e)
        {

        }


        void Player_SeekComplete(object sender, EventArgs e)
        {
            if (Player != null)
            {
                Player.Stop();
            }
        }


        public void SlidePlay(double value)
        {

        }
        public  void getobject(int values)
        {
            //Console.WriteLine("console5:"+ values);
            if (Player.IsPlaying)
            {
                var user = Player.Duration / 1000 * values;
                Console.WriteLine("Write:" + user);
                Player.SeekTo(user);

            }
            else
            {
                Player.SeekTo(values);
                Player.Start();
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinAudioPlayer.Interface
{
    internal interface IAudioInterface
    {
        void SetUpAudio(string filename, string filetype);
        void Play();
        void Pause();
        void Restart();
        void RemoveAudioSetup();
        object PlayerCurrentTime();
        object GetTotalTime();
        object MediaTotalDuration();
        event EventHandler PositionChanged;
    }
}

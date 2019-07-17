
using System;

namespace Audio
{
    public interface AudioInterface
    {

        void SetUpAudio();
        void Play();
        void Pause();
        void Restart();
        void RemoveNotification();
        object PlayerCurrettime();
        object GetTotaltime();
        object MediaTotalDuration();
        event EventHandler PositionChanged;
    }
}


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
        object playerCurrettime();
        object getTotaltime();
        object MediaTotalDuration();
        event EventHandler positionChanged;
    }
}

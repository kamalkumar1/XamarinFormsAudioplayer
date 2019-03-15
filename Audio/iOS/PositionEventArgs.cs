using System;
namespace Audio.iOS
{
    public class PositionEventArgs
    {
        string position { get; set; }
        public PositionEventArgs(string pos)
        {
            position = pos;
        }
    }
}

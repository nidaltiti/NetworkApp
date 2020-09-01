using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkApp
{
    public enum Headers : byte
    {
        Queue,
        Start,
        Stop,
        Pause,
        Chunk
    }
}

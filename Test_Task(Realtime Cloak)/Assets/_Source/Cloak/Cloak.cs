using System;

namespace CloakTime
{
    [Serializable]
    public class Cloak
    {
        public long time;
        public string cloaks;

        public DateTime GetTime() =>
            DateTimeOffset.FromUnixTimeMilliseconds(time).LocalDateTime;
    }
}
using System;

namespace CloakTime
{
    [Serializable]
    public class Clock
    {
        public long unixtime;

        public DateTime GetTime() =>
            DateTimeOffset.FromUnixTimeSeconds(unixtime).LocalDateTime;
    }
}
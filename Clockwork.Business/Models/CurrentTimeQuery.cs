using System;

namespace Clockwork.Business.Models
{
    public class CurrentTimeQuery
    {
        private DateTime? _time { get; set; }
        private DateTime? _uTCTime { get; set; }

        public int CurrentTimeQueryId { get; set; }
        public string ClientIp { get; set; }
        public DateTime Time
        {
            get
            {
                if (_time.HasValue)
                    return _time.Value;
                else
                    return DateTime.Now;
            }
            set
            {
                _time = value;
            }
        }
        public DateTime UTCTime
        {
            get
            {
                if (_uTCTime.HasValue)
                    return _time.Value;
                else
                    return DateTime.UtcNow;
            }
            set
            {
                _uTCTime = value;
            }
        }
    }
}

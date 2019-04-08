using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clockwork.Data.Entities
{
    [Table("CurrentTimeQueries")]
    public class CurrentTimeQuery
    {
        [Key]
        public int CurrentTimeQueryId { get; set; }
        public DateTime Time { get; set; }
        public string ClientIp { get; set; }
        public DateTime UTCTime { get; set; }
        public TimeSpan? Offset { get; set; }
    }
}

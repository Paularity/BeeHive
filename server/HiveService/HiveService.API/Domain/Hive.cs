using System;
using System.ComponentModel.DataAnnotations;

namespace HiveService.API.Domain
{
    public class Hive
    {
        [Key]
        public Guid HiveId { get; set; }
        public string Location { get; set; } = string.Empty;
        public string HiveName { get; set; } = string.Empty;
        public int QueenAge { get; set; }
        public int ColonyStrength { get; set; }
        public string HealthStatus { get; set; } = string.Empty;
    }
}

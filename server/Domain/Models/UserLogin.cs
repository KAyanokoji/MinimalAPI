using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Domain.Models
{
     [Table("UserLogins", Schema = "Identity")]
    public class UserLogin
    {
        [Key]
        public int LoginId { get; set; }

        [Required]
        public int UserId { get; set; }

        [MaxLength(255)]
        public string Username { get; set; }

        public string DeviceMacAddress { get; set; } // macaddr type in PostgreSQL

        public string IpAddress { get; set; } // inet type in PostgreSQL

        public DateTime? LoginDatetime { get; set; }

        [MaxLength(255)]
        public string GpsLocation { get; set; }

        [MaxLength(255)]
        public string BrowserInfo { get; set; }

        [MaxLength(255)]
        public string SessionId { get; set; }

        public bool? LoginStatus { get; set; }

        public DateTime? LogoutDatetime { get; set; }

        [MaxLength(50)]
        public string LoginMethod { get; set; }

        [MaxLength(100)]
        public string DeviceName { get; set; }

        [MaxLength(100)]
        public string DeviceModel { get; set; }

        [MaxLength(100)]
        public string OperatingSystem { get; set; }

        [MaxLength(100)]
        public string NetworkProvider { get; set; }

        public int? FailedLoginAttempts { get; set; }

        public bool? AccountLocked { get; set; }

        [MaxLength(255)]
        public string ReferrerUrl { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }

}
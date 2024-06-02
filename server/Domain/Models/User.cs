using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Domain.Models
{
    [Table("Users", Schema = "Identity")]

    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }

        [MaxLength(255)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(255)]
        public string UserName { get; set; }

        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [MaxLength(255)]
        public string Password { get; set; }

        [Required]
        public int Gender { get; set; }

        [Required]
        public int AddressId { get; set; }

        public bool? EmailVerified { get; set; }

        public bool? PhoneVerified { get; set; }

        [MaxLength(255)]
        public string Otp { get; set; }
        public bool Status { get; set; }


        public DateTime? LastLogin { get; set; }

        public int? LoginCount { get; set; }

        public int? RoleId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}
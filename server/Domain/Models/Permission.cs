using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Domain.Models
{
    [Table("Permission", Schema = "Identity")]
    public class Permission
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PermissionName { get; set; }

        [Required]
        public string GuardName { get; set; }

        [Required]
        public bool Status { get; set; }

        public int? RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}
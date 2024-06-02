using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Domain.Models
{
     [Table("Role", Schema = "Identity")]
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string RoleName { get; set; }

        [Required]
        public string GuardName { get; set; }

        [Required]
        public bool Status { get; set; }

        [Required]
        public int PermissionId { get; set; }
        
        // Navigation property for related Users
        public virtual ICollection<User> Users { get; set; }
    }
}
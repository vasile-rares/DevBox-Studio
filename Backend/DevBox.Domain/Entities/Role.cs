using System.ComponentModel.DataAnnotations;

namespace DevBox.Domain.Entities
{
    public class Role : BaseEntity
    {
        [Required, MaxLength(50)]
        public string Name { get; set; } = null!;

        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
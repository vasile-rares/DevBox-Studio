using System.ComponentModel.DataAnnotations;

namespace DevBox.Domain.Entities;

public class User : BaseEntity
{
    [Required, MaxLength(50)]
    public string Username { get; set; } = null!;

    [Required, MaxLength(100)]
    public string Email { get; set; } = null!;

    [Required]
    public string PasswordHash { get; set; } = null!;


    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

}

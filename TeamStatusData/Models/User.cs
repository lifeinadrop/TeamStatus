using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeamStatusData.Enums;

namespace TeamStatusData.Models;

[Table("Users", Schema = "teamstatus")]
public class User
{
    [Key]
    [Column("id")]
    public long Id { get; set; }
    
    [Required]
    [Column("name")]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    [Column("title")]
    public string Title { get; set; } = string.Empty;

    [Required, DefaultValue(UserStatus.Available), Column("status")]
    public UserStatus Status { get; set; } = UserStatus.Available;
}
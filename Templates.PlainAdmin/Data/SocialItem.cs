using System.ComponentModel.DataAnnotations;

namespace Templates.PlainAdmin.Data;
 
public class SocialItem
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Url { get; set; } = string.Empty;
    [Required]
    public string Icon { get; set; } = string.Empty;
}

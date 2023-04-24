using System.ComponentModel.DataAnnotations;

namespace Templates.PlainAdmin.Data;

public class PortifolioItem
{
    [Key]
    public int Id { get; set; }
    public string Image { get; set; } = string.Empty;
    [Required]
    public string Url { get; set; } = string.Empty;
    public string UrlGitHub { get; set; } = string.Empty;
}

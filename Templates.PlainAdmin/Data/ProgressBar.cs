using System.ComponentModel.DataAnnotations;

namespace Templates.PlainAdmin.Data;

public class ProgressBar
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Percent { get; set; } = string.Empty;
}

using System.ComponentModel.DataAnnotations;

namespace Templates.PlainAdmin.Data;
public class AboutItem
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string PrimaryText { get; set; } = string.Empty;
    [Required]
    public string SecundaryText { get; set; } = string.Empty;
}

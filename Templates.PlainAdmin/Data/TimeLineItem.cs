using System.ComponentModel.DataAnnotations;

namespace Templates.PlainAdmin.Data;
 
public class TimeLineItem
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Position { get; set; } = string.Empty;
    [Required]
    public string Local { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
    [Required]
    public string Icon { get; set; } = string.Empty;
}

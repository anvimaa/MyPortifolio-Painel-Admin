using System.ComponentModel.DataAnnotations;

namespace Templates.PlainAdmin.Data;

public class CertificacaoItem
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Image { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
}

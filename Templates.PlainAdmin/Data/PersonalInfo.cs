using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Templates.PlainAdmin.Data;

public class PersonalInfo
{
    public int Id { get; set; }

    [DisplayName("Primeiro Nome")]
    [Required(ErrorMessage ="Primeiro Nome obrigatório"), MinLength(2),MaxLength(50)]
    public string? FirstName { get; set; }

    [DisplayName("Segundo Nome")]
    [Required(ErrorMessage = "Segundo Nome obrigatório"), MinLength(2), MaxLength(50)]
    public string? LastName { get; set; }

    [DisplayName("Profissão")]
    [Required(ErrorMessage = "Profissão obrigatório"), MinLength(2), MaxLength(150)]
    public string? Carrer { get; set; } 

    [DisplayName("Breve descrição")]
    [Required(ErrorMessage = "Breve descrição obrigatório"), MinLength(50), MaxLength(250)]
    public string? Intro { get; set; } 

    [DisplayName("Descrição")]
    [Required(ErrorMessage = "Descrição obrigatório"), MinLength(50)]
    public string? Description { get; set; }
}

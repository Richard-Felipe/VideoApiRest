using System.ComponentModel.DataAnnotations;

namespace ApiRest.Data.Dtos;

public class UpdateVideoDto
{
    [Required]
    [StringLength(300, MinimumLength = 1, ErrorMessage = "O campo é obrigatório e deve conter entre 1 a 300 caracteres")]
    public string Titulo { get; set; }

    [Required]
    [StringLength(450, MinimumLength = 1, ErrorMessage = "O campo é obrigatório e deve conter entre 1 a 450 caracteres")]
    public string descricao { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "O campo é obrigatório e deve conter entre 1 a 100 caracteres")]
    public string URL { get; set; }
}

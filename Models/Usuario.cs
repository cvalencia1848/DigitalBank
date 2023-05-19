using System.ComponentModel.DataAnnotations;

namespace Models;

public partial class Usuario
{
    public int? Id { get; set; }
    [Required(ErrorMessage = "Este campo es requerido")]
    [MaxLength(100, ErrorMessage = "Este campo supera los 100 caracteres")]
    public string? Nombre { get; set; }
    [Required(ErrorMessage = "Este campo es requerido")]
    public DateTime? FechaNacimiento { get; set; }
    [Required(ErrorMessage = "Este campo es requerido")]
    [MaxLength(1)]
    public string? Sexo { get; set; }
}

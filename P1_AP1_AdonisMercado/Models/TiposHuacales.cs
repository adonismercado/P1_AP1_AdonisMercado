using System.ComponentModel.DataAnnotations;
namespace P1_AP1_AdonisMercado.Models;

public class TiposHuacales
{
    [Key]
    public int TipoId { get; set; }

    [Required(ErrorMessage = "Error: La descripcion es obligatoria.")]
    public string Descripcion { get; set; }

    public int Existencia { get; set; }

}

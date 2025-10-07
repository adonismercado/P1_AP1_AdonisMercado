using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace P1_AP1_AdonisMercado.Models;

public class TiposHuacales
{
    [Key]
    public int TipoId { get; set; }

    [Required(ErrorMessage = "Error: La descripcion es obligatoria.")]
    public string Descripcion { get; set; }

    public int Existencia { get; set; }

    [ForeignKey("DetalleId")]
    [InverseProperty("TiposHuacales")]
    public virtual TiposHuacales TipoHuacal { get; set; }
}

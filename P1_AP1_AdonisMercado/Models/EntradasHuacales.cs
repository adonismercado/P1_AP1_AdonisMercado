using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace P1_AP1_AdonisMercado.Models;

public class EntradasHuacales
{
    [Key]
    public int IdEntrada { get; set; }

    [Required(ErrorMessage = "Error: La fecha es obligatoria.")]
    public DateTime Fecha { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Error: El nombre del cliente es obligatorio.")]
    public string NombreCliente { get; set; }

    [Required(ErrorMessage = "Error: La cantidad es obligatoria.")]
    public int Cantidad { get; set; }

    [Required(ErrorMessage = "Error: El precio es obligatorio.")]
    public int Precio { get; set; }
}


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

    [Range(1, int.MaxValue, ErrorMessage = "Error: La cantidad debe ser mayor a 1.")]
    public int Cantidad { get; set; }

    [Range(1, double.MaxValue, ErrorMessage = "Error: El precio debe ser mayor a 1.")]
    public decimal Precio { get; set; }
}


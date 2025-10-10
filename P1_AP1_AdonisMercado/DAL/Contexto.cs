using Microsoft.EntityFrameworkCore;
using P1_AP1_AdonisMercado.Models;
namespace P1_AP1_AdonisMercado.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<EntradasHuacales> EntradasHuacales { get; set; }
    public DbSet<EntradasHuacalesDetalle> EntradasHuacalesDetalles { get; set; }
    public DbSet<TiposHuacales> TiposHuacales { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TiposHuacales>().HasData(
            new List<TiposHuacales>()
            {
                new()
                {
                    TipoId = 1,
                    Descripcion = "Huacal Verde Tamaño Pequeña",
                    Existencia = 0,
                },
                new()
                {
                    TipoId = 2,
                    Descripcion = "Huacal Verde Tamaño Mediana",
                    Existencia = 0,
                },
                new()
                {
                    TipoId = 3,
                    Descripcion = "Huacal Verde Tamaño Jumbo",
                    Existencia = 0,
                },
                new()
                {
                    TipoId = 4,
                    Descripcion = "Huacal Rojo Tamaño Pequeña",
                    Existencia = 0,
                },
                new()
                {
                    TipoId = 5,
                    Descripcion = "Huacalo Rojo Tamaño Mediana",
                    Existencia = 0,
                },
                new()
                {
                    TipoId = 6,
                    Descripcion = "Huacal Rojo Tamaño Jumbo",
                    Existencia = 0,
                }
            }
        );
        base.OnModelCreating(modelBuilder);
    }

}


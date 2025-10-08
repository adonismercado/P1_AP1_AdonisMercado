using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using P1_AP1_AdonisMercado.DAL;
using P1_AP1_AdonisMercado.Models;
using System.Linq.Expressions;

namespace P1_AP1_AdonisMercado.Services;

public class EntradaHuacalesService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<List<EntradasHuacales>> Listar(Expression<Func<EntradasHuacales, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradasHuacales
            .Include(e => e.EntradasHuacalesDetalles)
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<bool> Insertar(EntradasHuacales entradasHuacales)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.EntradasHuacales.Add(entradasHuacales);
        await AfectarEntradasHuacales(entradasHuacales.EntradasHuacalesDetalles.ToArray(), TipoOperacion.Suma);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task AfectarEntradasHuacales(EntradasHuacalesDetalle[] detalle, TipoOperacion tipoOperacion)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        foreach (var item in detalle)
        {
            var tipoHuacal = await contexto.TiposHuacales
                .SingleAsync(t => t.TipoId == item.TipoId);

            if (tipoOperacion == TipoOperacion.Suma)
            {
                tipoHuacal.Existencia += item.Cantidad;
            }
            else if (tipoOperacion == TipoOperacion.Resta)
            {
                tipoHuacal.Existencia -= item.Cantidad;
            }
        }
    }

    public async Task<bool> Modificar(EntradasHuacales entradasHuacales)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        var entradaAnterior = await contexto.EntradasHuacales
            .Include(e => e.EntradasHuacalesDetalles)
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.IdEntrada == entradasHuacales.IdEntrada);
        
        // Restar entrada original
        foreach (var item in entradaAnterior.EntradasHuacalesDetalles)
        {
            var tipoHuacal = await contexto.TiposHuacales
                .FirstOrDefaultAsync(t => t.TipoId == item.TipoId);

            if (tipoHuacal != null)
            {
                tipoHuacal.Existencia -= item.Cantidad;
            }
        }

        // Aplicar nueva entrada
        foreach (var item in entradasHuacales.EntradasHuacalesDetalles)
        {
            var tipoHuacal = await contexto.TiposHuacales
                .FirstOrDefaultAsync(t => t.TipoId == item.TipoId);

            if (tipoHuacal != null)
            {
                tipoHuacal.Existencia += item.Cantidad;
            }
        }
        
        // Actualizar entrada principal
        contexto.EntradasHuacales.Update(entradasHuacales);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Existe(int idEntrada)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradasHuacales
            .AnyAsync(e => e.IdEntrada == idEntrada);
    }

    public async Task<bool> Guardar(EntradasHuacales entradasHuacales)
    {
        if (!await Existe(entradasHuacales.IdEntrada))
        {
            return await Insertar(entradasHuacales);
        }
        else
        {
            return await Modificar(entradasHuacales);
        }
    }

    public async Task<EntradasHuacales?> Buscar(int idEntrada)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradasHuacales
            .Include(e => e.EntradasHuacalesDetalles)
            .FirstOrDefaultAsync(e => e.IdEntrada == idEntrada);
    }

    public async Task<bool> Eliminar(int idEntrada)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradasHuacales
            .AsNoTracking()
            .Where(e => e.IdEntrada == idEntrada)
            .ExecuteDeleteAsync() > 0;
    }

    public enum TipoOperacion
    { 
        Suma = 1,
        Resta = 2
    }

}


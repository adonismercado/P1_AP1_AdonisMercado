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
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<bool> Insertar(EntradasHuacales entradasHuacales)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.EntradasHuacales.Add(entradasHuacales);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(EntradasHuacales entradasHuacales)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
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

    public async Task<EntradasHuacales> Buscar(int idEntrada)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradasHuacales
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
}


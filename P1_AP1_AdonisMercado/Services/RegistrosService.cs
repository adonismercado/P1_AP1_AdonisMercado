﻿using Microsoft.EntityFrameworkCore;
using P1_AP1_AdonisMercado.DAL;
using P1_AP1_AdonisMercado.Models;
using System.Linq.Expressions;

namespace P1_AP1_AdonisMercado.Services;

public class RegistrosService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<List<Registros>> Listar(Expression<Func<Registros, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Registros
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }
}


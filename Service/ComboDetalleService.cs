using LiamellCruz_Ap1_P2.DAL;
using LiamellCruz_Ap1_P2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LiamellCruz_Ap1_P2.Service;

public class ComboDetalleService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<List<Articulo>> Listar(Expression<Func<Articulo, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Articulo
        .AsNoTracking()
        .Where(criterio)
        .ToListAsync();
    }
}

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

    public async Task<bool> Eliminar(int detalleId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var detalle = await contexto.ComboDetalle.FindAsync(detalleId);
        if (detalle != null)
        {
            await AfectarCantidad(detalle, false);
            contexto.ComboDetalle.Remove(detalle);
            await contexto.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task AfectarCantidad(ComboDetalle detalles, bool resta)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        // foreach (var item in detalles)
        // {
        var detalle = await contexto.Articulo.SingleOrDefaultAsync(d => d.ArticuloId == detalles.ArticuloId);
        if (resta)
            detalle.Existencia -= detalles.Cantidad;
        else
            detalle.Existencia += detalles.Cantidad;
        //}
        await contexto.SaveChangesAsync();
    }
}

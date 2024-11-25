using LiamellCruz_Ap1_P2.DAL;
using LiamellCruz_Ap1_P2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using static Azure.Core.HttpHeader;

namespace LiamellCruz_Ap1_P2.Service;

public class ComboService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Guardar(Combo combo)
    {
        
        if (!await Existe(combo.ComboId))
            return await Insertar(combo);
        else
            return await Modificar(combo);
    }

    public async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Combo
            .AnyAsync(c => c.ComboId == id);
    }


    private async Task<bool> Insertar(Combo combo)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        await AfectarCantidad(combo.ComboDetalle.ToArray(), true);
        contexto.Combo.Add(combo);
        return await contexto.SaveChangesAsync() > 0; ;
    }


    private async Task<bool> Modificar(Combo combo)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(combo);
        var modificado = await contexto.SaveChangesAsync() > 0;
        contexto.Entry(combo).State = EntityState.Modified;
        return modificado;
    }


    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var combo = contexto.Combo.Find(id);
        if (combo == null)
            return false;


        await AfectarCantidad(combo.ComboDetalle.ToArray(), false);
        return await contexto.Combo
            .Include(c => c.ComboDetalle)
            .Where(c => c.ComboId == combo.ComboId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task AfectarCantidad(ComboDetalle[] detalles, bool resta)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        foreach (var item in detalles)
        {
            var detalle = await contexto.ComboDetalle.SingleAsync(d => d.DetalleId == item.DetalleId);
            if (resta)
                detalle.Cantidad -= item.Cantidad;
            else
                detalle.Cantidad += item.Cantidad;
        }
        await contexto.SaveChangesAsync();
    }

    public async Task<Combo> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Combo
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.ComboId == id);

    }

    public async Task<List<Combo>> Listar(Expression<Func<Combo, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Combo
        .Include(c => c.ComboDetalle)
        .AsNoTracking()
        .Where(criterio)
        .ToListAsync();
    }

}



using LiamellCruz_Ap1_P2.DAL;
using LiamellCruz_Ap1_P2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LiamellCruz_Ap1_P2.Service;

public class ComboService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Guardar(Combo combo)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        if (!await Existe(combo.ComboId))
            return await Insertar(combo);
        else
            return await Modificar(combo);
    }

    private async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Combo
            .AnyAsync(c => c.ComboId == id);
    }

    private async Task<bool> Insertar(Combo combo)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Combo.Add(combo);
        return await contexto.SaveChangesAsync() > 0;
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
        return await contexto.Combo
           .AsNoTracking()
           .Where(c => c.ComboId == id)
           .ExecuteDeleteAsync() > 0;
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
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();




    }
}





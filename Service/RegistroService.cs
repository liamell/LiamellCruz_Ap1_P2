using LiamellCruz_Ap1_P2.DAL;
using LiamellCruz_Ap1_P2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LiamellCruz_Ap1_P2.Service;

public class RegistroService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Guardar(Registro registro)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return false;
    }

    private async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return false;
    }

    private async Task<bool> Insertar(Registro registro)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return false;
    }

    private async Task<bool> Modificar(Registro registro)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return false;
    }

   
    public async Task<bool> Eliminar(Registro registro)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return false;
    }

    public async Task<Registro> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return default;
        
    }

    public async Task<List<Registro>> Listar(Expression<Func<Registro, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return new List<Registro>();

    }



}

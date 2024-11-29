using LiamellCruz_Ap1_P2.DAL;
using LiamellCruz_Ap1_P2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using static Azure.Core.HttpHeader;

namespace LiamellCruz_Ap1_P2.Service;

public class ComboService(IDbContextFactory<Contexto> DbFactory)
{
   
        public async Task<bool> Existe(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Combo.AnyAsync(c => c.ComboId == id);
        }

        private async Task<bool> Insertar(Combo combo)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();

            
            foreach (var detalle in combo.ComboDetalle)
            {
                detalle.Articulo.ArticuloId = 0; 
            }

            await AfectarCantidad(combo.ComboDetalle.ToArray(), true);
            contexto.Combo.Add(combo);
            return await contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Combo combo)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();

            var comboOriginal = await contexto.Combo
                .Include(c => c.ComboDetalle)
                .FirstOrDefaultAsync(t => t.ComboId == combo.ComboId);

            if (comboOriginal == null)
                return false;

            await AfectarCantidad(comboOriginal.ComboDetalle.ToArray(), false);

            foreach (var detalleOriginal in comboOriginal.ComboDetalle)
            {
                if (!combo.ComboDetalle.Any(d => d.DetalleId == detalleOriginal.DetalleId))
                {
                    contexto.ComboDetalle.Remove(detalleOriginal);
                }
            }

            await AfectarCantidad(combo.ComboDetalle.ToArray(), true);

            contexto.Entry(comboOriginal).CurrentValues.SetValues(combo);

            foreach (var detalle in combo.ComboDetalle)
            {
                var detalleExistente = comboOriginal.ComboDetalle
                    .FirstOrDefault(d => d.DetalleId == detalle.DetalleId);

                if (detalleExistente != null)
                {
                    contexto.Entry(detalleExistente).CurrentValues.SetValues(detalle);
                }
                else
                {
                    comboOriginal.ComboDetalle.Add(detalle);
                }
            }

            return await contexto.SaveChangesAsync() > 0;
        }
        


        public async Task<bool> Guardar(Combo combo)
        {
            if (!await Existe(combo.ComboId))
            {
                return await Insertar(combo);
            }
            else
            {
                return await Modificar(combo);
            }
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

        public async Task<Combo> Buscar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Combo
            .Include(c => c.ComboDetalle)
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

        

        public async Task AfectarCantidad(ComboDetalle[] detalles, bool resta)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            foreach (var item in detalles)
            {
                var detalle = await contexto.Articulo.SingleOrDefaultAsync(a => a.ArticuloId == item.ArticuloId);
                if (resta)
                    detalle.Existencia -= item.Cantidad;
                else
                    detalle.Existencia += item.Cantidad;
            }
            await contexto.SaveChangesAsync();
        }

        
}



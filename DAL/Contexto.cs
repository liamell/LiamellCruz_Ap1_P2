using LiamellCruz_Ap1_P2.Models;
using Microsoft.EntityFrameworkCore;

namespace LiamellCruz_Ap1_P2.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }


    public DbSet<Combo> Combo { get; set; }
    public DbSet<ComboDetalle> ComboDetalle{ get; set; }
    public DbSet<Articulo> Articulo { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Articulo>().HasData(new List<Articulo>()
        {
            new Articulo() {ArticuloId = 1, Descripcion = "Mouse", Precio = 5000, Costo = 300,Existencia = 10},
            new Articulo() {ArticuloId = 2, Descripcion = "Cable", Precio = 500, Costo = 300, Existencia = 5},
            new Articulo() {ArticuloId = 3, Descripcion = "Pantalla", Precio = 750, Costo = 300, Existencia = 09 }
        });
    }







}
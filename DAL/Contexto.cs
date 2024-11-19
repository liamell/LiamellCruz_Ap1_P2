using LiamellCruz_Ap1_P2.Models;
using Microsoft.EntityFrameworkCore;

namespace LiamellCruz_Ap1_P2.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }


    public DbSet<Combo> Combo { get; set; }
    public DbSet<ComboDetalle> ComboDetalle{ get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Combo>().HasData(new List<Combo>()
        {
            new Combo() {ComboId = 1,Descripcion = "Mouse", Precio = 5000},
            new Combo() {ComboId = 2,Descripcion = "Cable", Precio = 500},
            new Combo() {ComboId = 3,Descripcion = "Pantalla", Precio = 750}
        });
    }







}
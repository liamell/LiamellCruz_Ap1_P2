using LiamellCruz_Ap1_P2.Models;
using Microsoft.EntityFrameworkCore;

namespace LiamellCruz_Ap1_P2.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }


    public DbSet<Registro> Registro { get; set; }
}

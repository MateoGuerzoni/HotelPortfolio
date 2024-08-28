using LogicaAccesoDatos.EF.Config;
using LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;


namespace LogicaAccesoDatos.EF
{
    public class HotelContext : DbContext
    {

        public DbSet<Cabania> Cabanias { get; set; }
        public DbSet<Mantenimiento> Mantenimientos { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


        public HotelContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //
            modelBuilder.ApplyConfiguration(new MantenimientoConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }
}

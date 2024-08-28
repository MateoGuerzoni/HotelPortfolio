using LogicaNegocio.Entidades;
using LogicaNegocio.IntefacesDominio;
using LogicaNegocio.Vo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.EF.Config
{
    internal class MantenimientoConfiguration : IEntityTypeConfiguration<Mantenimiento>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Mantenimiento> builder)
        {
       
             builder.OwnsOne(m => m.Fecha).Property(fecha => fecha.Value).HasColumnName("Fecha");
            builder.OwnsOne(m => m.Descripcion).Property(desc => desc.Value).HasColumnName("Descripcion");
            builder.OwnsOne(m => m.Costo).Property(costo => costo.Value).HasColumnName("Costo");
            builder.OwnsOne(m => m.NombreFuncionario).Property(nombre => nombre.Value).HasColumnName("NombreFuncionario");



        //  builder.ToTable("pepito");
        // builder.Property(x => x.Nacionalidad).HasMaxLength(10).IsRequired();
        // builder.HasIndex(x => x.Nacionalidad).IsUnique();
        // builder.HasQueryFilter(x => x.Nacionalidad == "argentina");
        //throw new NotImplementedException();
    }
    }
}

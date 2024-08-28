﻿// <auto-generated />
using System;
using LogicaAccesoDatos.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    [DbContext(typeof(HotelContext))]
    [Migration("20230621231435_mant")]
    partial class mant
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LogicaNegocio.Entidades.Cabania", b =>
                {
                    b.Property<int>("numHabitacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("numHabitacion"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxHuespedes")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TieneJacuzzi")
                        .HasColumnType("bit");

                    b.Property<int>("TipoId")
                        .HasColumnType("int");

                    b.HasKey("numHabitacion");

                    b.HasIndex("TipoId");

                    b.ToTable("Cabanias");
                });

            modelBuilder.Entity("LogicaNegocio.Entidades.Mantenimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CabaniaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CabaniaId");

                    b.ToTable("Mantenimientos");
                });

            modelBuilder.Entity("LogicaNegocio.Entidades.Tipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("CostoPorHuesped")
                        .HasColumnType("float");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tipos");
                });

            modelBuilder.Entity("LogicaNegocio.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("LogicaNegocio.Entidades.Cabania", b =>
                {
                    b.HasOne("LogicaNegocio.Entidades.Tipo", "Tipo")
                        .WithMany()
                        .HasForeignKey("TipoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tipo");
                });

            modelBuilder.Entity("LogicaNegocio.Entidades.Mantenimiento", b =>
                {
                    b.HasOne("LogicaNegocio.Entidades.Cabania", "CabaniaRealizada")
                        .WithMany()
                        .HasForeignKey("CabaniaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("LogicaNegocio.Vo.Costo", "Costo", b1 =>
                        {
                            b1.Property<int>("MantenimientoId")
                                .HasColumnType("int");

                            b1.Property<double>("Value")
                                .HasColumnType("float")
                                .HasColumnName("Costo");

                            b1.HasKey("MantenimientoId");

                            b1.ToTable("Mantenimientos");

                            b1.WithOwner()
                                .HasForeignKey("MantenimientoId");
                        });

                    b.OwnsOne("LogicaNegocio.Vo.Descripcion", "Descripcion", b1 =>
                        {
                            b1.Property<int>("MantenimientoId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Descripcion");

                            b1.HasKey("MantenimientoId");

                            b1.ToTable("Mantenimientos");

                            b1.WithOwner()
                                .HasForeignKey("MantenimientoId");
                        });

                    b.OwnsOne("LogicaNegocio.Vo.Fecha", "Fecha", b1 =>
                        {
                            b1.Property<int>("MantenimientoId")
                                .HasColumnType("int");

                            b1.Property<DateTime>("Value")
                                .HasColumnType("datetime2")
                                .HasColumnName("Fecha");

                            b1.HasKey("MantenimientoId");

                            b1.ToTable("Mantenimientos");

                            b1.WithOwner()
                                .HasForeignKey("MantenimientoId");
                        });

                    b.OwnsOne("LogicaNegocio.Vo.Nombre", "NombreFuncionario", b1 =>
                        {
                            b1.Property<int>("MantenimientoId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("NombreFuncionario");

                            b1.HasKey("MantenimientoId");

                            b1.ToTable("Mantenimientos");

                            b1.WithOwner()
                                .HasForeignKey("MantenimientoId");
                        });

                    b.Navigation("CabaniaRealizada");

                    b.Navigation("Costo")
                        .IsRequired();

                    b.Navigation("Descripcion")
                        .IsRequired();

                    b.Navigation("Fecha")
                        .IsRequired();

                    b.Navigation("NombreFuncionario")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

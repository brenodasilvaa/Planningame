﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Planningame_Insfrastructure;

#nullable disable

namespace Planningame_Insfrastructure.Migrations
{
    [DbContext(typeof(PlanningameDbContext))]
    [Migration("20241109024014_numeroAutoIncrement")]
    partial class numeroAutoIncrement
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("JogadorRodada", b =>
                {
                    b.Property<Guid>("JogadoresId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RodadasId")
                        .HasColumnType("uuid");

                    b.HasKey("JogadoresId", "RodadasId");

                    b.HasIndex("RodadasId");

                    b.ToTable("JogadorRodada");
                });

            modelBuilder.Entity("Planningame_Domain.Entidades.Jogador", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<Guid>("PartidaId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PartidaId");

                    b.ToTable("Jogadores");
                });

            modelBuilder.Entity("Planningame_Domain.Entidades.Partida", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.HasKey("Id");

                    b.ToTable("Partidas");
                });

            modelBuilder.Entity("Planningame_Domain.Entidades.Rodada", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Numero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Numero"));

                    b.Property<Guid>("PartidaId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PartidaId");

                    b.ToTable("Rodadas");
                });

            modelBuilder.Entity("JogadorRodada", b =>
                {
                    b.HasOne("Planningame_Domain.Entidades.Jogador", null)
                        .WithMany()
                        .HasForeignKey("JogadoresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Planningame_Domain.Entidades.Rodada", null)
                        .WithMany()
                        .HasForeignKey("RodadasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Planningame_Domain.Entidades.Jogador", b =>
                {
                    b.HasOne("Planningame_Domain.Entidades.Partida", "Partida")
                        .WithMany("Jogadores")
                        .HasForeignKey("PartidaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Partida");
                });

            modelBuilder.Entity("Planningame_Domain.Entidades.Rodada", b =>
                {
                    b.HasOne("Planningame_Domain.Entidades.Partida", "Partida")
                        .WithMany("Rodadas")
                        .HasForeignKey("PartidaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Partida");
                });

            modelBuilder.Entity("Planningame_Domain.Entidades.Partida", b =>
                {
                    b.Navigation("Jogadores");

                    b.Navigation("Rodadas");
                });
#pragma warning restore 612, 618
        }
    }
}

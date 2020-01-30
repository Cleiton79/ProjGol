﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TesteGolCleiton.Models;

namespace TesteGolCleiton.Migrations
{
    [DbContext(typeof(AirplaneDbContext))]
    [Migration("20200130020037_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TesteGolCleiton.Models.Airplanes", b =>
                {
                    b.Property<string>("Modelo")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CodAviao");

                    b.Property<DateTime>("DataCriacao");

                    b.Property<int>("QtdePsg");

                    b.HasKey("Modelo");

                    b.ToTable("Airplane");
                });
#pragma warning restore 612, 618
        }
    }
}

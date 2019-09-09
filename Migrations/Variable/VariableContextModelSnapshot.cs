﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Smartsafe.Models;

namespace Smartsafe.Migrations.Variable
{
    [DbContext(typeof(VariableContext))]
    partial class VariableContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("Smartsafe.Models.Variable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("SignedIn");

                    b.HasKey("Id");

                    b.ToTable("Variable");
                });
#pragma warning restore 612, 618
        }
    }
}

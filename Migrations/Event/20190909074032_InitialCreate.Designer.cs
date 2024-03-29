﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Smartsafe.Models;

namespace Smartsafe.Migrations.Event
{
    [DbContext(typeof(EventContext))]
    [Migration("20190909074032_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("Smartsafe.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Criticite");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<string>("Source");

                    b.HasKey("Id");

                    b.ToTable("Event");
                });

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

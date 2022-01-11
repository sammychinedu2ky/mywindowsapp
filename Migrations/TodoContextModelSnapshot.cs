﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using todo.Data;

#nullable disable

namespace todo.Migrations
{
    [DbContext(typeof(TodoContext))]
    partial class TodoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("todo.Model.Todo", b =>
                {
                    b.Property<string>("TodoId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsCompleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("Task")
                        .IsRequired()
                        .HasColumnType("ntext");

                    b.HasKey("TodoId");

                    b.ToTable("Todos", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheLudoGameEngine;

namespace TheLudoGameEngine.Migrations
{
    [DbContext(typeof(LudoContext))]
    [Migration("20200405101511_updateGameTabel")]
    partial class updateGameTabel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TheLudoGameEngine.Game", b =>
                {
                    b.Property<int>("GameID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Finished")
                        .HasColumnType("bit");

                    b.Property<string>("GameName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastSaved")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("SMALLDATETIME")
                        .HasDefaultValueSql("SYSDATETIME()");

                    b.Property<int>("PlayerTurn")
                        .HasColumnType("int");

                    b.Property<int>("Round")
                        .HasColumnType("int");

                    b.HasKey("GameID");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("TheLudoGameEngine.Player", b =>
                {
                    b.Property<int>("PlayerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GameID")
                        .HasColumnType("int");

                    b.Property<string>("PlayerColor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlayerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Winner")
                        .HasColumnType("bit");

                    b.HasKey("PlayerID");

                    b.HasIndex("GameID");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("TheLudoGameEngine.Token", b =>
                {
                    b.Property<int>("TokenID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GameBoardPosition")
                        .HasColumnType("int");

                    b.Property<bool>("InGoal")
                        .HasColumnType("bit");

                    b.Property<bool>("InNest")
                        .HasColumnType("bit");

                    b.Property<int>("PlayerID")
                        .HasColumnType("int");

                    b.Property<string>("TokenColor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TokenNumber")
                        .HasColumnType("int");

                    b.HasKey("TokenID");

                    b.HasIndex("PlayerID");

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("TheLudoGameEngine.Player", b =>
                {
                    b.HasOne("TheLudoGameEngine.Game", "Game")
                        .WithMany("Players")
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TheLudoGameEngine.Token", b =>
                {
                    b.HasOne("TheLudoGameEngine.Player", "Player")
                        .WithMany("Tokens")
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

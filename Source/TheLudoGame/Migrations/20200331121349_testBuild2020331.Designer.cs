﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheLudoGame.Classes;

namespace TheLudoGame.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20200331121349_testBuild2020331")]
    partial class testBuild2020331
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TheLudoGame.Game", b =>
                {
                    b.Property<int>("GameID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Finished")
                        .HasColumnType("bit");

                    b.HasKey("GameID");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("TheLudoGame.Player", b =>
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

                    b.HasKey("PlayerID");

                    b.HasIndex("GameID");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("TheLudoGame.Token", b =>
                {
                    b.Property<int>("TokenID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AtEndLine")
                        .HasColumnType("bit");

                    b.Property<int>("EndLinePosition")
                        .HasColumnType("int");

                    b.Property<int>("GameBoardPosition")
                        .HasColumnType("int");

                    b.Property<bool>("InGoal")
                        .HasColumnType("bit");

                    b.Property<int>("PlayerID")
                        .HasColumnType("int");

                    b.HasKey("TokenID");

                    b.HasIndex("PlayerID");

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("TheLudoGame.Player", b =>
                {
                    b.HasOne("TheLudoGame.Game", "Game")
                        .WithMany("Players")
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TheLudoGame.Token", b =>
                {
                    b.HasOne("TheLudoGame.Player", "Player")
                        .WithMany("Tokens")
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

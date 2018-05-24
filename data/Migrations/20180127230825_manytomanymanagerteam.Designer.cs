﻿// <auto-generated />
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace data.Migrations
{
    [DbContext(typeof(TeamContext))]
    [Migration("20180127230825_manytomanymanagerteam")]
    partial class manytomanymanagerteam
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("Domain.Manager", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CurrentTeamId");

                    b.HasKey("Id");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("Domain.ManagerTeamHistory", b =>
                {
                    b.Property<Guid>("ManagerId");

                    b.Property<Guid>("TeamId");

                    b.HasKey("ManagerId", "TeamId");

                    b.ToTable("ManagerTeamHistory");
                });

            modelBuilder.Entity("Domain.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("HomeStadium");

                    b.Property<Guid?>("ManagerId");

                    b.Property<string>("Nickname");

                    b.Property<string>("TeamName");

                    b.Property<string>("YearFounded");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("Domain.Manager", b =>
                {
                    b.OwnsOne("SharedKernel.PersonFullName", "NameFactory", b1 =>
                        {
                            b1.Property<Guid?>("ManagerId");

                            b1.Property<string>("First");

                            b1.Property<string>("Last");

                            b1.ToTable("Managers");

                            b1.HasOne("Domain.Manager")
                                .WithOne("NameFactory")
                                .HasForeignKey("SharedKernel.PersonFullName", "ManagerId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Domain.ManagerTeamHistory", b =>
                {
                    b.HasOne("Domain.Manager")
                        .WithMany("PastTeams")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Team", b =>
                {
                    b.HasOne("Domain.Manager", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId");
                });

            modelBuilder.Entity("Player", b =>
                {
                    b.HasOne("Domain.Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId");

                    b.OwnsOne("SharedKernel.PersonFullName", "NameFactory", b1 =>
                        {
                            b1.Property<Guid>("PlayerId");

                            b1.Property<string>("First");

                            b1.Property<string>("Last");

                            b1.ToTable("Player");

                            b1.HasOne("Player")
                                .WithOne("NameFactory")
                                .HasForeignKey("SharedKernel.PersonFullName", "PlayerId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

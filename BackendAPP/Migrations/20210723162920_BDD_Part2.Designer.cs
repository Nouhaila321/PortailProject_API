﻿// <auto-generated />
using System;
using BackendAPP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BackendAPP.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210723162920_BDD_Part2")]
    partial class BDD_Part2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("BackendAPP.Models.Client", b =>
                {
                    b.Property<long>("Id_Client")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nom_Client")
                        .HasColumnType("TEXT");

                    b.Property<string>("Presentation")
                        .HasColumnType("TEXT");

                    b.HasKey("Id_Client");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("BackendAPP.Models.ClientThematique", b =>
                {
                    b.Property<long>("Id_Client")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Id_Thematique")
                        .HasColumnType("TEXT");

                    b.HasKey("Id_Client", "Id_Thematique");

                    b.ToTable("ClientThematique");
                });

            modelBuilder.Entity("BackendAPP.Models.Collaborateur", b =>
                {
                    b.Property<string>("Id_Collaborateur")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nom")
                        .HasColumnType("TEXT");

                    b.Property<string>("Photo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Prenom")
                        .HasColumnType("TEXT");

                    b.HasKey("Id_Collaborateur");

                    b.ToTable("Collaborateur");
                });

            modelBuilder.Entity("BackendAPP.Models.CollaborateurActivite", b =>
                {
                    b.Property<string>("Id_Projet")
                        .HasColumnType("TEXT");

                    b.Property<string>("Id_Collaborateur")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.HasKey("Id_Projet", "Id_Collaborateur");

                    b.ToTable("CollaborateurActivite");
                });

            modelBuilder.Entity("BackendAPP.Models.CollaborateurTechnologie", b =>
                {
                    b.Property<string>("Id_Collaborateur")
                        .HasColumnType("TEXT");

                    b.Property<long>("Id_Technologie")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Niveau")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id_Collaborateur", "Id_Technologie");

                    b.ToTable("CollaborateurTechnologie");
                });

            modelBuilder.Entity("BackendAPP.Models.CollaborateurThematique", b =>
                {
                    b.Property<long>("Id_Thematique")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Id_Collaborateur")
                        .HasColumnType("TEXT");

                    b.HasKey("Id_Thematique", "Id_Collaborateur");

                    b.ToTable("CollaborateurThematique");
                });

            modelBuilder.Entity("BackendAPP.Models.ImageGalerie", b =>
                {
                    b.Property<long>("Id_Image")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Chemin")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("Id_Projet")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Ordre")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Titre")
                        .HasColumnType("TEXT");

                    b.HasKey("Id_Image");

                    b.ToTable("ImageGalerie");
                });

            modelBuilder.Entity("BackendAPP.Models.Pole", b =>
                {
                    b.Property<long>("Id_Pole")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nom_Pole")
                        .HasColumnType("TEXT");

                    b.HasKey("Id_Pole");

                    b.ToTable("Pole");
                });

            modelBuilder.Entity("BackendAPP.Models.Projet", b =>
                {
                    b.Property<string>("Id_Projet")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Domaine")
                        .HasColumnType("TEXT");

                    b.Property<string>("EM")
                        .HasColumnType("TEXT");

                    b.Property<int>("Id_Client")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Id_Pole")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Libelle")
                        .HasColumnType("TEXT");

                    b.Property<string>("Statut")
                        .HasColumnType("TEXT");

                    b.HasKey("Id_Projet");

                    b.ToTable("Projet");
                });

            modelBuilder.Entity("BackendAPP.Models.ProjetTechnologie", b =>
                {
                    b.Property<int>("Id_Projet")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Id_Technologie")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id_Projet", "Id_Technologie");

                    b.ToTable("ProjetTechnologie");
                });

            modelBuilder.Entity("BackendAPP.Models.Technologie", b =>
                {
                    b.Property<long>("Id_Techno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Libelle")
                        .HasColumnType("TEXT");

                    b.HasKey("Id_Techno");

                    b.ToTable("Technologie");
                });

            modelBuilder.Entity("BackendAPP.Models.Thematique", b =>
                {
                    b.Property<long>("Id_Thematique")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<string>("Libelle")
                        .HasColumnType("TEXT");

                    b.HasKey("Id_Thematique");

                    b.ToTable("Thematique");
                });
#pragma warning restore 612, 618
        }
    }
}

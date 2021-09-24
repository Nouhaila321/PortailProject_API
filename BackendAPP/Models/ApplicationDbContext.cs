using System;
using Microsoft.EntityFrameworkCore;
using BackendAPP.Models;

namespace BackendAPP.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Client> Client { get; set; }
        public DbSet<ClientThematique> ClientThematique { get; set; }

        public DbSet<Collaborateur> Collaborateur { get; set; }
        public DbSet<CollaborateurActivite> CollaborateurActivite { get; set; }
        public DbSet<CollaborateurThematique> CollaborateurThematique { get; set; }
        public DbSet<CollaborateurTechnologie> CollaborateurTechnologie { get; set; }

        public DbSet<Pole> Pole { get; set; }
        public DbSet<Projet> Projet { get; set; }
        public DbSet<ProjetGalerie> ProjetGalerie { get; set; }
        public DbSet<ProjetTechnologie> ProjetTechnologie { get; set; }
        public DbSet<ProjetThematique> ProjetThematique { get; set; }
        
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Portail_projets.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientThematique>()
                .HasKey(p => new { p.Id_Client, p.Id_Thematique });

            modelBuilder.Entity<CollaborateurTechnologie>()
                .HasKey(p => new { p.Id_Collaborateur, p.Id_Technologie });

            modelBuilder.Entity<CollaborateurActivite>()
                .HasKey(p => new { p.Id_Projet, p.Id_Collaborateur });

            modelBuilder.Entity<CollaborateurThematique>()
                .HasKey(p => new { p.Id_Thematique, p.Id_Collaborateur });

            modelBuilder.Entity<Projet>()
                .HasKey(p => new { p.Id_Projet , p.Id_Client});

            modelBuilder.Entity<ProjetTechnologie>()
                .HasKey(p => new { p.id_projet, p.id_client, p.id_technologie });

            modelBuilder.Entity<ProjetThematique>()
                .HasKey(p => new { p.id_projet, p.id_client, p.id_thematique });

            modelBuilder.Entity<ProjetGalerie>()
                .HasKey(p => new {  p.Id_Projet ,p.id_client, p.Id_Image });


        }
       
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendAPP.Models
{
    public class Projet
    {

        [Key]
        public long Id_Projet { get; set; }
        public string Libelle { get; set; }
        public string Description { get; set; }
        public string EM { get; set; }
        public string Domaine { get; set; }
        public string Statut { get; set; }

        public int Id_Pole { get; set; }
        public int Id_Client { get; set; }

    }
}
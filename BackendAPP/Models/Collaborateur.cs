using System;
using System.ComponentModel.DataAnnotations;

namespace BackendAPP.Models
{
    public class Collaborateur
    {
        [Key]
        public string Id_Collaborateur { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
    }
}
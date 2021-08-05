using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendAPP.Models
{
    public class CollaborateurActivite
    {

        
        [ForeignKey("Id_Collaborateur")]
        public string Id_Collaborateur { get; set; }

        
        [ForeignKey("Id_Projet")]
        public string Id_Projet { get; set; }

        public DateTime Date { get; set; }
       
    }
}
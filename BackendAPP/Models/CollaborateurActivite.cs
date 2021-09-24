using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendAPP.Models
{
    public class CollaborateurActivite
    {

        
        
        public string Id_Collaborateur { get; set; }
        
        public string Id_Projet { get; set; }

        public double Days { get; set; }
       
    }
}
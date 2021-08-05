using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendAPP.Models
{
    public class CollaborateurTechnologie
    {

       
        [ForeignKey("Id_Collaborateur")]
        public string Id_Collaborateur { get; set; }

        
        public long Id_Technologie { get; set; }

        public int Niveau { get; set; }

    }
}
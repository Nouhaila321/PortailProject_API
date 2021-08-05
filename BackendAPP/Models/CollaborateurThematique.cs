using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendAPP.Models
{
    public class CollaborateurThematique
    {

        
        [ForeignKey("Id_Collaborateur")]
        public string Id_Collaborateur { get; set; }

      
        public long Id_Thematique { get; set; }

      

    }
}
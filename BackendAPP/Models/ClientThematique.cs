using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendAPP.Models
{
    public class ClientThematique
    {
        public long  Id_Thematique { get; set; }
        public long Id_Client { get; set; }
        public string Nom_Thematique { get; set; }
        
        
    }
}



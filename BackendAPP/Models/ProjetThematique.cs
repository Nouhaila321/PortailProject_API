using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendAPP.Models
{
    public class ProjetThematique
    {
        public long id_thematique { get; set; }
        public long id_projet { get; set; }
        public long id_client { get; set; }
        public string nom_thematique { get; set; }
        

    }
}



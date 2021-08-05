using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendAPP.Models
{
    public class ProjetTechnologie
    {
        public long id_technologie { get; set; }
        public long id_projet { get; set; }
        public long id_client { get; set; }
        public string nom_technologie { get; set; }
        public string chemin_technologie { get; set; }

    }
}
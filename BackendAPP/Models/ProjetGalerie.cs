using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendAPP.Models
{
    public class ProjetGalerie
    {
        
        public long Id_Image { get; set; }
        public long id_client { get; set; }
        public int Id_Projet { get; set; }
        public string titre { get; set; }
        public string Chemin { get; set; }
        public string Description { get; set; }
        

    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace BackendAPP.Models
{
    public class Pole
    {

        [Key]
        public long Id_Pole { get; set; }
        public string Nom_Pole { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace BackendAPP.Models
{
    public class Client
    {

        [Key]
        public long Id_Client { get; set; }
        public string Nom_Client { get; set; }
        public string Description { get; set; }


    }
}
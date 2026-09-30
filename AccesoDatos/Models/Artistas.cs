using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Models
{
    public class Artista
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";

        public List<Canciones> Canciones { get; set; } = new();
     }
}
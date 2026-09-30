using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Models
{
    public class Canciones
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = "";
        public int ArtistaId { get; set; }
        public int DuracionSegundos { get; set; } 
        public Artista? Artista { get; set; }

    }
}
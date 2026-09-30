
using AccesoDatos.Models;
using Microsoft.EntityFrameworkCore;

namespace AccesoDatos.Repositories
{
    public class CancionRepositorie : GenericRepository<Canciones>
    {
   
        public List<Canciones> ObtenerConArtista()
        {
            return _context.Canciones
                .Include(c => c.Artista)
                .ToList();
        }

        public List<Canciones> ObtenerMasLargas()
        {
            return _context.Canciones
                .Include(c => c.Artista)
                .OrderByDescending(c => c.DuracionSegundos)
                .ToList();
        }

        public int ObtenerCantidad()
        {
            return _context.Canciones.Count();
        }

        public List<Canciones> ObtenerOrdenadasPorTitulo()
        {
            return _context.Canciones
                .Include(c => c.Artista)
                .OrderBy(c => c.Titulo)
                .ToList();
        }

        public bool HayCanciones()
        {
            return _context.Canciones.Any();
        }       
    }
}
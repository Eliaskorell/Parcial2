
using AccesoDatos.Models;

namespace AccesoDatos.Repositories
{
    public class ArtistaRepository : GenericRepository<Artista>
    {
        public bool Existe(int id)
        {
            return _context.Artistas.Any(a => a.Id == id);
        }
    }
}
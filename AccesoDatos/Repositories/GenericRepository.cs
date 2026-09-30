using AccesoDatos.Data;

namespace AccesoDatos.Repositories
{
    public class GenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        public GenericRepository()
        {
            _context = new ApplicationDbContext();
        }

        public void Agregar(T entidad)
        {
            _context.Set<T>().Add(entidad);
            _context.SaveChanges();
        }

        public List<T> ObtenerTodos()
        {
            return _context.Set<T>().ToList();
        }
    }
}

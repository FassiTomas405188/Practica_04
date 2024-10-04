using Practica_04.Models;

namespace Practica_04.Repositories.Repositories_S
{
    public class ServicioRepository : IServicioRepository
    {
        private AppDbContext _context;

        public ServicioRepository(AppDbContext context) 
        {
            _context = context;
        }

        public bool Create(TServicio oServicio)
        {
            _context.TServicios.Add(oServicio);
            return _context.SaveChanges() == 1;
        } 

        public bool Delete(TServicio oServicio)
        {
            throw new NotImplementedException();
        }

        public List<TServicio> GetAll(int costo1, int costo2)
        {
            return _context.TServicios.Where(x=>x.Costo < costo1 && x.Costo > costo2 ).ToList();
        }

        public bool Update(int id)
        {
            var servicioActualizado = _context.TServicios.Find(id);
            if(servicioActualizado == null) 
            {
                servicioActualizado.Id = id;
                return _context.SaveChanges() > 0;
            }

            return false;
        }
    }
}

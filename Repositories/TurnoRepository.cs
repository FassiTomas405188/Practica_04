using Practica_04.Models;

namespace Practica_04.Repositories
{
    public class TurnoRepository : ITurnosRepository
    {
        private AppDbContext _context;

        public TurnoRepository(AppDbContext context) 
        {
            _context = context;
        }
        public bool Create(TTurno oTurno)
        {
            _context.TTurnos.Add(oTurno);
            return _context.SaveChanges() == 1;
        }

        public bool Delete(TTurno oTurno)
        {
            throw new NotImplementedException();
        }

        public List<TTurno> GetAll()
        {
            return _context.TTurnos.Where(x=> x.Fecha == null && x.Hora == null).ToList();
        }

        public bool Update(int id)
        {
            var turnoActualizado = _context.TTurnos.Find(id);
            if (turnoActualizado != null) 
            {
                turnoActualizado.Id = id;
                return _context.SaveChanges() > 0;
            }

            return false;
        }
    }
}

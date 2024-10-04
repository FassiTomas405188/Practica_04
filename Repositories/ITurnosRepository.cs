using Practica_04.Models;

namespace Practica_04.Repositories
{
    public interface ITurnosRepository
    {
        bool Create(TTurno oTurno);
        List<TTurno> GetAll();
        bool Update(int id);
        bool Delete(TTurno oTurno);
    }
}

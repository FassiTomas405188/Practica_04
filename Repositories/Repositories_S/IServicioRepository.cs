using Practica_04.Models;

namespace Practica_04.Repositories.Repositories_S
{
    public interface IServicioRepository
    {
        bool Create(TServicio oServicio);
        List<TServicio> GetAll();
        bool Update(int id);
        bool Delete(TServicio oServicio);
    }
}

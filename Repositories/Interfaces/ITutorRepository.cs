using VeterinariaAPI.Models;

namespace VeterinariaAPI.Repositories.Interfaces
{
    public interface ITutorRepository
    {
        Task<IEnumerable<Tutor>> GetAll();
        Task<Tutor> GetById(int id);
        Task<Tutor> Create(Tutor tutor);
        Task<Tutor> Update(Tutor tutor);
        Task<bool> Delete(int id);
    }
}
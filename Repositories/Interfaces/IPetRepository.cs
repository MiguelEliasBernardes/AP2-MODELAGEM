using VeterinariaAPI.Models;

namespace VeterinariaAPI.Repositories.Interfaces
{
    public interface IPetRepository
    {
        Task<IEnumerable<Pet>> GetAll();
        Task<Pet> GetById(int id);
        Task<Pet> Create(Pet pet);
        Task<Pet> Update(Pet pet);
        Task<bool> Delete(int id);
    }
}

using Microsoft.EntityFrameworkCore;
using VeterinariaAPI.Data;
using VeterinariaAPI.Models;
using VeterinariaAPI.Repositories.Interfaces;

namespace VeterinariaAPI.Repositories.Implementations
{
    public class PetRepository : IPetRepository
    {
        private readonly AppDbContext _context;

        public PetRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pet>> GetAll()
        {
            return await _context.Pets.Include(p => p.Tutor).ToListAsync();
        }

        public async Task<Pet> GetById(int id)
        {
            return await _context.Pets.Include(p => p.Tutor).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Pet> Create(Pet pet)
        {
            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();
            return pet;
        }

        public async Task<Pet> Update(Pet pet)
        {
            _context.Pets.Update(pet);
            await _context.SaveChangesAsync();
            return pet;
        }

        public async Task<bool> Delete(int id)
        {
            var pet = await _context.Pets.FindAsync(id);
            if (pet == null) return false;

            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

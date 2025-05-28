using Microsoft.EntityFrameworkCore;
using VeterinariaAPI.Data;
using VeterinariaAPI.Models;
using VeterinariaAPI.Repositories.Interfaces;

namespace VeterinariaAPI.Repositories.Implementations
{
    public class TutorRepository : ITutorRepository
    {
        private readonly AppDbContext _context;

        public TutorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tutor>> GetAll()
        {
            return await _context.Tutores.Include(t => t.Pets).ToListAsync();
        }

        public async Task<Tutor> GetById(int id)
        {
            return await _context.Tutores.Include(t => t.Pets).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Tutor> Create(Tutor tutor)
        {
            _context.Tutores.Add(tutor);
            await _context.SaveChangesAsync();
            return tutor;
        }

        public async Task<Tutor> Update(Tutor tutor)
        {
            _context.Tutores.Update(tutor);
            await _context.SaveChangesAsync();
            return tutor;
        }

        public async Task<bool> Delete(int id)
        {
            var tutor = await _context.Tutores.FindAsync(id);
            if (tutor == null) return false;

            _context.Tutores.Remove(tutor);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}



using CatWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CatWebApp.Services
{
    public class CatService : ICatService
    {
        private CatDatabaseContext _context;
        private Random _random;

        public CatService(CatDatabaseContext context)
        {
            _context = context;
            _random = new Random();
        }
        public async Task<IEnumerable<Cat>> GetCats()
        {
            return await _context.Cats.Include(a => a.BreedType)
                                        .Include(a => a.FunFacts)
                                        .Include(a => a.HealthIssues)
                                        .ToListAsync();
        }
        public async Task<IEnumerable<BreedType>> GetBreeds()
        {
            return await _context.BreedTypes.ToListAsync();
        }
        public async Task<IEnumerable<Cat>> GetCats(string breed)
        {
            return await _context.Cats.Include(a => a.BreedType)
                                        .Include(a => a.FunFacts)
                                        .Include(a => a.HealthIssues)
                                        .Where(a=>a.BreedType.Name.Replace(" ","-").ToLower()==breed)
                                        .ToListAsync();
        }

        public async Task<Cat> GetCat(string breedName)
        {
            return await _context.Cats.Include(a => a.BreedType)
                                        .Include(a => a.FunFacts)
                                        .Include(a => a.HealthIssues)
                                        .Where(a => a.BreedName==breedName)
                                        .FirstOrDefaultAsync();
        }

        public async Task<Cat> GetRandomCat()
        {
            var list = await _context.Cats.Include(a => a.BreedType)
                                        .Include(a => a.FunFacts)
                                        .Include(a => a.HealthIssues)
                                        .ToListAsync();
            int randomNum = _random.Next(0, list.Count-1);
            return list.Where(a => a.Id == randomNum).FirstOrDefault();
        }
    }
}

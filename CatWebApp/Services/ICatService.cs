using CatWebApp.Models;

namespace CatWebApp.Services
{
    public interface ICatService
    {
        public Task<Cat> GetCat(string breedName);
        public Task<Cat> GetRandomCat();
        public Task<IEnumerable<Cat>> GetCats();
        public Task<IEnumerable<Cat>> GetCats(string breed);
        public Task<IEnumerable<BreedType>> GetBreeds();

    }
}

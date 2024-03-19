using WAD.CW1._11169.DAL.Models;

namespace WAD.CW1._11169.DAL.Interfaces
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> GetAllAsync();
        Task<Genre> GetByIdAsync(int id);
        Task<Genre> CreateAsync(Genre genre);
        Task UpdateAsync(Genre genre);
        Task DeleteAsync(int id);
    }
}

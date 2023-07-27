using Domain.Entities;

namespace Domain.Repositories
{
    public interface INoteRepository
    {
        Task<ICollection<Note>> FindAll();
        Task<Note> FindById(int id);    
        Task<Note> Create(Note note);
        Task<Note> Update(Note note);
        Task<bool> Delete(int id);

    
    }
}

using Domain.Entities;

namespace Domain.Repositories
{
    public interface IPersonRepository
    {
        Task<ICollection<Person>> FindAll();
        Task<Person> FindById(int id);
        Task<Person> Create (Person person);
        Task<Person> Update (Person person);
        Task<bool> Delete (int id);

    }
}

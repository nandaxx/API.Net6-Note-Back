using Domain.Entities;
using Domain.Repositories;
using InfraData.Context;
using Microsoft.EntityFrameworkCore;

namespace InfraData.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ContextDb _db;

        public PersonRepository(ContextDb db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<ICollection<Person>> FindAll()
        {
            var people =  await _db.People.Include(x => x.Notes).ToListAsync();
            return people;
        }

        public async Task<Person> FindById(int id)
        {
            var person = await _db.People.Include(x => x.Notes).FirstOrDefaultAsync(x => x.Id == id);
            return person;
        }

        public async Task<Person> Create(Person person)
        {
            _db.People.Add(person);
            await _db.SaveChangesAsync();
            return person;

        }
        public async Task<Person> Update(Person person)
        {
            _db.People.Update(person);
            await _db.SaveChangesAsync();
            return person;
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                var person = await _db.People.Where(u => u.Id == id)
                                    .FirstOrDefaultAsync();
                if (person == null) return false;
                _db.People.Remove(person);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

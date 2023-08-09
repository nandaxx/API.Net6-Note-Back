using Domain.Entities;
using Domain.Repositories;
using InfraData.Context;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

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

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
        public async Task<Person> Create(Person person)
        {
            var password = HashPassword(person.PassWord);
            person.PassWord = password;
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

        public async Task<Person> FindByEmail(string email)
        {
            var person = await _db.People.Include(x => x.Notes).FirstOrDefaultAsync(x => x.Email == email);
            return person;
        }

        public async Task<Person> Login(string email, string senha)
        {
            var pass = HashPassword(senha);
            return await _db.People.FirstOrDefaultAsync(x => x.Email == email && x.PassWord == pass);
        }
    }
}

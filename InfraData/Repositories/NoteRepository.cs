using Domain.Entities;
using Domain.Repositories;
using InfraData.Context;
using Microsoft.EntityFrameworkCore;

namespace InfraData.Repositories
{
    public class NoteRepository : INoteRepository
    {
        public readonly ContextDb _db;

        public NoteRepository(ContextDb db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<ICollection<Note>> FindAll()
        {
            var notes = await _db.Notes.Include(x => x.Person).ToListAsync();
            return notes;
        }

        public async Task<Note> FindById(int id)
        {
            var note = await _db.Notes.Include(x => x.Person).FirstOrDefaultAsync(x => x.Id == id);
            return note;
        }

        public async Task<Note> Create(Note note)
        {
            _db.Notes.Add(note);
            await _db.SaveChangesAsync();
            return note;
        }
        public async Task<Note> Update(Note note)
        {
            _db.Notes.Update(note);
            await _db.SaveChangesAsync();
            return note;
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                var note = await _db.Notes.Where(u => u.Id == id).FirstOrDefaultAsync();
                if (note == null) return false;
                _db.Notes.Remove(note);
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

using DemoProject.Data;
using DemoProject.Data.model;
using DemoProject.ModelDTO;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.RepositoryBattern
{
    public class RepositoryClass<T> : RepositoryInterface<T> where T : class
    {
        protected AppDbContext _db;
        public RepositoryClass(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public async Task InsertAsync(T entity)
        {
            _db.Set<T>().AddAsync(entity);
           await _db.SaveChangesAsync();
             
        }

        public async Task UpdateAsync(T entity)
        {
            DoctorDTO dTO = new();
            PatientDTO dTO1 = new();
            if (entity == dTO)
            {
                await _db.Doctors.SingleOrDefaultAsync(x => x.DocId == dTO.ID);
               // _db.Set<T>().Update(entity);
            }
            else if (entity == dTO1)
            {
                await _db.Patients.SingleOrDefaultAsync(x => x.PatId == dTO1.Id);
               // _db.Set<T>().Update(entity);
            }
            _db.Set<T>().Update(entity);
           await _db.SaveChangesAsync();
        }
        public async Task DeleteAsync(T entity)
        {
           _db.Set<T>().Remove(entity);
            await _db.SaveChangesAsync();
        }
    }
}

using KursovayaBlazorNet6.Abstract;
using KursovayaBlazorNet6.Domains;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;

namespace KursovayaBlazorNet6.DataAccessLayer
{
    public class DoctorSqlRepository : IRepository<Doctor>
    {
        private readonly ApplicationDbContext _context;

        public DoctorSqlRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Doctor model)
        {
            _context.Doctors.Add(model);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var entry = _context.Doctors.Find(id);
            _context.Doctors.Remove(entry);
            _context.SaveChanges();
        }

        public Doctor FindByName(string name) =>
            _context.Doctors.FirstOrDefault(p => p.Name == name);
        

        public IEnumerable<Doctor> GetList()
        {
            return _context.Doctors.Include(d => d.DoctorCategory);
        }

        public Doctor Read(long id)
        {
            var entry = _context.Doctors.Include(d => d.DoctorCategory)
                .FirstOrDefault(i => i.DoctorId == id);
            return entry;
      
        }

        public Doctor ReadWithRelations(long id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Doctor model)
        {
            var entry = _context.Doctors.Find(model.DoctorId);
            _context.Entry(entry).CurrentValues.SetValues(model);
            // связи - relation - нужно менять дополнительно
            _context.SaveChanges();
        }
    }
}

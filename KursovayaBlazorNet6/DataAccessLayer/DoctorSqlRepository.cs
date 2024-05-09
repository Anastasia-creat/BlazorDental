using KursovayaBlazorNet6.Abstract;
using KursovayaBlazorNet6.Domains;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;

namespace KursovayaBlazorNet6.DataAccessLayer
{
    public class ReviewsSqlRepository : IRepository<Reviews>
    {
        private readonly ApplicationDbContext _context;

        public ReviewsSqlRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Reviews model)
        {
            _context.Reviews.Add(model);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var entry = _context.Reviews.Find(id);
            _context.Reviews.Remove(entry);
            _context.SaveChanges();
        }

        public Reviews FindByName(string name) =>
            _context.Reviews.FirstOrDefault(p => p.Name == name);
        

        public IEnumerable<Reviews> GetList()
        {
            return _context.Reviews;
        }

        public Reviews Read(long id)
        {
            var entry = _context.Reviews
                .FirstOrDefault(i => i.ReviewId == id);
            return entry;
      
        }

        public Reviews ReadWithRelations(long id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Reviews model)
        {
            var entry = _context.Reviews.Find(model.ReviewId);
            _context.Entry(entry).CurrentValues.SetValues(model);
            // связи - relation - нужно менять дополнительно
            _context.SaveChanges();
        }
    }
}

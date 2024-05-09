using KursovayaBlazorNet6.Abstract;
using KursovayaBlazorNet6.Domains;
using Microsoft.EntityFrameworkCore;

namespace KursovayaBlazorNet6.DataAccessLayer
{
    public class ServiceSqlRepository : IRepository<Service>
    {
        private readonly ApplicationDbContext _context;

        public ServiceSqlRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Service FindByName(string name) =>
            _context.Services
                .FirstOrDefault(c => c.Name == name);

        public void Create(Service model)
        {
            _context.Services.Add(model);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var entry = _context.Services.Find(id);
            _context.Services.Remove(entry);
            _context.SaveChanges();
        }

        public IEnumerable<Service> GetList()
        {
            return _context
                .Services
                .Include(p => p.ServiceCategory);
        }

        public Service Read(long id)
        {   // join tables
            var entry = _context
                .Services
                // .Include(p => p.ProductBrand)
                .Include(p => p.ServiceCategory)
                .FirstOrDefault(p => p.ServiceId == id);
            return entry;
        }

        public void Update(Service model)
        {
            var entry = _context.Services.Find(model.ServiceId);
            _context.Entry(entry).CurrentValues.SetValues(model);
            // связи - relation - нужно менять дополнительно
            _context.SaveChanges();
        }

        public Service ReadWithRelations(long id)
        {
            throw new NotImplementedException();
        }
       

   

    }
}

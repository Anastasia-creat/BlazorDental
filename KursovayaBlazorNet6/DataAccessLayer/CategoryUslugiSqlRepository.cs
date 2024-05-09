using KursovayaBlazorNet6.Abstract;
using KursovayaBlazorNet6.Domains;

namespace KursovayaBlazorNet6.DataAccessLayer
{
    public class CategoryUslugiSqlRepository : IRepository<CategoryUslugi>
    {
        private readonly ApplicationDbContext _context;

        public CategoryUslugiSqlRepository(ApplicationDbContext context)
        {
            _context = context;
        }



        public void Create(CategoryUslugi model)
        {
            var existing = FindByName(model.Name);
            if (existing == null)
            {
                _context.CategoryUslugi.Add(model);
                _context.SaveChanges();
            }
            else
            {
                model.CategoryUslugiId = existing.CategoryUslugiId;
                // TODO: бросаем эксепшн?
            }
        }

        public void Delete(long id)
        {
            var entry = _context.CategoryUslugi.Find(id);
            _context.CategoryUslugi.Remove(entry);
            _context.SaveChanges();
        }

        public CategoryUslugi FindByName(string name) =>
            _context.CategoryUslugi
                .FirstOrDefault(c => c.Name == name);


        public void Update(CategoryUslugi model)
        {
            var entry = _context.CategoryUslugi.Find(model.CategoryUslugiId);
            _context.Entry(entry).CurrentValues.SetValues(model);
            // связи - relation - нужно менять дополнительно
            _context.SaveChanges();
        }

        //CategoryUslugi IRepository<CategoryUslugi>.FindByName(string name)
        //{
        //    throw new NotImplementedException();
        //}

        IEnumerable<CategoryUslugi> IRepository<CategoryUslugi>.GetList()
        {
            return _context.CategoryUslugi;

        }

        CategoryUslugi IRepository<CategoryUslugi>.Read(long id)
        {
            var entry = _context.CategoryUslugi.Find(id);
            return entry;
        }

        CategoryUslugi IRepository<CategoryUslugi>.ReadWithRelations(long id)
        {
            var entry = _context
                 .CategoryUslugi
                 // .Include(c => c.DoctorsOfCategory)
                 .FirstOrDefault(c => c.CategoryUslugiId == id);
            return entry;
        }
    }
}

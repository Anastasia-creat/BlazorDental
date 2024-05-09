using KursovayaBlazorNet6.Abstract;
using KursovayaBlazorNet6.Domains;

namespace KursovayaBlazorNet6.DataAccessLayer
{
    public class CategoryMedicSqlRepository : IRepository<CategoryMedic>
    {
        private readonly ApplicationDbContext _context;

        public CategoryMedicSqlRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(CategoryMedic model)
        {
            var existing = FindByName(model.Name);
            if (existing == null)
            {
                _context.CategoryMedic.Add(model);
                _context.SaveChanges();
            }
            else
            {
                model.CategoryMedicId = existing.CategoryMedicId;
                // TODO: бросаем эксепшн?
            }
        }

        public void Delete(long id)
        {
            var entry = _context.CategoryMedic.Find(id);
            _context.CategoryMedic.Remove(entry);
            _context.SaveChanges();
        }

        public CategoryMedic FindByName(string name) =>
          _context.CategoryMedic
              .FirstOrDefault(c => c.Name == name);



        public IEnumerable<CategoryMedic> GetList()
        {
            return _context.CategoryMedic;
        }

        public CategoryMedic Read(long id)
        {
            var entry = _context.CategoryMedic.Find(id);
            return entry;
        }

        public CategoryMedic ReadWithRelations(long id)
        {
            var entry = _context
                 .CategoryMedic
                 // .Include(c => c.DoctorsOfCategory)
                 .FirstOrDefault(c => c.CategoryMedicId == id);
            return entry;
        }

        public void Update(CategoryMedic model)
        {
            var entry = _context.CategoryMedic.Find(model.CategoryMedicId);
            _context.Entry(entry).CurrentValues.SetValues(model);
            // связи - relation - нужно менять дополнительно
            _context.SaveChanges();
        }
    }
}

using Mapster;
using Microsoft.AspNetCore.Mvc;
using KursovayaBlazorNet6.Abstract;
using KursovayaBlazorNet6.Models;
using KursovayaBlazorNet6.Domains;


namespace KursovayaBlazorNet6.BlazorServices
{
    public class BlazorService
    {
        private readonly IRepository<Service> _repositoryService;
        private readonly IRepository<CategoryUslugi> _repositoryCategory;
      

        public BlazorService(IRepository<Service> repository,
            IRepository<CategoryUslugi> repositoryCategory)
        {
            _repositoryService = repository;
            _repositoryCategory = repositoryCategory;
           
        }

        public int CountTotalPages(string categoryName)
        {
            // 0) ищем в базе категорию по имени
            var category = _repositoryCategory
                .FindByName(categoryName);

            // 1) добавляем механизм пагинации (разбиение на страницы)

            var query = _repositoryService
                .GetList()
                .Where(p =>
                    category == null ||
                    p.UslugiCategory.CategoryUslugiId == category.CategoryUslugiId);

            return (int)Math
                .Ceiling(query.Count() / 10f);
        }

        public Task<List<CategoryUslugi>> GetCategories()
        {
            return Task.FromResult(_repositoryCategory.GetList().ToList());
        }

       
        public List<ServicesBriefModel> GetServices(string categoryName, int page)
        {
            // 0) ищем в базе категорию по имени
            var category = _repositoryCategory
                .FindByName(categoryName);

            // 1) добавляем механизм пагинации (разбиение на страницы)

            var query = _repositoryService
                .GetList()
                .Where(p =>
                    category == null ||
                    p.UslugiCategory.CategoryUslugiId == category.CategoryUslugiId);

            var productsSample = query
                 .OrderBy(p => p.ServiceId)
                .Skip((page - 1) * 10)
                .Take(10)
                .Select(e => e.Adapt<ServicesBriefModel>());

            return productsSample.ToList();
        }

       

        public ServicesModel GetServiceDetails(long id)
        {
            var entity = _repositoryService.Read(id);
            var model = entity.Adapt<ServicesModel>();
            return model;
        }

       
    }
}

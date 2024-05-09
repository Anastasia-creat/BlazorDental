using Microsoft.AspNetCore.Mvc;
using KursovayaBlazorNet6.Abstract;
using KursovayaBlazorNet6.Domains;
using System.Linq;

namespace KursovayaBlazorNet6.Components
{
    [ViewComponent]
    public class MenuCategoriesViewComponent : ViewComponent
    {
        private readonly IRepository<Category> repository;

        public MenuCategoriesViewComponent(IRepository<Category> repository)
        {
            this.repository = repository;
        }

        public IViewComponentResult Invoke()
        {
            var categoriesNameList = repository
                .GetList()
                .Select(x => x.Name);

            return View(categoriesNameList);
        }
    }
}

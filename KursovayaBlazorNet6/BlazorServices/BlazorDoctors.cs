﻿using KursovayaBlazorNet6.Abstract;
using KursovayaBlazorNet6.Domains;
using KursovayaBlazorNet6.Models;
using Mapster;

namespace KursovayaBlazorNet6.BlazorServices
{
    public class BlazorDoctors
    {
        private readonly IRepository<Doctor> _repositoryDoctor;
        private readonly IRepository<CategoryMedic> _repositoryCategory;

        public BlazorDoctors(
            IRepository<Doctor> repository,
            IRepository<CategoryMedic> repositoryCategory
            )
        {
            _repositoryDoctor = repository;
            _repositoryCategory = repositoryCategory;
        }

        public int CountTotalPages(string categoryName)
        {
            // 0) ищем в базе категорию по имени
            var category = _repositoryCategory
                .FindByName(categoryName);

            // 1) добавляем механизм пагинации (разбиение на страницы)

            var query = _repositoryDoctor
                .GetList()
                .Where(p =>
                    category == null ||
                    p.MedicCategory.CategoryMedicId == category.CategoryMedicId);

            return (int)Math
                .Ceiling(query.Count() / 10f);
        }

        public Task<List<CategoryMedic>> GetCategories()
        {
            return Task.FromResult(
             _repositoryCategory
                .GetList()
                .ToList());
        }

       

        public List<DoctorModel> GetDoctors(string categoryName, int page)
        {
            // 0) ищем в базе категорию по имени
            var category = _repositoryCategory
                .FindByName(categoryName);

            // 1) добавляем механизм пагинации (разбиение на страницы)

            var query = _repositoryDoctor
                .GetList()
                .Where(p =>
                    category == null ||
                    p.MedicCategory.CategoryMedicId == category.CategoryMedicId);

            var productsSample = query
                .OrderBy(p => p.DoctorId)
                //.Skip((page - 1) * 10)
                .Take(50)
                .Select(e => e.Adapt<DoctorModel>());

            return productsSample.ToList();
        }

        public DoctorModel GetDoctorDetails(long id)
        {
            var entity = _repositoryDoctor.Read(id);
            var model = entity.Adapt<DoctorModel>();

            return model;
        }
    }
}

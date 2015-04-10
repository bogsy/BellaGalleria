using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BellaGalleria.Data.Infrastructure;
using BellaGalleria.Data.Repository;
using BellaGalleria.Model.Models;

namespace BellaGalleria.Service
{
    public interface ICategoryService : IServiceManager<Category>
    {
        void CreateCategory(Category category);
        Category GetCategory(int id);
        IEnumerable<Category> GetCategories();
        void EditCategory(Category category);
        void DeleteCategory(Category category);
        void SaveCategory();
    }

    public class CategoryService : BaseServiceManager<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository repository, IUnitOfWork unitofwork) 
            : base(repository, unitofwork)
        {
            _categoryRepository = repository;
            _unitOfWork = unitofwork;
        }

        public void CreateCategory(Category category)
        {
            _categoryRepository.Add(category);
            SaveCategory();
        }

        public Category GetCategory(int id)
        {
            var Category = _categoryRepository.GetById(id);
            return Category;
        }

        public IEnumerable<Category> GetCategories()
        {
            var Categories = _categoryRepository.GetAll();
            return Categories;
        }

        public void EditCategory(Category category)
        {
           // var Category = _categoryRepository.GetById(id);
            _categoryRepository.Update(category);
            SaveCategory();
        }

        public void DeleteCategory(Category category)
        {
            _categoryRepository.Delete(category);
        }

        public void SaveCategory()
        {
            _unitOfWork.Commit();
        }
    }
}

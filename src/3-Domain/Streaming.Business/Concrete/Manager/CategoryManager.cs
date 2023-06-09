using System.Collections.Generic;
using Streaming.Business.Interfaces;
using Streaming.Business.ValidationRules.FluentValidation;
using Streaming.Core.Aspects.Postsharp.ExceptionHandlingAspects;
using Streaming.Core.Aspects.Postsharp.ValidationAspects;
using Streaming.Core.Utilities.ServiceResult;
using Streaming.DataAccess.Interfaces;
using Streaming.Entities.Concrete;

namespace Streaming.Business.Concrete.Manager
{
    [ExceptionHandleAspect]
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public ICollection<Category> FindAll() =>
            _categoryRepository.FindAll();

        public Category FindById(int id) =>
            _categoryRepository.Find(x => x.Id == id);

        public Category FindByName(string name) =>
            string.IsNullOrWhiteSpace(name) ? null : _categoryRepository.Find(x => string.Equals(x.Name, name));

        [FluentValidationAspect(typeof(CategoryValidator))]
        public ServiceResult Add(Category category)
        {
            category.Id = default;
            _categoryRepository.Add(category);
            return ServiceResult.Success();
        }

        [FluentValidationAspect(typeof(CategoryValidator))]
        public ServiceResult Update(Category category)
        {
            _categoryRepository.Update(category);
            return ServiceResult.Success();
        }

        public ServiceResult RemoveById(int id)
        {
            var categoryCheckChild = _categoryRepository.CheckChildExist(x => x.Id == id);

            if (categoryCheckChild == null)
                return ServiceResult.Fail(ServiceError.EntityNotFound(nameof(Category), (nameof(Category.Id), id)));

            if (categoryCheckChild.IsMoviesExist)
                return ServiceResult.Fail(ServiceError.ForeignKeyUsing(nameof(Category), nameof(Category.Movies)));

            if (categoryCheckChild.IsSeriesExist)
                return ServiceResult.Fail(ServiceError.ForeignKeyUsing(nameof(Category), nameof(Category.Series)));

            _categoryRepository.Remove(new Category { Id = id });
            return ServiceResult.Success();
        }
    }
}

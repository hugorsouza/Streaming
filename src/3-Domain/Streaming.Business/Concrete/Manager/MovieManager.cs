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
    public class MoviesManager : IMovieservice
    {
        private readonly IMoviesRepository _MoviesRepository;
        private readonly ICategoryRepository _categoryRepository;

        public MoviesManager(IMoviesRepository MoviesRepository, ICategoryRepository categoryRepository)
        {
            _MoviesRepository = MoviesRepository;
            _categoryRepository = categoryRepository;
        }

        public ICollection<Movies> FindAll() =>
            _MoviesRepository.FindAll();

        public ICollection<Movies> FindAllByCategoryId(int categoryId) =>
            _MoviesRepository.FindAll(x => x.CategoryId == categoryId);

        public Movies FindById(int id) =>
            _MoviesRepository.Find(x => x.Id == id);

        public Movies FindByMovies(string name) =>
             string.IsNullOrWhiteSpace(name) ? null : _MoviesRepository.Find(x => string.Equals(x.Movie, name));

        [FluentValidationAspect(typeof(MoviesValidator))]
        public ServiceResult Add(Movies Movies)
        {
            var isCategoryExist = _categoryRepository.Exists(x => x.Id == Movies.CategoryId);

            if (!isCategoryExist)
                return ServiceResult.Fail(ServiceError.ForeignKeyNotFound(nameof(Movies.CategoryId)));

            Movies.Id = default;
            _MoviesRepository.Add(Movies);
            return ServiceResult.Success();
        }

        [FluentValidationAspect(typeof(MoviesValidator))]
        public ServiceResult Update(Movies Movies)
        {
            var existsCategory = _categoryRepository.Exists(x => x.Id == Movies.CategoryId);

            if (!existsCategory)
                return ServiceResult.Fail(ServiceError.ForeignKeyNotFound(nameof(Movies.CategoryId)));

            _MoviesRepository.Update(Movies);
            return ServiceResult.Success();
        }

        public ServiceResult RemoveById(int id)
        {
            var existsMovies = _MoviesRepository.Exists(x => x.Id == id);
            if (!existsMovies)
                return ServiceResult.Fail(ServiceError.EntityNotFound(nameof(Movies), (nameof(Movies.Id), id)));

            _MoviesRepository.Remove(new Movies { Id = id });
            return ServiceResult.Success();
        }
    }
}

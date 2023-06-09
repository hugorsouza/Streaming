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
    public class SeriesManager : ISeriesService
    {
        private readonly ISeriesRepository _SeriesRepository;
        private readonly ICategoryRepository _categoryRepository;

        public SeriesManager(ISeriesRepository SeriesRepository, ICategoryRepository categoryRepository)
        {
            _SeriesRepository = SeriesRepository;
            _categoryRepository = categoryRepository;
        }

        public ICollection<Series> FindAll() =>
            _SeriesRepository.FindAll();

        public ICollection<Series> FindAllByCategoryId(int categoryId) =>
            _SeriesRepository.FindAll(x => x.CategoryId == categoryId);

        public Series FindById(int id) =>
            _SeriesRepository.Find(x => x.Id == id);

        public Series FindBySeries(string name) =>
             string.IsNullOrWhiteSpace(name) ? null : _SeriesRepository.Find(x => string.Equals(x.Serie, name));

        [FluentValidationAspect(typeof(SeriesValidator))]
        public ServiceResult Add(Series Series)
        {
            var isCategoryExist = _categoryRepository.Exists(x => x.Id == Series.CategoryId);

            if (!isCategoryExist)
                return ServiceResult.Fail(ServiceError.ForeignKeyNotFound(nameof(Series.CategoryId)));

            Series.Id = default;
            _SeriesRepository.Add(Series);
            return ServiceResult.Success();
        }

        [FluentValidationAspect(typeof(SeriesValidator))]
        public ServiceResult Update(Series Series)
        {
            var existsCategory = _categoryRepository.Exists(x => x.Id == Series.CategoryId);

            if (!existsCategory)
                return ServiceResult.Fail(ServiceError.ForeignKeyNotFound(nameof(Series.CategoryId)));

            _SeriesRepository.Update(Series);
            return ServiceResult.Success();
        }

        public ServiceResult RemoveById(int id)
        {
            var existsSeries = _SeriesRepository.Exists(x => x.Id == id);
            if (!existsSeries)
                return ServiceResult.Fail(ServiceError.EntityNotFound(nameof(Series), (nameof(Series.Id), id)));

            _SeriesRepository.Remove(new Series { Id = id });
            return ServiceResult.Success();
        }
    }
}

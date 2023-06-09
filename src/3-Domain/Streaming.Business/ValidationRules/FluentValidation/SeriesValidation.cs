using FluentValidation;
using Streaming.Business.DependencyResolvers;
using Streaming.Business.Interfaces;
using Streaming.Core.CrossCuttingConcerns.Validation.FluentValidation;
using Streaming.Entities.Concrete;

namespace Streaming.Business.ValidationRules.FluentValidation
{
    public class SeriesValidator : AbstractValidator<Series>
    {
        private static readonly ISeriesService SeriesService = InstanceFactory.GetInstance<ISeriesService>();

        public SeriesValidator()
        {
            RuleFor(x => x.Serie).IsUnique<Series, string, int>(x => SeriesService.FindBySeries(x.Serie));
            RuleFor(x => x.Serie).NotEmpty().MaximumLength(100);
            RuleFor(x => x.CategoryId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Actor).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Director).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Seasons).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Streamings).NotEmpty().MaximumLength(100);
        }

    }
}

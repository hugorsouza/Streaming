using FluentValidation;
using Streaming.Business.DependencyResolvers;
using Streaming.Business.Interfaces;
using Streaming.Core.CrossCuttingConcerns.Validation.FluentValidation;
using Streaming.Entities.Concrete;

namespace Streaming.Business.ValidationRules.FluentValidation
{
    public class MoviesValidator : AbstractValidator<Movies>
    {
        private static readonly IMovieservice MoviesService = InstanceFactory.GetInstance<IMovieservice>();

        public MoviesValidator()
        {
            RuleFor(x => x.Movie).IsUnique<Movies, string, int>(x => MoviesService.FindByMovies(x.Movie));
            RuleFor(x => x.Movie).NotEmpty().MaximumLength(100);
            RuleFor(x => x.CategoryId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Actor).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Director).NotEmpty().MaximumLength(100);
            RuleFor(x => x.RunningTime).NotEmpty().GreaterThan(0);
        }

    }
}

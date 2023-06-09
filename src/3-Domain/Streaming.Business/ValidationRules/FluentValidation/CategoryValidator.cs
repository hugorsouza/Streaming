using FluentValidation;
using Streaming.Business.DependencyResolvers;
using Streaming.Business.Interfaces;
using Streaming.Core.CrossCuttingConcerns.Validation.FluentValidation;
using Streaming.Entities.Concrete;

namespace Streaming.Business.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        private static readonly ICategoryService CategoryService = InstanceFactory.GetInstance<ICategoryService>();

        public CategoryValidator()
        {
            RuleFor(x => x.Name).Cascade(CascadeMode.Stop).NotEmpty().MaximumLength(50)
                .IsUnique<Category, string, int>(x => CategoryService.FindByName(x.Name));
        }
    }
}

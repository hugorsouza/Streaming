using FluentValidation;
using Streaming.Business.DependencyResolvers;
using Streaming.Business.Interfaces;
using Streaming.Core.CrossCuttingConcerns.Validation.FluentValidation;
using Streaming.Entities.Concrete;

namespace Streaming.Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        private static readonly IUserService UserService = InstanceFactory.GetInstance<IUserService>();

        public UserValidator()
        {
            RuleFor(x => x.UserName).IsUnique<User, string, int>(x => UserService.FindByUser(x.UserName));
            RuleFor(x => x.UserName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Email).NotEmpty().MaximumLength(100);
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.PasswordHash).NotEmpty();
        }

    }
}

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
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User FindByUserNameWithRoles(string username) =>
            _userRepository.Find(x => x.UserName.Equals(username), nameof(User.Roles));


        public User FindById(int id) =>
            _userRepository.Find(x => x.Id == id);

        public User FindByUser(string name) =>
             string.IsNullOrWhiteSpace(name) ? null : _userRepository.Find(x => string.Equals(x.UserName, name));

        [FluentValidationAspect(typeof(UserValidator))]
        public ServiceResult Add(User User)
        {
            User.Id = default;
            _userRepository.Add(User);
            return ServiceResult.Success();
        }

        [FluentValidationAspect(typeof(UserValidator))]
        public ServiceResult Update(User User)
        {
            _userRepository.Update(User);
            return ServiceResult.Success();
        }

        public ServiceResult RemoveById(int id)
        {
            var existsUser = _userRepository.Exists(x => x.Id == id);
            if (!existsUser)
                return ServiceResult.Fail(ServiceError.EntityNotFound(nameof(User), (nameof(User.Id), id)));

            _userRepository.Remove(new User { Id = id });
            return ServiceResult.Success();
        }
    }
}

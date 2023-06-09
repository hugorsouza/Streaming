using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Streaming.Core.Utilities.ServiceResult;
using Streaming.Entities.Concrete;

namespace Streaming.Business.Interfaces
{
    public interface IUserService
    {
        User FindByUserNameWithRoles([NotNull] string username);
        User FindById(int id);
        User FindByUser([NotNull] string name);
        ServiceResult Add([NotNull] User User);
        ServiceResult Update([NotNull] User User);
        ServiceResult RemoveById(int id);
    }
}

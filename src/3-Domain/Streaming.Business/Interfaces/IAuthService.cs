using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Streaming.Core.Utilities.Authentication.TokenBased;
using Streaming.Core.Utilities.ServiceResult;
using Streaming.Entities.Concrete;

namespace Streaming.Business.Interfaces
{
    public interface IAuthService
    {
        /// <summary>
        /// Checks if <paramref name="username"/> and <paramref name="password"/> correct.
        /// </summary>
        /// <remarks>
        /// If the <paramref name="username"/> is incorrect, the <see cref="User"/> object is returned as null, otherwise the <see cref="User"/> object is returned.
        /// In the <see cref="ServiceResult"/> object, the IsSuccess property is true if the <paramref name="username"/> and <paramref name="password"/> are correct, otherwise false.
        /// </remarks>
        /// <returns>A tuple containing a <see cref="ServiceResult"/> and a <see cref="User"/> object including roles.</returns>
        (ServiceResult, User) Login(string username, string password);

        /// <summary>
        /// Creates a new <see cref="Token"/> instance.
        /// </summary>
        /// <returns>A <see cref="Token"/> object including roles.</returns>
        Token CreateToken(User user);
    }
}

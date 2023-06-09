using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Streaming.Core.Utilities.Authentication.TokenBased
{
    public abstract class TokenHelper
    {
        public abstract Token GetAccessToken(IEnumerable<Claim> claims);

    }
}

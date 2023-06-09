﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Streaming.Business.Interfaces;
using Streaming.Core.Utilities.Authentication.TokenBased;
using Streaming.Core.Utilities.ServiceResult;
using Streaming.Entities.Concrete;

namespace Streaming.Business.Concrete.Manager
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly TokenHelper _tokenHelper;

        public AuthManager(IUserService userService, IPasswordHasher<User> passwordHasher, TokenHelper tokenHelper)
        {
            _userService = userService;
            _passwordHasher = passwordHasher;
            _tokenHelper = tokenHelper;
        }

        public (ServiceResult, User) Login(string username, string password)
        {
            var user = _userService.FindByUserNameWithRoles(username);

            // check username 
            if (user == null)
                return (ServiceResult.Fail(new ServiceError(ServiceError.AuthenticationError, $"User not found for parameters {{username='{username}'}}.")), null);

            // check password
            if (_passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password) == PasswordVerificationResult.Failed)
                return (ServiceResult.Fail(new ServiceError(ServiceError.AuthenticationError, $"Incorrect password:  {{password='{password}'}}.")), user);

            return (ServiceResult.Success(), user);
        }

        public Token CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Name, user.UserName),
                new(ClaimTypes.Email, user.Email)
            };

            if (user.Roles != null)
                claims.AddRange(user.Roles.Select(role => new Claim(ClaimTypes.Role, role.Name)));

            return _tokenHelper.GetAccessToken(claims);
        }
    }
}

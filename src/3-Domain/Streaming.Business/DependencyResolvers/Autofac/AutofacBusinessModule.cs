using Autofac;
using Microsoft.AspNetCore.Identity;
using Streaming.Business.Concrete.Manager;
using Streaming.Business.Interfaces;
using Streaming.Core.Utilities.Authentication.TokenBased;
using Streaming.Core.Utilities.Authentication.TokenBased.JWT;
using Streaming.DataAccess.Concrete.EntityFramework;
using Streaming.DataAccess.Interfaces;
using Streaming.Entities.Concrete;

namespace Streaming.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region Services
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<RoleManager>().As<IRoleService>().SingleInstance();
            builder.RegisterType<MoviesManager>().As<IMovieservice>().SingleInstance();
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<SeriesManager>().As<ISeriesService>().SingleInstance();
            #endregion

            #region Repositories
            builder.RegisterType<EfUserRepository>().As<IUserRepository>().SingleInstance();
            builder.RegisterType<EfRoleRepository>().As<IRoleRepository>().SingleInstance();
            builder.RegisterType<EfUserRoleRepository>().As<IUserRoleRepository>().SingleInstance();
            builder.RegisterType<EfMoviesRepository>().As<IMoviesRepository>().SingleInstance();
            builder.RegisterType<EfCategoryRepository>().As<ICategoryRepository>().SingleInstance();
            builder.RegisterType<EfSeriesRepository>().As<ISeriesRepository>().SingleInstance();
            #endregion

            builder.RegisterType<PasswordHasher<User>>().As<IPasswordHasher<User>>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<TokenHelper>().SingleInstance();
        }
    }
}


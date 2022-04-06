using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using users_app.Application.Commands;
using users_app.Application.Queries;
using users_app.Implementation.Commands;
using users_app.Implementation.Queries;
using users_app.Implementation.Validators;

namespace users_app.Api.Core
{
    public static class ContainerExtensions
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<ICreateUserCommand, EfCreateUserCommand>();
            services.AddTransient<IEditUserCommand, EfEditUserCommand>();
            services.AddTransient<IGetUserQuery, EfGetUserQuery>();
            services.AddTransient<IGetUsersQuery, EfGetUsersQuery>();
            services.AddTransient<IGetRolesQuery, EfGetRolesQuery>();
        }

        public static void AddValidators(this IServiceCollection services)
        {
            services.AddTransient<CreateUserValidator>();
            services.AddTransient<EditUserValidator>();

        }
    }
}

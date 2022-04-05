using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using users_app.Application.Commands;
using users_app.Application.DTO;
using users_app.DataAccess;
using users_app.Domain;
using users_app.Implementation.Validators;

namespace users_app.Implementation.Commands
{
    public class EfCreateUserCommand : ICreateUserCommand
    {
        private readonly UserContext _con;
        private readonly CreateUserValidator _val;

        public EfCreateUserCommand(UserContext con, CreateUserValidator val)
        {
            _con = con;
            _val = val;
        }

        public int Id => 1;

        public string Name => "Create user command";

        public List<int> AllowedRoles => new List<int> { 1 };

        public void Execute(CreateUserDto request)
        {
            _val.ValidateAndThrow(request);

            var user = new User
            {
                Username = request.Username,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = GetMd5Hash(request.Password),
                RoleId = 2,
                CreatedAt = DateTime.UtcNow,
                IsDeleted = false,
                IsActive = true
            };

            _con.Users.Add(user);
            _con.SaveChanges();
        }

        public string GetMd5Hash(string input)
        {
            using MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}

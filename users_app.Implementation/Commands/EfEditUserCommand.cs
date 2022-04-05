using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using users_app.Application;
using users_app.Application.Commands;
using users_app.Application.DTO;
using users_app.Application.Exceptions;
using users_app.DataAccess;
using users_app.Domain;
using users_app.Implementation.Validators;

namespace users_app.Implementation.Commands
{
    public class EfEditUserCommand : IEditUserCommand
    {
        private readonly UserContext _con;
        private readonly IAppActor _actor;
        private readonly EditUserValidator _val;
        public EfEditUserCommand(UserContext con, IAppActor actor, EditUserValidator val)
        {
            _con = con;
            _val = val;
            _actor = actor;
        }
        public int Id => 2;

        public string Name => "Edit User Command";

        public List<int> AllowedRoles => new List<int> { 1 };

        public void Execute(EditUserDto request)
        {

            _val.ValidateAndThrow(request);

            var user = _con.Users.Where(x => x.IsDeleted == false && x.Id == request.Id).First();

            if (user == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(User));
            }

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.Password = GetMd5Hash(request.Password);

            user.ModifiedAt = DateTime.UtcNow;
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

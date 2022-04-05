using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using users_app.Application.DTO;
using users_app.Application.Exceptions;
using users_app.Application.Queries;
using users_app.DataAccess;
using users_app.Domain;

namespace users_app.Implementation.Queries
{
    public class EfGetUserQuery : IGetUserQuery
    {
        private readonly UserContext _con;
        private readonly IMapper _mapper;
        public EfGetUserQuery(UserContext con, IMapper mapper)
        {
            _con = con;
            _mapper = mapper;
        }
        public int Id => 3;

        public string Name => "Get User Query";

        public List<int> AllowedRoles => new List<int> { 1, 2 };

        public UserDto Execute(int request)
        {
            var user = _con.Users.Include(x => x.Role)
                 .Where(x => x.IsDeleted == false && x.Id == request)
                 .FirstOrDefault();
            if (user == null)
            {
                throw new EntityNotFoundException(request, typeof(User));
            }

            return _mapper.Map<UserDto>(user);
        }
    }
}

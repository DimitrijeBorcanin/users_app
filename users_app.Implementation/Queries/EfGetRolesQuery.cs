using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using users_app.Application.DTO;
using users_app.Application.Queries;
using users_app.Application.Searches;
using users_app.DataAccess;
using users_app.Domain;
using users_app.Implementation.Extensions;

namespace users_app.Implementation.Queries
{
    public class EfGetRolesQuery : IGetRolesQuery
    {
        private readonly UserContext _con;
        private readonly IMapper _mapper;
        public EfGetRolesQuery(UserContext con, IMapper mapper)
        {
            _con = con;
            _mapper = mapper;
        }
        public int Id => 5;

        public string Name => "Get roles query";

        public List<int> AllowedRoles => new List<int> { 1 };

        public PagedResponse<RoleDto> Execute(RoleSearchDto request)
        {
            var query = _con.Roles.AsQueryable();

            return query.MakePaged<RoleDto, Role>(request, _mapper);
        }
    }
}

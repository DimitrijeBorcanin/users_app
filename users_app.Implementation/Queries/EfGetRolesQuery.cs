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

namespace users_app.Implementation.Queries
{
    class EfGetRolesQuery : IGetRolesQuery
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
            var query = _con.Users.Include(x => x.Role)
                .Where(x => x.IsDeleted == false)
                .AsQueryable();

            var offset = request.PerPage * (request.Page - 1);

            var res = new PagedResponse<RoleDto>
            {
                PerPage = request.PerPage,
                TotalItems = query.Count(),
                CurrentPage = request.Page,
                Items = query.Skip(offset).Take(request.PerPage).Select(x => _mapper.Map<RoleDto>(x)).ToList()
            };

            return res;
        }
    }
}

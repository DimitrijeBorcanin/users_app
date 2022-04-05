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
    public class EfGetUsersQuery : IGetUsersQuery
    {
        private readonly UserContext _con;
        private readonly IMapper _mapper;
        public EfGetUsersQuery(UserContext con, IMapper mapper)
        {
            _con = con;
            _mapper = mapper;
        }
        public int Id => 4;

        public string Name => "Get users query";

        public List<int> AllowedRoles => new List<int> { 1 };

        public PagedResponse<UserDto> Execute(UserSearchDto request)
        {
            var query = _con.Users.Include(x => x.Role)
                .Where(x => x.IsDeleted == false)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.Keyword))
            {
                query = query.Where(x => x.FirstName.ToLower().Contains(request.Keyword.ToLower())
                || x.LastName.ToLower().Contains(request.Keyword.ToLower())
                || x.Email.ToLower().Contains(request.Keyword.ToLower())
                || x.Username.ToLower().Contains(request.Keyword.ToLower()));
            }

            if (request.DateFrom > DateTime.MinValue)
            {
                query = query.Where(x => x.CreatedAt >= request.DateFrom);
            }

            if (request.DateTo > DateTime.MinValue)
            {
                query = query.Where(x => x.CreatedAt <= request.DateTo);
            }

            if (request.Page == -1)
            {
                request.Page = 1;
                request.PerPage = query.Count();
            }

            var offset = request.PerPage * (request.Page - 1);

            var res = new PagedResponse<UserDto>
            {
                PerPage = request.PerPage,
                TotalItems = query.Count(),
                CurrentPage = request.Page,
                Items = query.Skip(offset).Take(request.PerPage).Select(x => _mapper.Map<UserDto>(x)).ToList()
            };

            return res;
        }
    }
}

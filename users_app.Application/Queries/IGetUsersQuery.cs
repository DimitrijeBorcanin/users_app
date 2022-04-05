using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using users_app.Application.DTO;
using users_app.Application.Searches;

namespace users_app.Application.Queries
{
    public interface IGetUsersQuery : IQuery<UserSearchDto, PagedResponse<UserDto>>
    {
    }
}

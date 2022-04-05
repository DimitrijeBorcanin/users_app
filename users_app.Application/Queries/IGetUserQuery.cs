using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using users_app.Application.DTO;

namespace users_app.Application.Queries
{
    public interface IGetUserQuery : IQuery<int, UserDto>
    {
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace users_app.Application
{
    public interface IAppActor
    {
        int Id { get; }
        string Identity { get; }
        int RoleId { get; }
    }
}

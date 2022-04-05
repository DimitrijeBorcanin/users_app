using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using users_app.Application;

namespace users_app.Api.Core
{
    public class GuestActor : IAppActor
    {
        public int Id => 0;

        public string Identity => "Guest";
        public int RoleId => 0;
    }
}

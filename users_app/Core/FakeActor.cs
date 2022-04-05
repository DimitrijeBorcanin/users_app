using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using users_app.Application;

namespace users_app.Api.Core
{
    public class FakeActor : IAppActor
    {
        public int Id => 2;
        public string Identity => "Fake Actor";
        public int RoleId => 2;
    }

    public class FakeAdmin : IAppActor
    {
        public int Id => 1;
        public string Identity => "Fake Admin";
        public int RoleId => 1;
    }
}

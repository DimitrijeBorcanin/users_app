using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace users_app.Application.Queries
{
    public abstract class PagedQuery
    {
        public int PerPage { get; set; } = 10;
        public int Page { get; set; } = 1;
    }
}

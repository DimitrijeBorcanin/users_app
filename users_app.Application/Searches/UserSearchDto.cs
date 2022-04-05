using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using users_app.Application.Queries;

namespace users_app.Application.Searches
{
    public class UserSearchDto : PagedQuery
    {
        public string Keyword { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}

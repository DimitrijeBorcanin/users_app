using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace users_app.Application.Queries
{
    public class PagedResponse<T> where T : class
    {
        public int CurrentPage { get; set; }
        public int PerPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages => (int)Math.Ceiling((float)TotalItems / PerPage);
        public IEnumerable<T> Items { get; set; }
    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using users_app.Application.Queries;

namespace users_app.Implementation.Extensions
{
    public static class PageAndResponseExtensions
    {
        public static PagedResponse<TDto> MakePaged<TDto, TEntity>(this IQueryable<TEntity> query, PagedQuery search, IMapper mapper) where TDto : class
        {
            var skipCount = search.PerPage * (search.Page - 1);
            var skipped = query.Skip(skipCount).Take(search.PerPage);

            var pageResponse = new PagedResponse<TDto>
            {
                CurrentPage = search.Page,
                PerPage = search.PerPage,
                TotalItems = query.Count(),
                Items = mapper.Map<IEnumerable<TDto>>(skipped)
            };
            return pageResponse;
        }
    }
}

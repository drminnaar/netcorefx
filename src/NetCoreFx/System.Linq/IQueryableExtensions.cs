using System.Collections.Generic;

namespace System.Linq
{
    public static class IQueryableExtensions
    {
        public static PagedCollection<T> ToPagedCollection<T>(this IQueryable<T> source, int pageNumber, int pageSize)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source), "Source of paged collection may not be null");

            if (pageNumber < 1)
                throw new ArgumentOutOfRangeException(nameof(pageNumber), "Page number must be greater than zero");

            if (pageSize < 1)
                throw new ArgumentOutOfRangeException(nameof(pageSize), "Page size must be greater than zero");

            var itemCount = source.AsEnumerable().Count();

            var items = source
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToList();

            return new PagedCollection<T>(items, itemCount, pageNumber, pageSize);
        }
    }
}

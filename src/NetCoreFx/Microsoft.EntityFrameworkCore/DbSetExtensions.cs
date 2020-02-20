using System;
using System.Linq;

namespace Microsoft.EntityFrameworkCore
{
    public static class DbSetExtensions
    {
        public static IQueryable<T> TagWithApplicationName<T>(this DbSet<T> source, string applicationName) where T : class
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            if (string.IsNullOrWhiteSpace(applicationName))
                throw new ArgumentException("The specified application name may not be null, empty or whitespace", nameof(applicationName));

            return source.TagWith($"ApplicationName: {applicationName}");
        }

        public static IQueryable<T> TagWithQueryName<T>(this DbSet<T> source, string queryName) where T : class
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            if (string.IsNullOrWhiteSpace(queryName))
                throw new ArgumentException("The specified query name may not be null, empty or whitespace", nameof(queryName));

            return source.TagWith($"QueryName: {queryName}");
        }
    }
}

using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace System.Linq
{
    public static class EnumerableExtensions
    {
        public static IList<T> ToListOrNull<T>(this IEnumerable<T> source)
        {
            return source?.ToList();
        } 
    }
}
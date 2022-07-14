using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LawTech.CrossCutting.Helper
{
    public static class ContextHelper
    {
        public static IQueryable<T> WhereIf<T>(
       this IQueryable<T> source, bool condition,
       Expression<Func<T, bool>> predicate)
        {
            if (condition)
                return source.Where(predicate);
            else
                return source;
        }

        public static IEnumerable<T> WhereIf<T>(
      this IEnumerable<T> source, bool condition,
      Func<T, bool> predicate)
        {
            if (condition)
                return source.Where(predicate);
            else
                return source;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using prep.collections;
using prep.utility.filtering;

namespace prep.utility
{
    public interface IWhereEnumerator<ItemToFilter, PropertyType>
    {
        IEnumerable<ItemToFilter> equal_to(PropertyType value);
    }

    public class WhereEnumerator<ItemToFilter, PropertyType> : IWhereEnumerator<ItemToFilter, PropertyType>
    {
        private readonly IEnumerable<ItemToFilter> _enumerable;
        private readonly PropertyAccessor<ItemToFilter, PropertyType> _accessor;

        public WhereEnumerator(IEnumerable<ItemToFilter> enumerable, PropertyAccessor<ItemToFilter,PropertyType> accessor)
        {
            _enumerable = enumerable;
            _accessor = accessor;
        }

        public IEnumerable<ItemToFilter> equal_to(PropertyType value)
        {
            var criteria = Where<ItemToFilter>.has_a(_accessor).equal_to(value);
            return _enumerable.all_items_matching(criteria);
        }
    }

    public static class BetterEnumerableExtensions
    {
        public static IWhereEnumerator<ItemToFilter, PropertyType> where<ItemToFilter, PropertyType>(this IEnumerable<ItemToFilter> enumerable, PropertyAccessor<ItemToFilter, PropertyType> accessor)
        {
            return new WhereEnumerator<ItemToFilter, PropertyType>(enumerable, accessor);
        }
    }
}

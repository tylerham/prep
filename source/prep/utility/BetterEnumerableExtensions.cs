using System.Collections;
using System.Collections.Generic;
using prep.collections;
using prep.utility.filtering;

namespace prep.utility
{
  public class FilteredEnumerable<ItemToFilter, PropertyType> : IEnumerable<ItemToFilter>
  {
    IEnumerable<ItemToFilter> items;
    PropertyAccessor<ItemToFilter, PropertyType> accessor;
    IMatchAn<ItemToFilter> criteria;

    public FilteredEnumerable(IEnumerable<ItemToFilter> items, PropertyAccessor<ItemToFilter, PropertyType> accessor)
    {
      this.items = items;
      this.accessor = accessor;
    }

    public IEnumerable<ItemToFilter> equal_to(PropertyType value)
    {
      criteria = Where<ItemToFilter>.has_a(accessor).equal_to(value);
      return this;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IEnumerator<ItemToFilter> GetEnumerator()
    {
      return items.all_items_matching(criteria).GetEnumerator();
    }
  }

  public static class BetterEnumerableExtensions
  {
    public static FilteredEnumerable<ItemToFilter, PropertyType> where<ItemToFilter, PropertyType>(
      this IEnumerable<ItemToFilter> enumerable, PropertyAccessor<ItemToFilter, PropertyType> accessor)
    {
      return new FilteredEnumerable<ItemToFilter, PropertyType>(enumerable, accessor);
    }
  }
}
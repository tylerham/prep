using System.Collections.Generic;
using prep.collections;
using prep.utility.filtering;

namespace prep.utility
{
  public static class FilteringEnumerableExtensions 
  {
    public static FilteringExtensionPoint<ItemToFilter, PropertyType> where<ItemToFilter, PropertyType>(
      this IEnumerable<ItemToFilter> enumerable, PropertyAccessor<ItemToFilter, PropertyType> accessor)
    {
      return new FilteringExtensionPoint<ItemToFilter, PropertyType>(enumerable,
                                                                     Where<ItemToFilter>.has_a(accessor));
    }
  }
}
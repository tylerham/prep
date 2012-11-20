using System;
using prep.utility.filtering;

namespace prep.collections
{
  public class Where<ItemToFilter>
  {
    public static MatchFactory<ItemToFilter, TProperty> has_a<TProperty>(
      PropertyAccessor<ItemToFilter, TProperty> accessor)
    {
      return new MatchFactory<ItemToFilter, TProperty>(accessor);
    }

    public static ComparableMatchFactory<ItemToFilter, TProperty> has_an<TProperty>(
      PropertyAccessor<ItemToFilter, TProperty> accessor) where TProperty : IComparable<TProperty>
    {
      return new ComparableMatchFactory<ItemToFilter, TProperty>(has_a(accessor));
    }
  }
}
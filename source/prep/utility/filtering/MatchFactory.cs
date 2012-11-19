using System.Collections.Generic;
using prep.collections;

namespace prep.utility.filtering
{
  public class MatchFactory<ItemToFilter, TProperty>
  {
    PropertyAccessor<ItemToFilter, TProperty> accessor;

    public MatchFactory(PropertyAccessor<ItemToFilter, TProperty> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchAn<ItemToFilter> equal_to(TProperty value)
    {
      return equal_to_any(value);
    }

    public IMatchAn<ItemToFilter> equal_to_any(params TProperty[] values)
    {
      return new ConditionalMatch<ItemToFilter>(item => new List<TProperty>(values).Contains(accessor(item)));
    }

    public IMatchAn<ItemToFilter> not_equal_to(TProperty value)
    {
      return new NegatingMatcher<ItemToFilter>(equal_to(value));
    }
  }
}
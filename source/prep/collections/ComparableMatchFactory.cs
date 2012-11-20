using System;
using prep.utility;
using prep.utility.filtering;
using prep.utility.ranges;

namespace prep.collections
{
  public class ComparableMatchFactory<ItemToFilter, TProperty> : ICreateMatchers<ItemToFilter, TProperty>
    where TProperty : IComparable<TProperty>
  {
    ICreateMatchers<ItemToFilter, TProperty> original;

    public ComparableMatchFactory(ICreateMatchers<ItemToFilter, TProperty> original)
    {
      this.original = original;
    }

    public IMatchAn<ItemToFilter> create_using(Condition<ItemToFilter> condition)
    {
      return original.create_using(condition);
    }

    public IMatchAn<ItemToFilter> equal_to(TProperty value)
    {
      return original.equal_to(value);
    }

    public IMatchAn<ItemToFilter> equal_to_any(params TProperty[] values)
    {
      return original.equal_to_any(values);
    }

    public IMatchAn<ItemToFilter> not_equal_to(TProperty value)
    {
      return original.not_equal_to(value);
    }

    public IMatchAn<ItemToFilter> falls_in(IContainValues<TProperty> range)
    {
      return create_to_match(new FallsInRange<TProperty>(range));
    }

    public IMatchAn<ItemToFilter> greater_than(TProperty value)
    {
      return create_to_match(new IsGreaterThan<TProperty>(value));
    }

    public IMatchAn<ItemToFilter> between(TProperty start, TProperty end)
    {
      return create_to_match(new IsBetween<TProperty>(start, end));
    }

    public IMatchAn<ItemToFilter> create_to_match(IMatchAn<TProperty> criteria)
    {
      return original.create_to_match(criteria);
    }
  }
}
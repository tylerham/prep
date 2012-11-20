using System;
using prep.utility.filtering;
using prep.utility.ranges;

namespace prep.collections
{
  public static class FilteringExtensions
  {
    public static DSLResult equal_to<ItemToFilter, TProperty, DSLResult>(
      this IProvideAccessToFilteringDSL<ItemToFilter, TProperty, DSLResult> dsl_point, TProperty value)
    {
      return equal_to_any(dsl_point, value);
    }

    public static DSLResult equal_to_any<ItemToFilter, TProperty, DSLResult>(
      this IProvideAccessToFilteringDSL<ItemToFilter, TProperty, DSLResult> dsl_point, params TProperty[] values)
    {
      return create_to_match(dsl_point, new EqualToAny<TProperty>(values));
    }

    public static DSLResult create_to_match<ItemToFilter, TProperty, DSLResult>(
      this IProvideAccessToFilteringDSL<ItemToFilter, TProperty, DSLResult> dsl_point, IMatchAn<TProperty> criteria)
    {
      return dsl_point.build_dsl_result_using(criteria);
    }

    public static DSLResult falls_in<ItemToFilter, TProperty, DSLResult>(
      this IProvideAccessToFilteringDSL<ItemToFilter, TProperty, DSLResult> dsl_point, IContainValues<TProperty> range)
      where TProperty : IComparable<TProperty>
    {
      return create_to_match(dsl_point, new FallsInRange<TProperty>(range));
    }

    public static DSLResult greater_than<ItemToFilter, TProperty, DSLResult>(
      this IProvideAccessToFilteringDSL<ItemToFilter, TProperty, DSLResult> dsl_point, TProperty value)
      where TProperty : IComparable<TProperty>
    {
      return create_to_match(dsl_point, new IsGreaterThan<TProperty>(value));
    }

    public static DSLResult between<ItemToFilter, TProperty, DSLResult>(
      this IProvideAccessToFilteringDSL<ItemToFilter, TProperty, DSLResult> dsl_point, TProperty start, TProperty end)
      where TProperty : IComparable<TProperty>
    {
      return create_to_match(dsl_point, new IsBetween<TProperty>(start, end));
    }
  }
}
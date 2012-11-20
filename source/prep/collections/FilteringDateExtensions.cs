using System;

namespace prep.collections
{
  public static class FilteringDateExtensions
  {
    public static DSLResult greater_than<ItemToFilter, DSLResult>(
      this IProvideAccessToFilteringDSL<ItemToFilter, DateTime,DSLResult> dsl_point, int year)
    {
      return dsl_point.create_to_match(Where<DateTime>.has_a(x => x.Year).greater_than(year));
    }
  }
}
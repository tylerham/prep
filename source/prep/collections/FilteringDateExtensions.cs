using System;
using prep.utility.filtering;

namespace prep.collections
{
  public static class FilteringDateExtensions
  {
    public static IMatchAn<ItemToFilter> greater_than<ItemToFilter>(
      this MatchCreationExtensionPoint<ItemToFilter, DateTime> extension_point, int year)
    {
      return extension_point.create_to_match(Where<DateTime>.has_a(x => x.Year).greater_than(year));
    }

  }
}
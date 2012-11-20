using System;
using prep.utility.filtering;

namespace prep.utility.ranges
{
  public static class Range
  {
    public static ContainValues<T> starting_from<T>(T start) where T : IComparable<T>
    {
      return new ContainValues<T>(new IsEqualOrGreaterThan<T>(start));
    }

    public static ContainValues<T> After<T>(T start) where T : IComparable<T>
    {
      return new ContainValues<T>(new IsGreaterThan<T>(start));
    }
  }
}
using System;

namespace prep.utility.ranges
{
  public interface IContainValues<in T> where T : IComparable<T>
  {
    bool contains(T item);
    bool does_not_contain(T item);
  }
}
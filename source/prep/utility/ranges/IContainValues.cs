using System;

namespace prep.utility.ranges
{
  public interface IContainValues<T> where T : IComparable<T>
  {
    bool contains(T item);
  }
}
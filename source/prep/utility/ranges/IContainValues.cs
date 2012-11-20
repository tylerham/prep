using System;
using prep.utility.filtering;

namespace prep.utility.ranges
{
  public interface IContainValues<T> where T : IComparable<T>
  {
    bool contains(T item);
  }

  public class ContainValues<TProperty> : IContainValues<TProperty> where TProperty : IComparable<TProperty>
  {
    IMatchAn<TProperty> condition;

    public ContainValues(IMatchAn<TProperty> condition)
    {
      this.condition = condition;
    }

    public bool contains(TProperty item)
    {
      return condition.matches(item);
    }

    public ContainValues<TProperty> add_condition(IMatchAn<TProperty> condition)
    {
      return new ContainValues<TProperty>(this.condition.and(condition));
    }

    public ContainValues<TProperty> to(TProperty end)
    {
      return add_condition(new IsEqualOrLesserThan<TProperty>(end));
    }
  }

}
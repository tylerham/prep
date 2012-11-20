using System;
using System.Collections.Generic;
using prep.utility.filtering;

namespace prep.utility.ranges
{
  public interface IContainValues<T> where T : IComparable<T>
  {
    bool contains(T item);
  }

    public class ContainValues<TProperty> : IContainValues<TProperty> where TProperty : IComparable<TProperty>
    {
        private readonly List<Condition<TProperty>> _conditions=new List<Condition<TProperty>>();

        public bool contains(TProperty item)
        {
            foreach (var condition in _conditions)
            {
                if (!condition(item)) return false;
            }
            return true;
        }

        public void AddCondition(Condition<TProperty> condition)
        {
            _conditions.Add(condition);
        }

        //public IRangeConfig<TProperty> From(TProperty start)
        //{
        //    throw new NotImplementedException();
        //}

        public ContainValues<TProperty> To(TProperty end)
        {
            AddCondition(new IsEqualOrLesserThan<TProperty>(end).matches);
            return this;
        }
    }

    //public interface IRangeConfig<T>
    //{
    //    IRangeConfig<T> From(T start);
    //    IRangeConfig<T> To(T end);
    //}
}
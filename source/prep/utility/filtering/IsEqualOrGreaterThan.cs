using System;

namespace prep.utility.filtering
{
    public class IsEqualOrGreaterThan<T> :IMatchAn<T> where T : IComparable<T>
    {
        T value;

        public IsEqualOrGreaterThan(T start)
        {
            this.value = start;
        }

        public bool matches(T item)
        {
            return item.CompareTo(value) >= 0;
        }
    }
}
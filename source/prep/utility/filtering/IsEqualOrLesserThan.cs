using System;

namespace prep.utility.filtering
{
    public class IsEqualOrLesserThan<T> :IMatchAn<T> where T : IComparable<T>
    {
        T start;

        public IsEqualOrLesserThan(T start)
        {
            this.start = start;
        }

        public bool matches(T item)
        {
            return item.CompareTo(start) <= 0;
        }
    }
}
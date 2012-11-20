using System;

namespace prep.utility.filtering
{
    public class IsLesserThan<T> :IMatchAn<T> where T : IComparable<T>
    {
        T start;

        public IsLesserThan(T start)
        {
            this.start = start;
        }

        public bool matches(T item)
        {
            return item.CompareTo(start) < 0;
        }
    }
}
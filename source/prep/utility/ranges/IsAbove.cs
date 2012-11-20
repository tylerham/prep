using System;
using prep.utility.filtering;

namespace prep.utility.ranges
{
    public class IsAbove<T> : IMatchAn<T> where T : IComparable<T>
    {
        private readonly RangeBoundary<T> _boundary;

        public IsAbove(RangeBoundary<T> boundary)
        {
            _boundary = boundary;
        }

        public bool matches(T item)
        {
            if (_boundary.Condition == RangeBoundaryCondition.Unchecked)
                return true;

            if (_boundary.Condition == RangeBoundaryCondition.Inclusive)
                return item.CompareTo(_boundary.Value) >= 0;

            return item.CompareTo(_boundary.Value) > 0;
        }
    }
}
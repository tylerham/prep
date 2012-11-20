using System;
using prep.utility.ranges;

namespace prep.utility.filtering
{
    public class FallsInRange<T> : IMatchAn<T> where T : IComparable<T>
    {
        private readonly IContainValues<T> _range;

        public FallsInRange(IContainValues<T> range)
        {
            this._range = range;
        }

        public bool matches(T item)
        {
            return _range.contains(item);
        }
    }
}
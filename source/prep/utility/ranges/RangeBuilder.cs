using System;

namespace prep.utility.ranges
{
    public class RangeBuilder<T> : IStartRanges<T>, IEndRanges<T> where T : IComparable<T>
    {
        private RangeBoundary<T> _start = new NullRangeBoundary<T>();
        private RangeBoundary<T> _end = new NullRangeBoundary<T>(); 

        public IEndRanges<T> starts_after(T startAfter)
        {
            _start = new RangeBoundary<T>(startAfter, RangeBoundaryCondition.Exclusive);
            return this;
        }

        public IEndRanges<T> starts_on(T startOn)
        {
            _start = new RangeBoundary<T>(startOn, RangeBoundaryCondition.Inclusive);
            return this;
        }

        public IContainValues<T> ends_on(T endsOn)
        {
            _end = new RangeBoundary<T>(endsOn, RangeBoundaryCondition.Inclusive);
            return this;
        }

        public IContainValues<T> ends_before(T endsBefore)
        {
            _end =new RangeBoundary<T>(endsBefore, RangeBoundaryCondition.Exclusive);
            return this;
        }

        public bool contains(T item)
        {
            return is_above_start(item) && is_below_end(item);
        }

        private bool is_above_start(T item)
        {
            var spec = new IsAbove<T>(_start);
            return spec.matches(item);
        }

        private bool is_below_end(T item)
        {
            var spec = new IsBelow<T>(_end);
            return spec.matches(item);
        }
    }
}
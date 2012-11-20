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
            VerifyEndBoundary(endsOn);

            _end = new RangeBoundary<T>(endsOn, RangeBoundaryCondition.Inclusive);
            return this;
        }

        private void VerifyEndBoundary(T endValue)
        {
            if (_start.Condition != RangeBoundaryCondition.Unchecked && (endValue.CompareTo(_start.Value) < 0))
                throw new InvalidOperationException("End cannot be less than start");
        }

        public IContainValues<T> ends_before(T endsBefore)
        {
            VerifyEndBoundary(endsBefore);

            _end = new RangeBoundary<T>(endsBefore, RangeBoundaryCondition.Exclusive);
            return this;
        }

        public bool contains(T item)
        {
            return is_within_start_bound(item) && is_within_end_bound(item);
        }

        public bool does_not_contain(T item)
        {
            return !contains(item);
        }

        private bool is_within_start_bound(T item)
        {
            var spec = new RangeBoundaryMatcher<T>(_start, RangeBoundaryType.Low);
            return spec.matches(item);
        }

        private bool is_within_end_bound(T item)
        {
            var spec = new RangeBoundaryMatcher<T>(_end, RangeBoundaryType.High);
            return spec.matches(item);
        }
    }
}
using System;
using prep.utility.filtering;

namespace prep.utility.ranges
{
    public class RangeBoundaryMatcher<T> : IMatchAn<T> where T : IComparable<T>
    {
        private readonly RangeBoundary<T> _boundary;
        private readonly RangeBoundaryType _type;

        public RangeBoundaryMatcher(RangeBoundary<T> boundary, RangeBoundaryType type)
        {
            _boundary = boundary;
            _type = type;
        }

        public bool matches(T item)
        {
            if (_boundary.Condition == RangeBoundaryCondition.Unchecked)
                return true;

            var comparisonResult = item.CompareTo(_boundary.Value);

            return _type == RangeBoundaryType.Low
                       ? MatchesBoundary(comparisonResult)
                       : MatchesBoundary(comparisonResult * -1);
        }

        private bool MatchesBoundary(int compareResult)
        {
            if (_boundary.Condition == RangeBoundaryCondition.Inclusive)
                return compareResult >= 0;

            return compareResult > 0;
        }

    }
}
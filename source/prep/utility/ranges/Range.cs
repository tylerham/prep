using System;

namespace prep.utility.ranges
{
    public static class Range<T> where T : IComparable<T>
    {
        public static IEndRanges<T> starts_after(T startAfter)
        {
            return new RangeBuilder<T>().starts_after(startAfter);
        }

        public static IEndRanges<T> starts_on(T startOn)
        {
            return new RangeBuilder<T>().starts_on(startOn);
        }

        public static IContainValues<T> ends_before(T endsBefore)
        {
            return new RangeBuilder<T>().ends_before(endsBefore);
        }

        public static IContainValues<T> ends_on(T endsOn)
        {
            return new RangeBuilder<T>().ends_on(endsOn);
        }
    }
}
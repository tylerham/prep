using System;
using prep.utility.filtering;

namespace prep.utility.ranges
{
    public static class Range
    {
        public static ContainValues<T> StartingFrom<T>(T start) where T : IComparable<T>
        {
            var containValues = new ContainValues<T>();
            containValues.AddCondition(new IsEqualOrGreaterThan<T>(start).matches);
            return containValues;
        }
        public static ContainValues<T> After<T>(T start) where T : IComparable<T>
        {
            var containValues = new ContainValues<T>();
            containValues.AddCondition(new IsGreaterThan<T>(start).matches);
            return containValues;
        }
    }
}

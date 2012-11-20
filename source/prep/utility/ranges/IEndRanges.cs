using System;

namespace prep.utility.ranges
{
    public interface IEndRanges<T> : IContainValues<T> where T : IComparable<T>
    {
        IContainValues<T> ends_on(T endsOn);
        IContainValues<T> ends_before(T endsBefore);
    }
}
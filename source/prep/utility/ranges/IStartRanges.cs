using System;

namespace prep.utility.ranges
{
    public interface IStartRanges<T> : IContainValues<T> where T : IComparable<T>
    {
        IEndRanges<T> starts_after(T startAfter);
        IEndRanges<T> starts_on(T startOn);
    }
}
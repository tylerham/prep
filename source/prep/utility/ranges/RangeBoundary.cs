using System;

namespace prep.utility.ranges
{
    public class RangeBoundary<T>
    {
        public RangeBoundary(T value, RangeBoundaryCondition condition)
        {
            Value = value;
            Condition = condition;
        }

        public T Value { get; private set; }
        public RangeBoundaryCondition Condition { get; private set; }
    }
}
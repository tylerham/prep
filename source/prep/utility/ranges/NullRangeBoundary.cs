namespace prep.utility.ranges
{
    public class NullRangeBoundary<T> : RangeBoundary<T>
    {
        public NullRangeBoundary()
            : base(default(T), RangeBoundaryCondition.Unchecked)
        {
        }
    }
}
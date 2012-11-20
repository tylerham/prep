using System;

namespace prep.utility.ranges
{
    public class Range<T> : IContainValues<T> where T : IComparable<T>
    {
        Boundary<T> lower;
        Boundary<T> upper;
        public Range<T> at_least(T item)
        {
            lower = new Boundary<T>(item, true);
            return this;
        }
        public Range<T> at_most(T item)
        {
            lower = new Boundary<T>(item, true);
            return this;
        }
        public Range<T> greater_than(T item)
        {
            lower = new Boundary<T>(item, false);
            return this;
        } 
        public Range<T> less_than(T item)
        {
            upper = new Boundary<T>(item, false);
            return this;
        }
        public bool contains(T item)
        {
            bool above_lower = true, below_upper = true;
            if(lower != null)
                if(lower._inclusive)
                    above_lower = item.CompareTo(lower._value) >= 0;
                else
                    above_lower = item.CompareTo(lower._value) > 0;
            if (upper != null)
                if (upper._inclusive)
                    below_upper = item.CompareTo(upper._value) <= 0;
                else
                    below_upper = item.CompareTo(upper._value) < 0;
            return above_lower && below_upper;
        }
    }
    public class Boundary<T> where T : IComparable<T>
    {
        public T _value { get; private set; }
        public bool _inclusive { get; private set; }
        public Boundary(T value, bool inclusive = true )
    {
        this._value = value;
        this._inclusive = inclusive;
    }
    }
}
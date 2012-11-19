using System;
using prep.utility;
using prep.utility.filtering;

namespace prep.collections
{
    public class ComparableMatchFactory<ItemToFilter, TProperty> : ICreateMatchers<ItemToFilter, TProperty>
      where TProperty : IComparable<TProperty>
    {
        PropertyAccessor<ItemToFilter, TProperty> accessor;
        ICreateMatchers<ItemToFilter, TProperty> original;

        private readonly Func<Condition<ItemToFilter>, ConditionalMatch<ItemToFilter>> conditionalMatchBuilder =
            c => new ConditionalMatch<ItemToFilter>(c);


        public IMatchAn<ItemToFilter> equal_to(TProperty value)
        {
            return original.equal_to(value);
        }

        public IMatchAn<ItemToFilter> equal_to_any(params TProperty[] values)
        {
            return original.equal_to_any(values);
        }

        public IMatchAn<ItemToFilter> not_equal_to(TProperty value)
        {
            return original.not_equal_to(value);
        }

        public ComparableMatchFactory(PropertyAccessor<ItemToFilter, TProperty> accessor, ICreateMatchers<ItemToFilter, TProperty> original)
        {
            this.accessor = accessor;
            this.original = original;
        }

        public IMatchAn<ItemToFilter> greater_than(TProperty value)
        {
            return conditionalMatchBuilder(x => accessor(x).CompareTo(value) > 0);
        }

        public IMatchAn<ItemToFilter> between(TProperty start, TProperty end)
        {
            return conditionalMatchBuilder(x => accessor(x).CompareTo(start) >= 0 && accessor(x).CompareTo(end) <= 0);
        }
    }
}
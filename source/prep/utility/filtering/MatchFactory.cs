using System;
using System.Collections.Generic;
using prep.collections;

namespace prep.utility.filtering
{
    public class MatchFactory<ItemToFilter, TProperty>
    {
        readonly PropertyAccessor<ItemToFilter, TProperty> accessor;

        public MatchFactory(PropertyAccessor<ItemToFilter, TProperty> accessor)
        {
            this.accessor = accessor;
        }

        public IMatchAn<ItemToFilter> equal_to(TProperty value)
        {
            return equal_to_any(value);
        }

        public IMatchAn<ItemToFilter> equal_to_any(params TProperty[] values)
        {
            return new ConditionalMatch<ItemToFilter>(item => new List<TProperty>(values).Contains(accessor(item)));
        }

        public IMatchAn<ItemToFilter> not_equal_to(TProperty value)
        {
            return new NegatingMatcher<ItemToFilter>(equal_to(value));
        }

        public IMatchAn<ItemToFilter> greater_than(TProperty value)
        {
            return new ConditionalMatch<ItemToFilter>(i => ((IComparable)accessor(i)).CompareTo((IComparable)value) > 0);
        }

        public IMatchAn<ItemToFilter> between(TProperty smaller, TProperty larger)
        {
            return new ConditionalMatch<ItemToFilter>(
                i =>
                    {
                        var target = ((IComparable) accessor(i));
                        return target.CompareTo((IComparable)smaller)>=0  && target.CompareTo((IComparable)larger) <= 0;
                    });

        }
    }
}
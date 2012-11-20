using System;
using prep.utility;
using prep.utility.filtering;
using prep.utility.ranges;

namespace prep.collections
{
    public static class FilteringExtensions
    {
        public static IMatchAn<ItemToFilter> equal_to<ItemToFilter, TProperty>(this MatchCreationExtensionPoint<ItemToFilter, TProperty> extension_point, TProperty value)
        {
            return equal_to_any(extension_point, value);
        }

        public static IMatchAn<ItemToFilter> equal_to_any<ItemToFilter, TProperty>(this MatchCreationExtensionPoint<ItemToFilter, TProperty> extension_point, params TProperty[] values)
        {
            return create_to_match(extension_point, new EqualToAny<TProperty>(values));
        }

        public static IMatchAn<ItemToFilter> not_equal_to<ItemToFilter, TProperty>(this MatchCreationExtensionPoint<ItemToFilter, TProperty> extension_point, TProperty value)
        {
            return new NegatingMatcher<ItemToFilter>(equal_to(extension_point, value));
        }

        public static IMatchAn<ItemToFilter> create_using<ItemToFilter, TProperty>(this MatchCreationExtensionPoint<ItemToFilter, TProperty> extension_point, Condition<ItemToFilter> condition)
        {
            return new ConditionalMatch<ItemToFilter>(condition);
        }

        public static IMatchAn<ItemToFilter> create_to_match<ItemToFilter, TProperty>(this MatchCreationExtensionPoint<ItemToFilter, TProperty> extension_point, IMatchAn<TProperty> criteria)
        {
            return new PropertyMatch<ItemToFilter, TProperty>(extension_point.accessor, criteria);
        }

        public static IMatchAn<ItemToFilter> falls_in<ItemToFilter, TProperty>(this MatchCreationExtensionPoint<ItemToFilter, TProperty> extension_point, IContainValues<TProperty> range) where TProperty : IComparable<TProperty>
        {
            return create_to_match(extension_point, new FallsInRange<TProperty>(range));
        }

        public static IMatchAn<ItemToFilter> greater_than<ItemToFilter, TProperty>(this MatchCreationExtensionPoint<ItemToFilter, TProperty> extension_point, TProperty value) where TProperty : IComparable<TProperty>
        {
            return create_to_match(extension_point, new IsGreaterThan<TProperty>(value));
        }

        public static IMatchAn<ItemToFilter> between<ItemToFilter, TProperty>(this MatchCreationExtensionPoint<ItemToFilter, TProperty> extension_point, TProperty start, TProperty end) where TProperty : IComparable<TProperty>
        {
            return create_to_match(extension_point, new IsBetween<TProperty>(start, end));
        }
    }
}

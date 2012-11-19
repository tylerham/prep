using System;
using prep.utility.filtering;

namespace prep.collections
{
	public class Where<ItemToFilter>
	{
		public static MatchFactory<ItemToFilter, TProperty> has_a<TProperty>(PropertyAccessor<ItemToFilter, TProperty> accessor)
		{
			return new MatchFactory<ItemToFilter, TProperty>(accessor);
		}
	}
}
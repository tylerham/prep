namespace prep.utility.filtering
{
	public class NegatingMatcher<Item> : IMatchAn<Item>
	{
		readonly IMatchAn<Item> _innerMatcher;

		public NegatingMatcher(IMatchAn<Item> innerMatcher)
		{
			_innerMatcher = innerMatcher;
		}

		public bool matches(Item item)
		{
			return !_innerMatcher.matches(item);
		}
	}
}
namespace prep.utility.filtering
{
	public class NegatingMatcher<Item> : IMatchAn<Item>
	{
		readonly IMatchAn<Item> _innerItem;

		public NegatingMatcher(IMatchAn<Item> innerItem)
		{
			_innerItem = innerItem;
		}

		public bool matches(Item item)
		{
			return !_innerItem.matches(item);
		}
	}
}
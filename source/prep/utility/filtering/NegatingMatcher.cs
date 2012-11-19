namespace prep.utility.filtering
{
  public class NegatingMatcher<Item> : IMatchAn<Item>
  {
    IMatchAn<Item> inner;

    public NegatingMatcher(IMatchAn<Item> inner)
    {
      this.inner = inner;
    }

    public bool matches(Item item)
    {
      return ! inner.matches(item);
    }
  }
}
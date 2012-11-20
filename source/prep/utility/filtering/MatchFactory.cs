namespace prep.utility.filtering
{
  public class MatchFactory<ItemToFilter, TProperty> : ICreateMatchers<ItemToFilter, TProperty>
  {
    PropertyAccessor<ItemToFilter, TProperty> accessor;

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
      return create_to_match(new EqualToAny<TProperty>(values));
    }

    public IMatchAn<ItemToFilter> not_equal_to(TProperty value)
    {
      return new NegatingMatcher<ItemToFilter>(equal_to(value));
    }

    public IMatchAn<ItemToFilter> create_using(Condition<ItemToFilter> condition)
    {
      return new ConditionalMatch<ItemToFilter>(condition);
    }

    public IMatchAn<ItemToFilter> create_to_match(IMatchAn<TProperty> criteria)
    {
      return new PropertyMatch<ItemToFilter, TProperty>(accessor, criteria);
    }
  }
}
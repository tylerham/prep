namespace prep.utility.filtering
{
  public class PropertyMatch<ItemToFilter, PropertyType> : IMatchAn<ItemToFilter>
  {
    PropertyAccessor<ItemToFilter, PropertyType> accessor;
    IMatchAn<PropertyType> specification;

    public PropertyMatch(PropertyAccessor<ItemToFilter, PropertyType> accessor, IMatchAn<PropertyType> specification)
    {
      this.accessor = accessor;
      this.specification = specification;
    }

    public bool matches(ItemToFilter item)
    {
      return specification.matches(accessor(item));
    }

  }
}
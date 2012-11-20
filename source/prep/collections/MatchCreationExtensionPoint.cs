using prep.utility.filtering;

namespace prep.collections
{
  public class MatchCreationExtensionPoint<ItemToFilter,PropertyType>
  {
    public PropertyAccessor<ItemToFilter, PropertyType> accessor;

    public MatchCreationExtensionPoint(PropertyAccessor<ItemToFilter, PropertyType> accessor)
    {
      this.accessor = accessor;
    }
  }
}
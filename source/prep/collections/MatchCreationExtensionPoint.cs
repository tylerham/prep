using prep.utility.filtering;

namespace prep.collections
{
  public interface IProvideAccessToFilteringExtensions<ItemToFilter, PropertyType>
  {
    IMatchAn<ItemToFilter> build_criteria(IMatchAn<PropertyType> criteria);
  }

  public class MatchCreationExtensionPoint<ItemToFilter, PropertyType> :
    IProvideAccessToFilteringExtensions<ItemToFilter, PropertyType>
  {
    PropertyAccessor<ItemToFilter, PropertyType> accessor;

    public MatchCreationExtensionPoint(PropertyAccessor<ItemToFilter, PropertyType> accessor)
    {
      this.accessor = accessor;
    }

    public IProvideAccessToFilteringExtensions<ItemToFilter, PropertyType> not
    {
      get { return new NegatingFilteringExtensionPoint<ItemToFilter,PropertyType>(this); }
    }

    public IMatchAn<ItemToFilter> build_criteria(IMatchAn<PropertyType> criteria)
    {
      return new PropertyMatch<ItemToFilter, PropertyType>(accessor, criteria);
    }
  }
}
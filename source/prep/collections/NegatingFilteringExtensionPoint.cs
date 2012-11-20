using prep.utility.filtering;

namespace prep.collections
{
  public class NegatingFilteringExtensionPoint<ItemToFilter,PropertyType> : IProvideAccessToFilteringExtensions<ItemToFilter,PropertyType>
  {
    IProvideAccessToFilteringExtensions<ItemToFilter, PropertyType> original;

    public NegatingFilteringExtensionPoint(IProvideAccessToFilteringExtensions<ItemToFilter, PropertyType> original)
    {
      this.original = original;
    }

    public IMatchAn<ItemToFilter> build_criteria(IMatchAn<PropertyType> criteria)
    {
      return new NegatingMatcher<ItemToFilter>(original.build_criteria(criteria));
    }
  }
}
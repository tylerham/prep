using prep.utility.filtering;

namespace prep.collections
{
  public class MatchCreationExtensionPoint<ItemToFilter, PropertyType> :
    IProvideAccessToFilteringDSL<ItemToFilter, PropertyType, IMatchAn<ItemToFilter>>
  {
    PropertyAccessor<ItemToFilter, PropertyType> accessor;

    public MatchCreationExtensionPoint(PropertyAccessor<ItemToFilter, PropertyType> accessor)
    {
      this.accessor = accessor;
    }

    public IProvideAccessToFilteringDSL<ItemToFilter, PropertyType,IMatchAn<ItemToFilter>> not
    {
      get { return new NegatingMatchingExtensionPoint(this); }
    }

    public IMatchAn<ItemToFilter> build_dsl_result_using(IMatchAn<PropertyType> criteria)
    {
      return new PropertyMatch<ItemToFilter, PropertyType>(accessor, criteria);
    }

    class NegatingMatchingExtensionPoint : IProvideAccessToFilteringDSL<ItemToFilter, PropertyType, IMatchAn<ItemToFilter>>
    {
      IProvideAccessToFilteringDSL<ItemToFilter, PropertyType, IMatchAn<ItemToFilter>> original;

      public NegatingMatchingExtensionPoint(
        IProvideAccessToFilteringDSL<ItemToFilter, PropertyType, IMatchAn<ItemToFilter>> original)
      {
        this.original = original;
      }

      public IMatchAn<ItemToFilter> build_dsl_result_using(IMatchAn<PropertyType> criteria)
      {
        return new NegatingMatcher<ItemToFilter>(original.build_dsl_result_using(criteria));
      }
    }
  }
}
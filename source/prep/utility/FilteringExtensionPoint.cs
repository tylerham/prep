using System.Collections.Generic;
using prep.collections;
using prep.utility.filtering;

namespace prep.utility
{
  public class FilteringExtensionPoint<ItemToFilter, PropertyType> :
    IProvideAccessToFilteringDSL<ItemToFilter, PropertyType, IEnumerable<ItemToFilter>>
  {
    IProvideAccessToFilteringDSL<ItemToFilter, PropertyType, IMatchAn<ItemToFilter>>
      specification_creation_extension_point;

    IEnumerable<ItemToFilter> items;

    public FilteringExtensionPoint(IEnumerable<ItemToFilter> items,
                                   IProvideAccessToFilteringDSL<ItemToFilter, PropertyType, IMatchAn<ItemToFilter>>
                                     specification_creation_extension_point)
    {
      this.items = items;
      this.specification_creation_extension_point = specification_creation_extension_point;
    }

    public IProvideAccessToFilteringDSL<ItemToFilter, PropertyType, IEnumerable<ItemToFilter>> not
    {
      get { return new NegatingFilteringExtensionPoint(this); }
    }

    public IEnumerable<ItemToFilter> build_dsl_result_using(IMatchAn<PropertyType> criteria)
    {
      return items.all_items_matching(specification_creation_extension_point.build_dsl_result_using(criteria));
    }

    class NegatingFilteringExtensionPoint :
      IProvideAccessToFilteringDSL<ItemToFilter, PropertyType, IEnumerable<ItemToFilter>>
    {
      IProvideAccessToFilteringDSL<ItemToFilter, PropertyType, IEnumerable<ItemToFilter>>
        enumerable_extension_point;

      public NegatingFilteringExtensionPoint(
        IProvideAccessToFilteringDSL<ItemToFilter, PropertyType, IEnumerable<ItemToFilter>> enumerable_extension_point)
      {
        this.enumerable_extension_point = enumerable_extension_point;
      }

      public IEnumerable<ItemToFilter> build_dsl_result_using(IMatchAn<PropertyType> criteria)
      {
        return enumerable_extension_point.build_dsl_result_using(new NegatingMatcher<PropertyType>(criteria));
      }
    }
  }
}
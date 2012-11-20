using prep.utility.filtering;

namespace prep.collections
{
  public interface IProvideAccessToFilteringDSL<ItemToFilter, PropertyType, DSLResult>
  {
    DSLResult build_dsl_result_using(IMatchAn<PropertyType> criteria);
  }
}
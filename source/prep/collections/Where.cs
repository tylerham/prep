using prep.utility.filtering;

namespace prep.collections
{
  public class Where<ItemToFilter>
  {
    public static MatchCreationExtensionPoint<ItemToFilter, TProperty> has_a<TProperty>(
      PropertyAccessor<ItemToFilter, TProperty> accessor)
    {
      return new MatchCreationExtensionPoint<ItemToFilter, TProperty>(accessor);
    }
  }
}
namespace prep.utility.filtering
{
  public static class MatchExtensions
  {
/*    public static IMatchAn<Item> and<Item>(this IMatchAn<Item> left, IMatchAn<Item> right)
    {
      return new AndMatch<Item>(left, right);
    }*/

    public static IMatchAn<Item> or<Item>(this IMatchAn<Item> left, IMatchAn<Item> right)
    {
      return new OrMatch<Item>(left, right);
    }
  }
}
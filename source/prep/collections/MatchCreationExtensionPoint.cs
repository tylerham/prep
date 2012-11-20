using prep.utility.filtering;

namespace prep.collections
{
    public class MatchCreationExtensionPoint<ItemToFilter, PropertyType>
    {
        public PropertyAccessor<ItemToFilter, PropertyType> accessor;

        private bool _negative = false;

        public MatchCreationExtensionPoint(PropertyAccessor<ItemToFilter, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public MatchCreationExtensionPoint<ItemToFilter, PropertyType> not
        {
            get
            {
                _negative = true;
                return this;
            }
        }

        public IMatchAn<PropertyType> build_criteria(IMatchAn<PropertyType> criteria)
        {
           if (_negative)
           {
               return new NegatingMatcher<PropertyType>(criteria);
           }

            return criteria;
        }
    }

}
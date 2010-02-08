namespace Legendigital.Framework.Common.Bussiness.NHibernate
{
    public enum FilterFunction
    {
        NoFilter,
        Contains,
        DoesNotContain,
        StartsWith,
        EndsWith,
        EqualTo,
        NotEqualTo,
        GreaterThan,
        LessThan,
        GreaterThanOrEqualTo,
        LessThanOrEqualTo,
        Between,
        NotBetween,
        IsEmpty,
        NotIsEmpty,
        IsNull,
        NotIsNull,
        Custom
    }
}
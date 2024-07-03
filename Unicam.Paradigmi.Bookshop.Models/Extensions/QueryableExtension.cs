namespace Unicam.Paradigmi.Bookshop.Application.Extensions;

public static class QueryableExtension
{
    public static IQueryable<T> UncurriedFilter<T>(this IQueryable<T> queryable, Predicate<T> predicate, T? value) 
    {
        return value == null ? queryable : queryable.Where(v => predicate.Invoke(value));
    }
}
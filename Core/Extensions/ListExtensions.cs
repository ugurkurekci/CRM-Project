namespace Domain.Extensions;

public static class ListExtensions
{

    public static void AddRange<T>(this IList<T> list, IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            list.Add(item);
        }
    }

    public static void AddRange<T>(this IList<T> list, params T[] items)
    {
        foreach (var item in items)
        {
            list.Add(item);
        }
    }

    public static void AddRange<T>(this IList<T> list, T item, int count)
    {
        for (int i = 0; i < count; i++)
        {
            list.Add(item);
        }
    }

    public static void AddRange<T>(this IList<T> list, Func<T> itemFactory, int count)
    {
        for (int i = 0; i < count; i++)
        {
            list.Add(itemFactory());
        }
    }

    public static void AddRange<T>(this IList<T> list, Func<int, T> itemFactory, int count)
    {
        for (int i = 0; i < count; i++)
        {
            list.Add(itemFactory(i));
        }
    }

    public static void AddRange<T>(this IList<T> list, Func<T, int, T> itemFactory, int count)
    {
        for (int i = 0; i < count; i++)
        {
            list.Add(itemFactory(list[i], i));
        }
    }

    public static void AddRange<T>(this IList<T> list, Func<T> itemFactory, Func<int, bool> predicate)
    {
        int i = 0;
        while (predicate(i))
        {
            list.Add(itemFactory());
            i++;
        }
    }

    public static void AddRange<T>(this IList<T> list, Func<int, T> itemFactory, Func<int, bool> predicate)
    {
        int i = 0;
        while (predicate(i))
        {
            list.Add(itemFactory(i));
            i++;
        }
    }

    public static void AddRange<T>(this IList<T> list, Func<T, int, T> itemFactory, Func<int, bool> predicate)
    {
        int i = 0;
        while (predicate(i))
        {
            list.Add(itemFactory(list[i], i));
            i++;
        }
    }

}
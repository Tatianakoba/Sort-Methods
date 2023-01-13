using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Класс с методами расширения для определения направление сортировки
/// </summary>
public static class SortExt
{
}
//Проверка упорядоченности по возрастанию
/// <summary>
/// Метод для проверки массива на упорядоченность по возрастанию
/// </summary>
/// <param name="dataSource">Массив данных</param>
/// <returns>true - данные отсортированы по возрастанию, false - в противном случае</returns>
public static bool IsSortedAscending<TSource>(this IList<TSource> dataSource) where TSource : IComparable
{
    for (var index = 0; index < dataSource.Count() - 1; index++)
    {
        if (dataSource[index].CompareTo(dataSource[index + 1]) > 0)
        {
            return false;
        }
    }

    return true;
}
//Проверка упорядоченности по убыванию
/// <summary>
/// Метод для проверки массива на упорядоченность по убыванию
/// </summary>
/// <param name="dataSource">массив данных</param>
/// <returns>true - данные отсортированы по убыванию, false - в противном случае</returns>
public static bool IsSortedDescending<TSource>(this IList<TSource> dataSource) where TSource : IComparable
{
    for (var index = 0; index < dataSource.Count() - 1; index++)
    {
        if (dataSource[index].CompareTo(dataSource[index + 1]) < 0)
        {
            return false;
        }
    }

    return true;
}
//Проверка с возвратом направления сортировки
//В предыдущих методах коллекция данных проверялась на упорядоченность, однако удобно использовать метод, который проверяет массив и отвечает на вопрос в каком направлении отсортированы данные. Для этого добавим перечисление, которое содержит все возможные состояния массива данных:

/// <summary>
/// Направление сортировки
/// </summary>
[Flags]
public enum SourceSortDirection
{
    /// <summary>
    /// Все значения равны
    /// </summary>
    AllEqual = 0b0000,
    /// <summary>
    /// Значения отсортированы по возрастанию
    /// </summary>
    Ascending = 0b0001,
    /// <summary>
    /// Значения отсортированы по убыванию
    /// </summary>
    Descending = 0b0010,
    /// <summary>
    /// Значения не отсортированы
    /// </summary>
    Unsorted = AllEqual | Ascending | Descending
}
//Добавим метод, который проверяет направление сортировки массива:

/// <summary>
/// Метод для получения направления сортировки массива
/// </summary>
/// <typeparam name="TSource">Тип данных массива</typeparam>
/// <param name="dataSource">Входные данные</param>
/// <returns>Направление сортировки</returns>
public static SourceSortDirection SortDirection<TSource>(this IList<TSource> dataSource) where TSource : IComparable
{
    var result = SourceSortDirection.AllEqual;
    for (var index = 0; index < dataSource.Count() - 1; index++)
    {
        var t = dataSource[index].CompareTo(dataSource[index + 1]);
        if (t < 0)
        {
            result |= SourceSortDirection.Ascending;
        }
        else if (t > 0)
        {
            result |= SourceSortDirection.Descending;
        }

        if (result == SourceSortDirection.Unsorted)
        {
            break;
        }
    }

    return result;
}
//Пример использования методов расширения:

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var a = new int[] { 1, 2, 3, 4, 4, 5 };
        var b = new double[] { 9, 8, 7, 7, 6, 5 };
        var c = new List<byte> { 1, 1, 1, 1, 1 };
        var d = new char[] { 'H', 'e', 'l', 'l', 'o', '!' };

        Console.WriteLine(a.IsSortedAscending());
        Console.WriteLine(a.IsSortedDescending());
        Console.WriteLine(a.SortDirection());

        Console.WriteLine(b.IsSortedAscending());
        Console.WriteLine(b.IsSortedDescending());
        Console.WriteLine(b.SortDirection());

        Console.WriteLine(c.IsSortedAscending());
        Console.WriteLine(c.IsSortedDescending());
        Console.WriteLine(c.SortDirection());

        Console.WriteLine(d.IsSortedAscending());
        Console.WriteLine(d.IsSortedDescending());
        Console.WriteLine(d.SortDirection());

        Console.ReadLine();
    }
}

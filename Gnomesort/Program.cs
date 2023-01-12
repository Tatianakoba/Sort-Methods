using System;

class Program
{
    //метод для обмена элементов
    static void Swap(ref int item1, ref int item2)
    {
        var temp = item1;
        item1 = item2;
        item2 = temp;
    }

    //Гномья сортировка
    static int[] GnomeSort(int[] unsortedArray)
    {
        var index = 1;
        var nextIndex = index + 1;

        while (index < unsortedArray.Length)
        {
            if (unsortedArray[index - 1] < unsortedArray[index])
            {
                index = nextIndex;
                nextIndex++;
            }
            else
            {
                Swap(ref unsortedArray[index - 1], ref unsortedArray[index]);
                index--;
                if (index == 0)
                {
                    index = nextIndex;
                    nextIndex++;
                }
            }
        }

        return unsortedArray;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Гномья сортировка");
        Console.Write("Введите элементы массива: ");
        var parts = Console.ReadLine().Split(new[] { " ", ",", ";" }, StringSplitOptions.RemoveEmptyEntries);
        var array = new int[parts.Length];
        for (int i = 0; i < parts.Length; i++)
        {
            array[i] = Convert.ToInt32(parts[i]);
        }

        Console.WriteLine("Отсортированный массив: {0}", string.Join(", ", GnomeSort(array)));

        Console.ReadLine();
    }
}
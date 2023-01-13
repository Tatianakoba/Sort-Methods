using System;

class Program
{
    //метод обмена элементов
    static void Swap(ref int value1, ref int value2)
    {
        var temp = value1;
        value1 = value2;
        value2 = temp;
    }

    //метод для генерации следующего шага
    static int GetNextStep(int s)
    {
        s = s * 1000 / 1247;
        return s > 1 ? s : 1; //Условный оператор ?:, также называемый тернарным, вычисляет логическое выражение и в зависимости от полученного значения true
                              //или false возвращает результат одного из двух соответствующих выражений
                              //condition ? consequent : alternative
                              //Выражение condition должно принимать значение true или false.Если condition принимает значение true,
                              //вычисляется выражение consequent, а результат становится результатом операции.Если condition принимает значение false,
                              //вычисляется выражение alternative, а результат становится результатом операции.Вычисляется только выражение consequent или alternative.
                              //Таким образом: Если s>1, то s     НО если s<1, то 1
    }

    static int[] CombSort(int[] array)
    {
        var arrayLength = array.Length;
        var currentStep = arrayLength - 1;

        while (currentStep > 1)
        {
            for (int i = 0; i + currentStep < array.Length; i++)
            {
                if (array[i] > array[i + currentStep])
                {
                    Swap(ref array[i], ref array[i + currentStep]);
                }
            }

            currentStep = GetNextStep(currentStep);
        }

        //сортировка пузырьком
        for (var i = 1; i < arrayLength; i++)
        {
            var swapFlag = false;
            for (var j = 0; j < arrayLength - i; j++)
            {
                if (array[j] > array[j + 1])
                {
                    Swap(ref array[j], ref array[j + 1]);
                    swapFlag = true;
                }
            }

            if (!swapFlag) //если свопов не было - выходим
            {
                break;
            }
        }

        return array;
    }

    //метод для получения массива заполненного случайными числами
    static int[] GetRandomArray(int length, int minValue, int maxValue)
    {
        var r = new Random();
        var outputArray = new int[length];
        for (var i = 0; i < outputArray.Length; i++)
        {
            outputArray[i] = r.Next(minValue, maxValue);
        }

        return outputArray;
    }

    static void Main(string[] args)
    {
        var arr = GetRandomArray(15, 0, 10);
        Console.WriteLine("Входные данные: {0}", string.Join(", ", arr));
        Console.WriteLine("Отсортированный массив: {0}", string.Join(", ", CombSort(arr)));
        Console.ReadLine();
    }
}
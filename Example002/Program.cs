/*
Задача 2: Задайте прямоугольный двумерный массив. Напишите программу,
которая будет находить строку с наименьшей суммой элементов.
*/

int Prompt(string message) // Ввод числа ( функция )
{
    Console.Write(message);
    string a_String = Console.ReadLine();
    return int.Parse(a_String);
}

int[,] GenerateMultiArray(int row, int column, int min, int max) // Заполнение случайными числами 2-х мерного массива. row - количество строк, column - количество колонок, min - минимальное генерируемое число, max - максимальное генерируемое число.
{
    var array = new int[row, column];
    var rnd = new Random();

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = rnd.Next(min, max + 1);
        }
    }

    return array;
}

void PrintMultiArray(int[,] array) // Запись многомерного массива в консоль.
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (j == 0) Console.Write("[");

            if (j < array.GetLength(1) - 1) Console.Write(array[i, j] + ",");

            if (j == array.GetLength(1) - 1) Console.Write(array[i, j] + "]");
        }
        Console.WriteLine("");
    }

}

(int, int ) MinSumRowMultiArray(int[,] multiArray) // Нахождение строки с минимальной суммой элементов
{
    int row = multiArray.GetLength(0);
    int column = multiArray.GetLength(1);

    int[] array = new int[row];

    for (int i = 0; i < row; i++) // Нахождение сумы чисел строк
    {
        for (int j = 0; j < column; j++)
        {
            array[i] += multiArray[i, j];
        }
    }

    int min = array[0];
    int minRow = 0;

    for (int i = 0; i < row; i++) // Нахождение минимального значения строки
    {
        if (min > array[i])
        {
            min = array[i];
            minRow = i ;
        }
    }
    return (minRow+1, min);
}




System.Console.WriteLine("Размер массива");
int row = Prompt("Количество строк => ");

int column = Prompt("Количество столбцов => ");

int[,] array = GenerateMultiArray(row, column, 0, 5);

PrintMultiArray(array);
System.Console.WriteLine("");

 
(int number, int minSum ) = MinSumRowMultiArray(array);

System.Console.WriteLine($"В массиве строка с минимальной суммой {minSum} равняется => {number}");
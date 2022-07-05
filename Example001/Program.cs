/*
Задача 1: Задайте двумерный массив. Напишите программу, которая
упорядочит по убыванию элементы каждой строки двумерного массива.
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

int[,] OrderingArray(int[,] array) // Функция упорядочивания по убыванию строк 2-х мерного массива
{
    int row = array.GetLength(0);
    int column = array.GetLength(1);

    for (int i = 0; i < row; i++)
    {
        int n = 0; int j = n;
        int max = array[i, n];

        while (n < column)
        {
            if (j == n) max = array[i, n];
            if (array[i, j] > max)
            {
                max = array[i, j];
                array[i, j] = array[i, n];
                array[i, n] = max;
            }
            j++;
            if (j == (column))
            {
                n++;
                j = n;
            }

        }

    }

    return array;
}

System.Console.WriteLine("Размер массива");
int row = Prompt("Количество строк => ");

int column = Prompt("Количество столбцов => ");

int[,] array = GenerateMultiArray(row, column, 0, 100);

PrintMultiArray(array);
System.Console.WriteLine("");

int[,] newArray = OrderingArray(array);

PrintMultiArray(newArray);




/*
Задайте две матрицы. Напишите программу, которая будет
находить произведение двух матриц.
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

(int [,], bool) MatrixSum (int [,] array1, int [,] array2)
{
    int row1 = array1.GetLength(0);
    int row2 = array2.GetLength(0);
    int column1 = array1.GetLength(1);
    int column2 = array2.GetLength(1);
    int [,] newArray = new int[row1,column2];

    if (column1 != row2 ) return ( newArray, false);

    for (int i = 0; i < row1; i++)
    {
        for (int j = 0; j < column2; j++)
        {
            for (int k = 0; k < column1; k++)
            {
                newArray[i,j] =array1[i,k]*array2[k,j]+ newArray[i,j];
            }
                 
        }
    }
    
return (newArray, true);
}




System.Console.WriteLine("Размер матрицы A");
int rowMatricaA = Prompt("Количество строк => ");

int columnMatricaA = Prompt("Количество столбцов => ");

System.Console.WriteLine("Размер матрицы B");
int rowMatricaB = Prompt("Количество строк => ");

int columnMatricaB = Prompt("Количество столбцов => ");

int minRandom = 0;
int maxRandom = 10;

int[,] arrayA = GenerateMultiArray(rowMatricaA, columnMatricaA, minRandom, maxRandom);

PrintMultiArray(arrayA);
System.Console.WriteLine("");

int[,] arrayB = GenerateMultiArray(rowMatricaB, columnMatricaB, minRandom, maxRandom);

PrintMultiArray(arrayB);
System.Console.WriteLine("");

(int [,] arrayC, bool result) = MatrixSum(arrayA,arrayB);

if ( result== false) System.Console.WriteLine("Размеры матриц не корректны, из-за этого они не могут иметь произведение");
else
{
    System.Console.WriteLine("Произведение матриц равняется => ");
    System.Console.WriteLine();
    PrintMultiArray(arrayC);
}
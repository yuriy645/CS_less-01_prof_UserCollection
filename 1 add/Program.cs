using System;
using System.Collections;
using System.Collections.Generic;

namespace _1_add
{// Создайте метод, который в качестве аргумента принимает массив целых чисел и возвращает
 // коллекцию квадратов всех нечетных чисел массива.Для формирования коллекции
 //  используйте оператор yield.
    class Program
    {
        static IEnumerable GetSquare(int[] myArray)
        {
            for (int i = 0; i < myArray.Length; i++)

                if (myArray[i] % 2 != 0)
                    yield return myArray[i]* myArray[i];                    
        }

        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            IEnumerable сollection = GetSquare(arr);


            foreach (int element in сollection)
            {
                Console.WriteLine("{0} ", element);
            }
        }
    }

}

    

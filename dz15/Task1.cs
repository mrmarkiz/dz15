using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz15
{
    internal class Task1
    {
        public static void Run()
        {
            Random rnd = new Random();
            int[] array = new int[100];
            for (int i = 0; i < 100; i++)
            {
                array[i] = rnd.Next(200);
            }
            StringBuilder pathSimple = new StringBuilder("\\simpleNumbers.txt"), pathFibonacci = new StringBuilder("\\fibonacciNumbers.txt");
            ProcessNumbers(array, pathSimple, pathFibonacci);
            Console.WriteLine("Array elements:");
            Show(array);
            Console.WriteLine($"Number of simple numbers: {Count(pathSimple)}\nNumber of Fibonacci numbers: {Count(pathFibonacci)}");
        }

        public static void Show(int[] array)
        {
            foreach(int i in array)
                Console.Write($"{i}\t");
            Console.WriteLine();
        }

        public static int Count(StringBuilder path)
        {            
            using (FileStream fs = new FileStream(path.ToString(), FileMode.OpenOrCreate))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    return sr.ReadToEnd().Split('\n').Length;
                }
            }
        }

        public static void ProcessNumbers(int[] numbers, StringBuilder pathSimple, StringBuilder pathFibonacci)
        {
            using (FileStream fsSimple = new FileStream(pathSimple.ToString(), FileMode.Append), fsFibonacci = new FileStream(pathFibonacci.ToString(), FileMode.Append))
            {
                using (StreamWriter swSimple = new StreamWriter(fsSimple), swFibonacci = new StreamWriter(fsFibonacci))
                {
                    foreach(int number in numbers)
                    {
                        if(IsSimple(number))
                            swSimple.WriteLine(number);
                        if (IsFibonacci(number))
                            swFibonacci.WriteLine(number);
                    }
                }
            }
        }

        private static bool IsSimple(int number)
        {
            if(number < 0)
                return false;
            int divs = 0;
            for (int i = 1; i <= Math.Sqrt(number); i++)
                if (number % i == 0)
                    divs++;
            return divs <= 1;
        }
        private static bool IsFibonacci(int number)
        {
            int a = 0, b = 1, c = 1, tmp;
            while (a < number)
            {
                tmp = b + c;
                a = b;
                b = c;
                c = tmp;
            }
            return a == number;
        }
    }
}

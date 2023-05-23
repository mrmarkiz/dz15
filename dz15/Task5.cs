using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz15
{
    internal class Task5
    {
        public static void Run()
        {
            Console.WriteLine("Enter path to the file with numbers:");
            StringBuilder path = new StringBuilder(Console.ReadLine());
            GenStatistics(path);
            ShowStatistics(path);
        }
        public static void ShowStatistics(StringBuilder path)
        {
            Console.WriteLine("General numbers of words in file: " + Count(path));
            Console.WriteLine($"Plus numbers: {Count(new StringBuilder("\\plus_numbers.txt"))}" +
                $"\nMinus numbers: {Count(new StringBuilder("\\minus_numbers.txt"))}" +
                $"\n2-digit numbers: {Count(new StringBuilder("\\two-digit_numbers.txt"))}" +
                $"\n5-digit numbers: {Count(new StringBuilder("\\five-digit_numbers.txt"))}");
        }

        public static void GenStatistics(StringBuilder path)
        {
            string[] numbers = new string[0];
            try
            {
                using (FileStream fs = new FileStream(path.ToString(), FileMode.Open))
                {
                }
            }
            catch
            {
                Init(path);
            }
            finally
            {
                using (FileStream fs = new FileStream(path.ToString(), FileMode.Open))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        numbers = sr.ReadToEnd().Split('\n');
                    }
                }
                int num;
                using (FileStream fsPlus = new FileStream("\\plus_numbers.txt", FileMode.OpenOrCreate), fsMinus = new FileStream("\\minus_numbers.txt", FileMode.OpenOrCreate))
                {
                    using (StreamWriter swPlus = new StreamWriter(fsPlus), swMinus = new StreamWriter(fsMinus))
                    {
                        for (int i = 0; i < numbers.Length; i++)
                        {
                            if (int.TryParse(numbers[i], out num))
                            {
                                if (num < 0)
                                    swMinus.WriteLine(num);
                                else
                                    swPlus.WriteLine(num);
                            }
                        }
                    }
                }
                using (FileStream fsTwoDigit = new FileStream("\\two-digit_numbers.txt", FileMode.OpenOrCreate), fsFiveDigit = new FileStream("\\five-digit_numbers.txt", FileMode.OpenOrCreate))
                {
                    using (StreamWriter swTwoDigits = new StreamWriter(fsTwoDigit), swFiveDigit = new StreamWriter(fsFiveDigit))
                    {
                        for (int i = 0; i < numbers.Length; i++)
                        {
                            if (int.TryParse(numbers[i], out num))
                            {
                                if (num / 10 != 0 && num / 100 == 0)
                                    swTwoDigits.WriteLine(num);
                                else if (num / 10_000 != 0 && num / 100_000 == 0)
                                    swFiveDigit.WriteLine(num);
                            }
                        }
                    }
                }
            }
        }

        public static void Init(StringBuilder path)
        {
            Random rnd = new Random();
            using (FileStream fs = new FileStream(path.ToString(), FileMode.OpenOrCreate))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    for (int i = 0; i < 100_000; ++i)
                    {
                        sw.WriteLine(rnd.Next(-100_000, 100_001));
                    }
                }
            }
        }
        public static int Count(StringBuilder path)
        {
            using (FileStream fs = new FileStream(path.ToString(), FileMode.OpenOrCreate))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    return sr.ReadToEnd().Split('\n').Length - 1;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz15
{
    internal class Task3
    {
        public static void Run()
        {
            Console.WriteLine("Enter path to file with text for moderating:");
            StringBuilder pathText = new StringBuilder(Console.ReadLine());
            Console.WriteLine("Enter path to file with word to moderate:");
            StringBuilder pathModers = new StringBuilder(Console.ReadLine());
            Console.WriteLine("Content of text file before moderating:");
            Show(pathText);



        }

        public static void Moderate(StringBuilder pathText, StringBuilder pathModers)
        {

        }

        public static void Show(StringBuilder path)
        {
            using (FileStream fs = new FileStream(path.ToString(), FileMode.OpenOrCreate))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
        }
    }
}

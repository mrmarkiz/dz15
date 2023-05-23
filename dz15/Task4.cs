using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz15
{
    internal class Task4
    {
        public static void Run()
        {
            Console.WriteLine("Enter the path to the file to reverse:");
            StringBuilder path = new StringBuilder(Console.ReadLine());
            Console.WriteLine("Original file content before:");
            Show(path);
            StringBuilder copyPath = new StringBuilder(path.ToString().Insert(path.Length - 4, "(reversed)"));
            Reverse(path, copyPath);
            Console.WriteLine("\nCopy file content after changes:");
            Show(copyPath);

        }

        public static void Reverse(StringBuilder path, StringBuilder copyPath)
        {
            StringBuilder contents = new StringBuilder();
            using (FileStream fsSource = new FileStream(path.ToString(), FileMode.OpenOrCreate), fsCopy = new FileStream(copyPath.ToString(), FileMode.OpenOrCreate))
            {
                using (StreamReader sr = new StreamReader(fsSource))
                {
                    contents = new StringBuilder(sr.ReadToEnd());
                }
                contents = new StringBuilder(new string(contents.ToString().Reverse().ToArray()));
                using (StreamWriter sw = new StreamWriter(fsCopy))
                {
                    sw.Write(contents.ToString());
                }
            }
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

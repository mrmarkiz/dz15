using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace dz15
{
    internal class Task2
    {
        public static void Run()
        {
            StringBuilder path = new StringBuilder("\\replace_word.txt");
            Console.WriteLine("File content:");
            Show(path);
            Console.Write("Enter the word to change: ");
            StringBuilder word = new StringBuilder(Console.ReadLine());
            Console.Write("Enter the exchange word: ");
            StringBuilder exchangeWord = new StringBuilder(Console.ReadLine());
            int numOfChanges = ChangeWord(path, word, exchangeWord);
            Console.WriteLine("File content after replacement:");
            Show(path);
            Console.WriteLine($"Number of changed words: {numOfChanges}");
        }

        public static int Count(StringBuilder text, StringBuilder word)
        {
            string[] words = text.ToString().Split(new char[] { ',', '.', ' ', '?', '!', ':', ';' });
            return words.Count(str => str == word.ToString());
        }

        public static int ChangeWord(StringBuilder path, StringBuilder word, StringBuilder changedWord)
        {
            int counter = 0;
            if (word.ToString() == "")
                return counter;
            StringBuilder contents = new StringBuilder();
            using (FileStream fs = new FileStream(path.ToString(), FileMode.OpenOrCreate))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    contents = new StringBuilder(sr.ReadToEnd());
                    counter = Count(contents, word);
                    contents = contents.Replace(word.ToString(), changedWord.ToString());
                }
            }
            using (FileStream fs = new FileStream(path.ToString(), FileMode.OpenOrCreate))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(contents.ToString());
                }
            }
            return counter;
        }

        public static void Show(StringBuilder path)
        {
            using (FileStream fs = new FileStream(path.ToString(), FileMode.OpenOrCreate))
            {
                using(StreamReader sr = new StreamReader(fs))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
        }
    }
}

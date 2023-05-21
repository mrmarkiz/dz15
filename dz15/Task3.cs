using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            Moderate(pathText, pathModers);
            Console.WriteLine("Content of text after moderating:");
            Show(pathText);
        }

        public static void Moderate(StringBuilder pathText, StringBuilder pathModers)
        {
            using (FileStream fs = new FileStream(pathModers.ToString(), FileMode.OpenOrCreate))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string[] content = sr.ReadToEnd().Split(new char[] { ' ', ',', '.', '\n', '\r', ';', ':', '!', '\t', '?' });
                    foreach (string word in content)
                        ChangeWord(pathText, new StringBuilder(word), new StringBuilder(new string('*', word.Length)));
                }
            }
        }

        public static bool IsSeparator(char ch)
        {
            return ch == ' ' || ch == ',' || ch == ';' || ch == '.' || ch == '!' || ch == '?' || ch == ':' || ch == '\n' || ch == '\r' || ch == '\t';
        }

        public static void ChangeWord(StringBuilder path, StringBuilder word, StringBuilder changedWord)
        {
            if (word.ToString() == "")
                return ;

            StringBuilder contents = new StringBuilder();
            using (FileStream fs = new FileStream(path.ToString(), FileMode.OpenOrCreate))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    contents = new StringBuilder(sr.ReadToEnd());
                    int miniCounter;
                    for (int i = 0; i < contents.Length; i++)
                    {
                        miniCounter = 0;
                        if (contents[i] == word.ToString()[0] && (i == 0 || IsSeparator(contents[i - 1])))
                        {
                            for (; i < contents.Length && miniCounter < word.Length && contents[i] == word[miniCounter]; i++, miniCounter++)
                            { }
                            if (miniCounter == word.Length && (i == contents.Length || IsSeparator(contents[i])))
                            {
                                contents = contents.Replace(word.ToString(), changedWord.ToString(), i - miniCounter, word.Length);
                                i += changedWord.Length - word.Length;
                            }
                        }
                    }
                }
            }
            using (FileStream fs = new FileStream(path.ToString(), FileMode.OpenOrCreate))
            {
                using (StreamWriter sw = new StreamWriter(fs))
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

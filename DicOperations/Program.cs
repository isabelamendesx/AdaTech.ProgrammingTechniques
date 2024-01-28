using System.ComponentModel.Design;
using System.Diagnostics.Tracing;

namespace DicOperations
{
    public class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Enter a text to count the words");
                var input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Your text is null or empty. Please enter a valid text.");
                    continue;
                }

                var dic = WordCount(input);

                Console.Clear();
                Console.WriteLine("Word Count:");
                foreach (var entry in dic)
                {
                    Console.WriteLine($"{entry.Key}: {entry.Value}");
                }

                Console.WriteLine("Do you want to check another text? Press Y or any other key to exit");

            } while (Console.ReadLine().ToUpper() == "Y");
        }

        static Dictionary<string, int> WordCount(string text)
        {
            var dic = new Dictionary<string, int>();

            char[] delimiters = { ' ', ',', '.' };

            string[] words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                if (dic.ContainsKey(word))
                {
                    dic[word]++;
                    continue;
                }
                
                dic.Add(word, 1);
            }

            return dic;
        }
    }
}

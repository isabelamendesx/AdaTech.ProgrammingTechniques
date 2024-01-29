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
                    // Só acrescentando um tempo para que o usuário consiga ler a mensagem antes de limpar a tela
                    Thread.Sleep(2000);
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

            // Assume todo o texto como em minúsculas para incluir na contagem todas as ocorrência independentemente da capitulação
            string[] words = text.ToLowerInvariant().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

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

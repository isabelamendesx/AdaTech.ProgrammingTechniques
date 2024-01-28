using System.Reflection.Metadata.Ecma335;

namespace ListOperations;

public class Program
{
    static void Main(string[] args)
    {
        var input = new List<string>{
              "Idiossincrasia",
              "Ambivalente",
              "Quimérica",
              "Perpendicular",
              "Efêmero",
              "Pletora",
              "Obnubilado",
              "Xilografia",
              "Quixote",
              "Inefável"
        };

        foreach (var longWord in FilterLongWords(input, 10))
        {
            Console.WriteLine(longWord);
        }

    }

    static IEnumerable<string> FilterLongWords(List<string> input, int length)
    {

        foreach (var word in input)
        {
            if (word.Length >= length)
            {
                yield return word;
            }

        }
    }
}

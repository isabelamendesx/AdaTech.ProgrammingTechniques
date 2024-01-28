using System.Text;

namespace StackOperations;

public class Program
{
    static void Main(string[] args)
    {
        do
        {
            Console.Clear();
            Console.WriteLine("Enter a expression to check if it's balanced");
            var expression = Console.ReadLine();

            if (string.IsNullOrEmpty(expression))
            {
                Console.WriteLine("Expression is null or empty. Please enter a valid expression.");
                continue;
            }

            DisplayResult(expression);
            Console.WriteLine("Do you want to check another expression? press Y or any other key to exit");

        } while (Console.ReadLine().ToUpper() == "Y");
    }

    static void DisplayResult(string expression)
    {
        Console.WriteLine($"Cleaning expression: {expression}");
        var cleanedExpression = CleanExpression(expression);

        if (IsExpressionBalanced(cleanedExpression))
        {
            Console.WriteLine($"{expression} is balanced :)");
        }
        else
        {
            Console.WriteLine($"{expression} is not balanced :(");
        }
    }

    static string CleanExpression(string expression)
    {
        var validChars = new HashSet<char> { '(', '{', '[', ')', '}', ']' };
        var cleanedExpression = new StringBuilder();

        foreach(var c in expression)
        {
            if(validChars.Contains(c)){
                cleanedExpression.Append(c);
            }
        }

        return cleanedExpression.ToString();
    }

    static bool IsExpressionBalanced(string expression)
    {
        var stack = new Stack<char>();
        HashSet<char> openingChars = new HashSet<char> { '(', '{', '[' };

        foreach(var c in expression)
        {
            if (openingChars.Contains(c))
            {
                stack.Push(c);
            }
            else if(stack.Count == 0 || !TryMatchPair(stack.Pop(), c))
            {
                return false;
            }
        }

        return stack.Count == 0;
    }

    static bool TryMatchPair(char open, char close)
    {
        return (open == '(' && close == ')') ||
           (open == '{' && close == '}') ||
           (open == '[' && close == ']');
    }

}


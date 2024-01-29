namespace QueueOperations;

public class Program
{
    static void Main(string[] args)
    {
        do
        {
            Console.Clear();
            Console.WriteLine("Type the number of players");
            int numberPlayers;

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out numberPlayers))
                {
                    Console.WriteLine($"You entered {numberPlayers} players.\n");
                    break; 
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }

            HotPotatoGame(numberPlayers);


            Console.WriteLine("Do you want to play again? Press Y or any other key to exit");

        } while (Console.ReadLine()?.ToUpper() == "Y");
    }

    static void HotPotatoGame(int numberPlayers)
    {
        var playersQueue = new Queue<string>();

        for (int i = 0; i < numberPlayers; i++)
        {
            playersQueue.Enqueue($"Player {i + 1}");
        }

        var randomTimes = new Random().Next(1, 101);

        while(playersQueue.Count > 1) { 

            Console.WriteLine($"Starting the game with {playersQueue.Count} players...");

            for (int i = 0; i < randomTimes; i++)
            {
                string currentPlayer = playersQueue.Dequeue();
                playersQueue.Enqueue(currentPlayer);
            }

            string loserPlayer = playersQueue.Dequeue();
            Console.WriteLine($"The potato exploded for {loserPlayer}");
        }

        string winningPlayer = playersQueue.Dequeue();
        Console.WriteLine($"Player {winningPlayer} won the game!");
    }
}

namespace CastTheDice;

class Program
{
    static readonly Random rnd = new();
    static int game = 1;

    static void Main()
    {
        
        Console.WriteLine("Välkommen till spelet Cast the Dice, målet är att få summan på tärningarna till 12!");
        Console.WriteLine("För att avbryta spelet tryck på tangenten x.");
        
        Console.WriteLine("*****************************************");
        Console.WriteLine("Spelomgång: {0}", game);
        Console.WriteLine("*****************************************");
        Console.WriteLine("Tryck Enter för att kasta tärningarna...");

        while (true)
        {
            var input = Console.ReadLine();

            if (input != "x")
            {
                int die1 = rnd.Next(1, 7);
                int die2 = rnd.Next(1, 7);
                int total = die1 + die2;

                Console.WriteLine($"Tärning 1: {die1}");
                Console.WriteLine($"Tärning 2: {die2}");
                Console.WriteLine($"Summa: {total}");

                if (total == 12)
                {
                    Console.WriteLine("Grattis, du har vunnit!");

                    Console.WriteLine("Vill du spela igen? y/n");

                    if (Console.ReadLine()! == "y")
                    {
                        game++;
                        Console.WriteLine("");
                        Console.WriteLine("*****************************************");
                        Console.WriteLine("Spelomgång: {0}", game);
                        Console.WriteLine("*****************************************");
                        Console.WriteLine("Tryck Enter för att kasta tärningarna...");

                        continue;
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }
                else
                {
                    Console.WriteLine("Tyvärr, det blev inte 12. Försök igen!");
                    Console.WriteLine("Tryck Enter för att kasta igen (eller x för att avsluta)...");
                }
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}

namespace Task_5th_ATE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ATE ate = new ATE();

            //Create subscribers
            for (int i = 0; i < 4; i++)
            {
                ate.CreateSubscriber($"FirstName{i}", $"SecondName{i}", $"LastName{i}");
            }

            //Subscribers call
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Results of subscribers' calls");
            Console.ResetColor();

            for (int i = 0; i < 2; i++)
            {
                for (int j = 2; j < 4; j++)
                {
                    ate.Subscribers[i].Call(ate.Subscribers[j].PhoneNumber.Number);
                }

                ate.Subscribers[i].Call(Guid.NewGuid());
            }

            //All call logs
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("\nCall logs:");
            Console.ResetColor();

            foreach (var subscriber in ate.Subscribers)
            {
                foreach (var log in subscriber.CallLogs)
                {
                    Console.WriteLine($"{subscriber.FirstName} - {subscriber.SecondName}- {subscriber.SecondName}");
                    Console.WriteLine(log);
                }
            }

            //Subscribers print sorted call by cost
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("\nPrint sorted call logs by Subscriber:");
            Console.ResetColor();

            foreach (var subscriber in ate.Subscribers)
            {
                Console.WriteLine($"{subscriber.FirstName} - {subscriber.SecondName}- {subscriber.SecondName}");

                subscriber.PrintSortedCallLogs(SortBy.Cost);
            }


        }
    }
}
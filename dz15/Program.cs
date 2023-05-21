namespace dz15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.Write("Enter task to run: ");
                int.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        Task1.Run();
                        break;
                    case 2:
                        Task2.Run();
                        break;

                }
            } while (choice != 0);
        }
    }
}
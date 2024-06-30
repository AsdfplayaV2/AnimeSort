using AnimeSort.Logic;

namespace AnimeSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            run();
        }

        private static void test()
        {
            Sorter MySorter = new(@"G:\[1] Move");
            MySorter.SetLogger(Console.WriteLine);
            if (MySorter.GetFiles())
            {
                if (MySorter.GetGroups())
                {
                    if (MySorter.MoveFiles())
                    {
                        Console.WriteLine("Success");
                    }
                    else
                    {
                        Console.WriteLine("Couldn't move Files");
                    }
                }
                else
                {
                    Console.WriteLine("Couldn't Group Files");
                }
            }
            else
            {
                Console.WriteLine("Couldn't collect Files");
            }

        }

        private static void run()
        {
            string? inputString = "";
            while (true)
            {
                Console.Write("Provide Path: ");
                inputString = Console.ReadLine();
                if (inputString == "quit")
                {
                    break;
                }
                Sorter MySorter = new(inputString);
                MySorter.SetLogger(Console.WriteLine);
                if (MySorter.GetFiles())
                {
                    if (MySorter.GetGroups())
                    {
                        Console.WriteLine("Move Files? (y/N)");
                        inputString = Console.ReadLine();
                        if (inputString == "y" || inputString == "Y")
                        {
                            if (MySorter.MoveFiles())
                            {
                                Console.WriteLine("Success");
                            }
                            else
                            {
                                Console.WriteLine("Couldn't move Files");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Couldn't Group Files");
                    }
                }
                else
                {
                    Console.WriteLine("Couldn't collect Files");
                }
            }
        }
    }
}
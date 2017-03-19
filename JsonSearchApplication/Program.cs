using System;


namespace JsonSearchApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            SearchApplication.startApplication();
            String userInput = Console.ReadLine();
            Console.WriteLine(userInput);
            //searchTheJsonFile("_id","1","users");
        }
    }
}

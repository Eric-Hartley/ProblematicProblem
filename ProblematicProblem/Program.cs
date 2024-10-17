using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    public class Program 
    {
        
        public static void Main(string[] args)
        {
            var user = new User();
            Random rng = new Random();
            bool cont;
            bool seeList;
            bool addToList;
            List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };

            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            
            var start = Console.ReadLine();

            if (start != null && start.ToLower() == "yes")
            {
                cont = true;

                Console.WriteLine("First, we just need to get some information.");
                Console.WriteLine("What is your name?");
                user.Name = Console.ReadLine();
                Console.WriteLine("What is your age?");
                user.Age = int.Parse(Console.ReadLine());

                //Console.WriteLine($"{user.Name} : {user.Age}");
                
                Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
                var inputSeeList = Console.ReadLine();

                if (inputSeeList != null && inputSeeList.ToLower() == "sure")
                {
                    seeList = true;
                    Console.WriteLine("Here is the list of activities: ");
                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }
                    Console.WriteLine();
                }
                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                var inputAddActs = Console.ReadLine();
                if (inputAddActs != null && inputAddActs == "yes")
                {
                    addToList = true;
                    while (addToList)
                    {
                        Console.Write("What would you like to add? ");

                        string userAddition = Console.ReadLine();
                        activities.Add(userAddition);

                        foreach (string activity in activities)
                        {
                            Console.Write($"{activity} ");
                            Thread.Sleep(250);
                        }

                        Console.WriteLine();

                        Console.WriteLine("Would you like to add more? yes/no: ");
                        var inputAddMore = Console.ReadLine();
                        if (inputAddMore != null && inputAddMore.ToLower() == "yes")
                        {
                            addToList = true;
                        }
                        else
                        {
                            addToList = false;
                        }


                    }
                }
                
                while (cont)
                {
                    Console.Write("Connecting to the database");
                    for (int i = 0; i < 10; i++)
                    {
                        Console.Write(". ");
                        Thread.Sleep(500);
                    }
                    Console.WriteLine();
                    Console.Write("Choosing your random activity");
                    for (int i = 0; i < 9; i++)
                    {
                        Console.Write(". ");
                        Thread.Sleep(500);
                    }
                    Console.WriteLine();

                    int randomNumber = rng.Next(activities.Count);
                    string randomActivity = activities[randomNumber];

                    if (user.Age < 21 && randomActivity == "Wine Tasting")
                    {
                        Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                        Console.WriteLine("Pick something else!");
                        activities.Remove(randomActivity);
                    }
                    else
                    {
                        Console.Write($"Ah got it! {user.Name}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                        Console.WriteLine();
                        var inputContinue = Console.ReadLine();
                        if (inputContinue != null && inputContinue.ToLower() == "keep")
                        {
                            cont = false;
                        }
                    }
                    
                }
            }
        }
    }
}
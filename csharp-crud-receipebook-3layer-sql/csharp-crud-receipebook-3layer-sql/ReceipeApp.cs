using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Services;
using Persistence.Models;

namespace csharp_crud_receipebook_3layer_sql
{
    internal class ReceipeApp
    {
        private readonly IReceipeService _receipeService;

        public ReceipeApp(IReceipeService receipeService)
        {
            _receipeService = receipeService;
        }

        public ReceipeApp()
        {
        }

        public void Start()
        {
            string name;
            string description;
            string difficulty; // should be enum
            int timeToComplete; // should be TimeSpan
            int id;

            while (true)
            {
                Console.WriteLine("Available commands:");
                Console.WriteLine("1 - Show all receipes");
                Console.WriteLine("2 - Create receipe");
                Console.WriteLine("3 - Edit receipe");
                Console.WriteLine("4 - Delete receipe");
                Console.WriteLine("5 - Delete all receipes");
                Console.WriteLine("6 - Exit");

                var chosenCommand = Console.ReadLine();
                switch (chosenCommand)
                {
                    case "1":
                        var allReceipes = _receipeService.GetAll();
                        foreach (var receipe in allReceipes)
                        {
                            Console.WriteLine(receipe);
                        }
                        break;

                    case "2":
                        Console.WriteLine("Enter receipe Name:");
                        name = Console.ReadLine();
                        Console.WriteLine("Enter receipe Description: ");
                        description = Console.ReadLine();
                        Console.WriteLine("Enter receipe Difficulty: ");
                        difficulty = Console.ReadLine(); // should be enum
                        Console.WriteLine("Enter receipe Duration: ");
                        timeToComplete = Convert.ToInt32(Console.ReadLine()); // should be TimeSpan
                        _receipeService.Create(new Receipe
                        {
                            Name = name,
                            Description = description,
                            Difficulty = difficulty,
                            Time_To_Complete = timeToComplete,
                            Date_Created = DateTime.Now
                        });
                        break;

                    case "3":
                        Console.WriteLine("Enter receipe ID");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter new receipe Name");
                        name = (Console.ReadLine());
                        Console.WriteLine("Enter new receipe Description");
                        description = (Console.ReadLine());
                        _receipeService.Edit(id, name, description);
                        break;

                    case "4":
                        Console.WriteLine("Enter receipe ID:");
                        id = Convert.ToInt32(Console.ReadLine());
                        _receipeService.DeleteById(id);
                        break;

                    case "5":
                        _receipeService.ClearAll();
                        break;

                    case "6":
                        return;
                }
            }
        }
    }
}
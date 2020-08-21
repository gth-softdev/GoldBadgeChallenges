using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramUI_ChallOne
{
    class ChallOne_ProgramUI

    {
        private MenuRepository _menuRepository = new MenuRepository();
        private bool _isRunning = true;
        public void Start()
        {
            RunMenu();
        }

        private void RunMenu()
        {
            while (_isRunning)
            {
                string userInput = GetMenuOption();
                ActOnMenuOption(userInput);
            }
        }
        private string GetMenuOption()
        {
            Console.Clear();
            Console.WriteLine(
                            "Please make a selection:\n" +
                            "1. Create menu items.\n" +
                            //"2. Update menu items.\n" +
                            "2. Delete menu items.\n" +
                            "3. Display all menu items.\n" +
                            "4. Exit.");

            string userInput = Console.ReadLine();
            return userInput;
        }

        public void ActOnMenuOption(string userInput)
        {
            switch (userInput)
            {
                case "1":
                    CreateMenuItems();
                    break;
                //case "2":
                    //UpdateMenuItems();
                  //  break;
                case "2":
                    DeleteMenuItems();
                    break;
                case "3":
                    DisplayAllItems();
                    break;
                case "4":
                    _isRunning = false;
                    break;
                default:
                    break;
            }
        }

        private void CreateMenuItems()
        {
            Console.Clear();
            List<ChallOne_MenuContent> allMenuContent = _menuRepository.GetDirectory();
            ChallOne_MenuContent newContent = new ChallOne_MenuContent();
            Console.Write("Enter the Menu Item number this will be: ");
            var inputTwo = Console.ReadLine();
            var getValidNumber = false;
            while (!getValidNumber)
            {
                getValidNumber = int.TryParse(inputTwo, out _);
                if (getValidNumber)
                {
                    break;
                }
                else
                {
                    Console.Write("Please enter a number: ");
                    inputTwo = Console.ReadLine();
                }
            }

                var inputNum = int.Parse(inputTwo);


            foreach (ChallOne_MenuContent content in allMenuContent)
            {
                while (true)
                {
                    if (content.MenuItemNumber == inputNum)
                    {
                        Console.WriteLine("This menu item number is already in the list. Please enter a different menu item number: ");
                        inputNum = int.Parse(Console.ReadLine());
                    }
                    break;
                }
            }

            newContent.MenuItemNumber = inputNum;

            Console.Write("Enter the Meal Name for the menu item: ");
            newContent.MenuItemName = Console.ReadLine();

            Console.Write("Enter a description for this menu item: ");
            newContent.MenuItemDesc = Console.ReadLine();

            List<string> ingred = new List<string>();
            while (true)
            {
                Console.Write("Enter an ingredient: ");
                var inputIngred = Console.ReadLine();
                ingred.Add(inputIngred);
                foreach (var item in ingred)
                {
                    Console.Write($"{item}\n");
                }
                Console.Write("Are there more ingredients? (y/n)");
                string input = Console.ReadLine().ToLower();
                if (input == "n")
                {
                    break;
                }
            }
            newContent.MenuItemIngredients = ingred;
            Console.WriteLine("Enter the price for this menu item: ");

            var inputPrice = Console.ReadLine();
            var getValidPrice = false;
            while (!getValidPrice)
            {
                getValidPrice = decimal.TryParse(inputPrice, out _);
                if (getValidPrice)
                {
                    break;
                }
                else
                {
                    Console.Write("Please enter a price: $ ");
                    inputPrice = Console.ReadLine();
                }
            }

            var price = decimal.Parse(inputPrice);


            newContent.MenuItemPrice = price;
            _menuRepository.AddMenuItemSet(newContent);
        }

       
        private void DeleteMenuItems()
        {
            Console.Clear();
            Console.Write("Please enter the menu item number to delete: ");
            var item = int.Parse(Console.ReadLine());
            List<ChallOne_MenuContent> allMenuContent = _menuRepository.GetDirectory();
            var count = 0;
            foreach (ChallOne_MenuContent content in allMenuContent)
            {
                if (content.MenuItemNumber == item)
                {
                    _menuRepository.DeleteMenuItemSet(content);
                    //allMenuContent.Remove(content);
                    Console.WriteLine("Item deleted.\n\n");
                    Console.WriteLine("Press <Enter> to continue.");
                    Console.ReadLine();
                    break;
                }
                else
                {
                    count++;
                }
                if (count == allMenuContent.Count)
                {
                    Console.WriteLine("That menu item was not found. Press <Enter> to continue.");
                    Console.ReadLine();
                }
            }
        }

        private void DisplayAllItems()
        {
            Console.Clear();
            List<ChallOne_MenuContent> allMenuContent = _menuRepository.GetDirectory();
            foreach (ChallOne_MenuContent content in allMenuContent)
            {
                Console.WriteLine($"Menu Item #: {content.MenuItemNumber}");
                Console.WriteLine($"Meal name: {content.MenuItemName}");
                Console.WriteLine($"Menu description: {content.MenuItemDesc}");
                Console.Write($"Ingredients: ");
                foreach (var item in content.MenuItemIngredients)
                {
                    Console.Write($"{item}, ");
                }
                Console.WriteLine($"\nPrice: $ {content.MenuItemPrice}\n");
            }
            Console.WriteLine("Press <Enter> to continue.");
            Console.ReadLine();
        }
    }

}

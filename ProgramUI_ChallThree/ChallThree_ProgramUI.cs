using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramUI_ChallThree
{
    class ChallThree_ProgramUI
    {
        public BadgeRepository _badgeRepository = new BadgeRepository();
        private bool _isRunning = true;

        public void Start()
        {
            SeedBadgeData();
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
                            "Menu\n\n" +
                            "Hello Security Admin, what would you like to do? \n\n" +
                            "1. Add a badge\n" +
                            "2. Edit a badge\n" +
                            "3. List all badges\n" +
                            "4. Exit");

            string userInput = Console.ReadLine();
            return userInput;
        }
        public void ActOnMenuOption(string userInput)
        {
            switch (userInput)
            {
                case "1":
                    AddBadgeChoice();
                    break;
                case "2":
                    EditBadgeChoice();
                    break;
                case "3":
                    ListAllBadgesChoice();
                    break;
                case "4":
                    _isRunning = false;
                    break;
                default:
                    break;
            }
        }
        public void AddBadgeChoice()
        {
            Dictionary<int, List<string>> allBadgeContent = _badgeRepository.GetDirectory();
            ChallThree_BadgeContent newContent = new ChallThree_BadgeContent();
            Console.Clear();
            Console.Write("What is the number on the badge: ");
            var inputBadgeNum = Console.ReadLine();
            var getValidNumber = false;
            while (!getValidNumber)
            {
                getValidNumber = int.TryParse(inputBadgeNum, out _);
                if (getValidNumber)
                {
                    break;
                }
                else
                {
                    Console.Write("Please enter a number: ");
                    inputBadgeNum = Console.ReadLine();
                }
            }
            var inputNum = int.Parse(inputBadgeNum);
            foreach (KeyValuePair<int, List<string>> content in allBadgeContent)
            {
                while (true)
                {
                    if (content.Key == inputNum)
                    {
                        Console.WriteLine("This badge is already in the list. Please enter a different badge number: ");
                        inputNum = int.Parse(Console.ReadLine());
                    }
                    break;
                }
            }
            newContent.BadgeIDNumber = inputNum;
            Console.WriteLine("What door to add?");

            var tempDoorName = Console.ReadLine();
            var newDoorNameList = new List<string>() { tempDoorName };

            //newContent.DoorNames.Add(newDoorNameList);
            newContent.DoorNames = newDoorNameList;
            var isLooping = true;
            while (isLooping == true)
            {

                Console.WriteLine("Is there another door to add?");
                var isAnother = Console.ReadLine().ToLower();
                if (isAnother == "y")
                {
                    Console.WriteLine("What door to add?");
                    tempDoorName = Console.ReadLine();
                    if (!newContent.DoorNames.Contains(tempDoorName))
                    {
                        newContent.DoorNames.Add(tempDoorName);
                    }

                    else
                    {
                        Console.WriteLine("This door is already in the list. Please enter a different door number: ");
                    }
                }
                else
                {
                    isLooping = false;
                    break;
                }

            }

            _badgeRepository.AddBadge(newContent);
        }
        public void EditBadgeChoice()
        {
            Console.Clear();
            Dictionary<int, List<string>> allBadgeContent = _badgeRepository.GetDirectory();
            var getValidNumber = false;
            var getValidBadge = false;
            int tempBadgeNum = 0;
            while (getValidNumber == false && getValidBadge == false)
            {
                Console.WriteLine("What badge number would you like to edit?");
                var tempBadge = Console.ReadLine();
                getValidNumber = int.TryParse(tempBadge, out _);
                if (getValidNumber)
                {
                    tempBadgeNum = int.Parse(tempBadge);
                    if (allBadgeContent.ContainsKey(tempBadgeNum))
                    {
                        break;
                    }
                    else
                    {
                        //Console.Write("Please enter a number: ");
                        //tempBadge = Console.ReadLine();
                        Console.WriteLine("That badge number is not valid");
                        getValidNumber = false;
                    }

                }
                else
                {
                    Console.WriteLine("Please enter a number");

                }
                // find the record and change

            }

            List<string> newContent = allBadgeContent[tempBadgeNum];

            Console.Write($"Badge {tempBadgeNum} has access to the following doors: ");

            //Console.WriteLine(content.Key + "\t");
            foreach (string x in newContent)
            {
                Console.Write($"{x} ");
            }
            Console.WriteLine();
            Console.WriteLine("What would you like to do?\n\n" +
                "1. Remove a door\n" +
                "2. Add a door\n" +
                "3. Exit\n");

            var userInput = Console.ReadLine();
            //ChallThree_BadgeContent newBadge = new ChallThree_BadgeContent();

            switch (userInput)
            {
                case "1":
                    Console.WriteLine("Which door do you want to remove?");
                    var tempDoorRemove = Console.ReadLine();

                    newContent.Remove(tempDoorRemove);
                    _badgeRepository.EditBadge(tempBadgeNum, newContent);
                    Console.Write($"Door removed.\n\nBadge {tempBadgeNum} now has access to the following doors: ");

                    //Console.WriteLine(content.Key + "\t");
                    foreach (string x in newContent)
                    {
                        Console.Write($"{x} ");
                    }
                    Console.WriteLine("\n\nPress <Enter> to continue");
                    Console.ReadLine();
                    break;
                case "2":
                    Console.WriteLine("What door do you want to add?");
                    var tempDoorName = Console.ReadLine();
                    var newDoorNameList = new List<string>() { tempDoorName };
                    newContent.Add(tempDoorName);
                    //ChallThree_BadgeContent seedBadgeOne = new ChallThree_BadgeContent(tempBadgeNum, newContent);
                    _badgeRepository.EditBadge(tempBadgeNum, newContent);
                    Console.Write($"Door added.\n\nBadge {tempBadgeNum} now has access to the following doors: ");

                    //Console.WriteLine(content.Key + "\t");
                    foreach (string x in newContent)
                    {
                        Console.Write($"{x} ");
                    }
                    Console.WriteLine("\n\nPress <Enter> to continue");
                    Console.ReadLine();
                    break;
                case "3":
                    break;
                default:
                    break;
            }
        }

        public void ListAllBadgesChoice()
        {
            Dictionary<int, List<string>> allBadgeContent = _badgeRepository.GetDirectory();
            Console.Clear();
            Console.WriteLine("Badge\t\tDoor Access");
            foreach (KeyValuePair<int, List<string>> content in allBadgeContent)
            {
                Console.Write(content.Key + "\t\t");
                foreach (string x in content.Value)
                {
                    Console.Write(x + " ");
                }
                Console.WriteLine();

            }
            Console.WriteLine("\nPress <Enter> to continue");
            Console.ReadLine();
        }

        public void SeedBadgeData()
        {
            ChallThree_BadgeContent seedBadgeOne = new ChallThree_BadgeContent(12345, new List<string>() { "A7" });
            ChallThree_BadgeContent seedBadgeTwo = new ChallThree_BadgeContent(22345, new List<string>() { "A1", "A4", "B1", "B2" });
            ChallThree_BadgeContent seedBadgeThree = new ChallThree_BadgeContent(32345, new List<string>() { "A4", "A5" });

            _badgeRepository.AddBadge(seedBadgeOne);
            _badgeRepository.AddBadge(seedBadgeTwo);
            _badgeRepository.AddBadge(seedBadgeThree);

        }
    }
}



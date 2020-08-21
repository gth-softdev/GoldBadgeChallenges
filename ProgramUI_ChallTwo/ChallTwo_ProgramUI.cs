using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProgramUI_ChallTwo
{
    class ChallTwo_ProgramUI
    {
        private ClaimRepository _claimRepository = new ClaimRepository();
        private bool _isRunning = true;

        public void Start()
        {
            SeedClaimData();
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
                            "Choose a menu item:\n\n" +
                            "1. See all claims\n" +
                            "2. Take care of next claim\n" +
                            "3. Enter new claim.\n" +
                            "4. Modify an existing claim.\n" +
                            "5. Exit.");

            string userInput = Console.ReadLine();
            return userInput;
        }
        public void ActOnMenuOption(string userInput)
        {
            switch (userInput)
            {
                case "1": // See all claims
                    DisplayAllClaims();
                    break;
                case "2": // Take care of next claim
                    ActOnNextClaim();
                    break;
                case "3": // Enter new claim
                    CreateClaim();
                    break;
                case "4": // Modify existing claim
                    ModifyExistingClaim();
                    break;
                case "5":
                    _isRunning = false;
                    break;
                default:
                    break;
            }
        }

        public void CreateClaim()
        {
            // Start Get ID Number

            Console.Clear();
            Queue<ChallTwo_ClaimContent> allClaimContent = _claimRepository.GetDirectory();
            ChallTwo_ClaimContent newContent = new ChallTwo_ClaimContent();
            Console.Write("Enter the claim number this will be: ");
            var inputClaimNum = Console.ReadLine();
            var getValidNumber = false;
            while (!getValidNumber)
            {
                getValidNumber = int.TryParse(inputClaimNum, out _);
                if (getValidNumber)
                {
                    break;
                }
                else
                {
                    Console.Write("Please enter a number: ");
                    inputClaimNum = Console.ReadLine();
                }
            }
            var inputNum = int.Parse(inputClaimNum);
            foreach (ChallTwo_ClaimContent content in allClaimContent)
            {
                while (true)
                {
                    if (content.ClaimIDNumber == inputNum)
                    {
                        Console.WriteLine("This claim number is already in the queue. Please enter a different claim number: ");
                        inputNum = int.Parse(Console.ReadLine());
                    }
                    break;
                }
            }
            newContent.ClaimIDNumber = inputNum;

            // End Claim ID Number




            // Start Claim type

            Console.Write("Select a claim type:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft\n");
            bool test = true;
            while (test)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        newContent.ClaimType = ClaimType.Car;
                        test = false;
                        break;
                    case "2":
                        newContent.ClaimType = ClaimType.Home;
                        test = false;
                        break;
                    case "3":
                        newContent.ClaimType = ClaimType.Theft;
                        test = false;
                        break;
                }
                if (test == true)
                {
                    Console.WriteLine("Invalid, try again");
                }
            }

            // End Claim type



            // Start Claim description

            Console.Write("Enter a description of this claim (in 30 characters or less!): ");
            var getDesc = Console.ReadLine();
            getDesc = getDesc + "                             ";
            newContent.ClaimDesc = getDesc.Substring(0, 30);

            // End Claim Description


            // Start Claim Amount

            Console.Write("Enter the dollar amount of this claim: $ ");
            var inputAmount = Console.ReadLine();
            var getValidAmount = false;
            while (!getValidAmount)
            {
                getValidAmount = decimal.TryParse(inputAmount, out _);
                if (getValidAmount)
                {
                    break;
                }
                else
                {
                    Console.Write("Please enter a price: $ ");
                    inputAmount = Console.ReadLine();
                }
            }
            var price = decimal.Parse(inputAmount);
            newContent.ClaimAmount = price;

            // End Claim Amount

            // Start Accident Year

            Console.Write("What year did this accident occur? Please enter 4 digits: ");
            var year = Console.ReadLine();
            //ValidateYear(year);
            var getValidYear = false;
            while (!getValidYear)
            {
                getValidYear = int.TryParse(year, out _);
                if (getValidYear && (int.Parse(year) <= DateTime.Now.Year && int.Parse(year) >= (DateTime.Now.Year - 5)))
                {
                    break;
                }
                else
                {
                    getValidYear = false;
                    Console.Write("Please enter a 4 digit number for the year: ");
                    year = Console.ReadLine();
                }
            }
            Console.Write("In what month did this accident occur? Please enter 1 or 2 digits: ");
            var month = Console.ReadLine();
            var getValidMonth = false;
            while (!getValidMonth)
            {
                getValidMonth = int.TryParse(month, out _);
                if (getValidMonth && (int.Parse(month) >= 1 && int.Parse(month) <= 12))
                {
                    if ((int.Parse(year) == DateTime.Now.Year && int.Parse(month) <= DateTime.Now.Month) || int.Parse(year) != DateTime.Now.Year)
                    {
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        getValidMonth = false;
                        Console.Write($"The month cannot be greater than the current month, {DateTime.Now.Month}.\n" +
                            $"Please enter the current month or a previous month: ");
                        month = Console.ReadLine();
                    }
                }
                else
                {
                    Console.Clear();
                    getValidMonth = false;
                    Console.Write("Please enter up to 2 digits for the month: ");
                    month = Console.ReadLine();
                }
            }
            Console.Write("What day of the month did this accident occur? Please enter 1 or 2 digits: ");
            var day = Console.ReadLine();
            var getValidDay = false;
            while (!getValidDay)
            {
                getValidDay = int.TryParse(day, out _);
                if (getValidDay && (int.Parse(day) >= 1 && int.Parse(day) <= DateTime.DaysInMonth(int.Parse(year), int.Parse(month))))
                {
                    //if (int.Parse(year) <= DateTime.Now.Year && int.Parse(month) <= DateTime.Now.Month && int.Parse(day) <= DateTime.Now.Day)
                    if (int.Parse(year) <= DateTime.Now.Year || (int.Parse(year) == DateTime.Now.Year && int.Parse(month) <= DateTime.Now.Month) || (int.Parse(year) == DateTime.Now.Year && int.Parse(month) == DateTime.Now.Month && int.Parse(day) <= DateTime.Now.Day))
                    {
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        getValidDay = false;
                        Console.Write($"The day cannot be greater than the current day, {DateTime.Now.Day}.\n" +
                            $"Please enter the current day or a previous day: ");
                        day = Console.ReadLine();
                    }
                }
                else
                {
                    Console.Clear();
                    getValidDay = false;
                    Console.Write("Please enter up to 2 digits for the day: ");
                    day = Console.ReadLine();
                }
            }
            newContent.ClaimAccidentDate = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));
            // End Accident date

            // Start Date of Filing claim

            Console.Clear();
            Console.Write("What year was this claim filed? Please enter 4 digits: ");
            var filedYear = Console.ReadLine();
            var getValidFiledYear = false;
            while (!getValidFiledYear)
            {
                getValidFiledYear = int.TryParse(filedYear, out _);
                if (getValidFiledYear && (int.Parse(filedYear) <= DateTime.Now.Year && int.Parse(filedYear) >= (DateTime.Now.Year - 5) && int.Parse(filedYear) >= int.Parse(year)))
                {
                    break;
                }
                else
                {
                    getValidFiledYear = false;
                    Console.Write("Please enter a 4 digit number for the year: ");
                    filedYear = Console.ReadLine();
                }
            }
            Console.Write("In what month was this filed? Please enter 1 or 2 digits: ");
            var filedMonth = Console.ReadLine();
            var getValidFiledMonth = false;
            while (!getValidFiledMonth)
            {
                getValidFiledMonth = int.TryParse(filedMonth, out _);
                if (getValidFiledMonth && (int.Parse(filedMonth) >= 1 && int.Parse(filedMonth) <= 12))
                {
                    if (int.Parse(filedYear) > int.Parse(year) || (int.Parse(filedYear) == int.Parse(year) && int.Parse(filedMonth) >= int.Parse(month)))
                    {
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        getValidFiledMonth = false;
                        Console.Write($"The month cannot be greater than the current month, or less than the accident month. \n" +
                            $"Please enter the current month or a previous month: ");
                        filedMonth = Console.ReadLine();
                    }
                }
                else
                {
                    Console.Clear();
                    getValidFiledMonth = false;
                    Console.Write("Please enter up to 2 digits for the month: ");
                    filedMonth = Console.ReadLine();
                }
            }
            Console.Write("On what day of the month was this filed? Please enter 1 or 2 digits: ");
            var filedDay = Console.ReadLine();
            var getValidFiledDay = false;
            while (!getValidFiledDay)
            {
                getValidFiledDay = int.TryParse(filedDay, out _);
                if (getValidFiledDay && (int.Parse(filedDay) >= 1 && int.Parse(filedDay) <= DateTime.DaysInMonth(int.Parse(filedYear), int.Parse(filedMonth))))
                {
                    if ((int.Parse(filedYear) > int.Parse(year)) || ((int.Parse(filedYear) == int.Parse(year) && int.Parse(filedMonth) > int.Parse(month)) || (int.Parse(filedYear) == int.Parse(year) && int.Parse(filedMonth) == int.Parse(month) && int.Parse(filedDay) >= int.Parse(day))))
                    {
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        getValidFiledDay = false;
                        Console.Write($"Invalid entry, please enter the filed day again: ");
                        filedDay = Console.ReadLine();
                    }
                }
                else
                {
                    Console.Clear();
                    getValidFiledDay = false;
                    Console.Write("Please enter up to 2 digits for the day: ");
                    filedDay = Console.ReadLine();
                }
            }
            newContent.ClaimFiledDate = new DateTime(int.Parse(filedYear), int.Parse(filedMonth), int.Parse(filedDay));

            // End Filing Date Claim

            // Start IsValid

            while (true)
            {
                Console.WriteLine("Is this a valid claim? Please answer \"YES\" or \"NO\"");
                var claimValid = Console.ReadLine().ToUpper();
                if (claimValid == "YES")
                {
                    newContent.ClaimIsValid = true;
                    break;
                }
                if (claimValid == "NO")
                {
                    newContent.ClaimIsValid = false;
                    break;
                }
                else
                {

                }
            }

            _claimRepository.AddClaim(newContent);
        }

        // End IsValid

        private void DeleteMenuItems()
        {
            Console.Clear();
            Console.Write("Please enter the menu item number to delete: ");
            var item = int.Parse(Console.ReadLine());
            Queue<ChallTwo_ClaimContent> allMenuContent = _claimRepository.GetDirectory();
            var count = 0;
            foreach (ChallTwo_ClaimContent content in allMenuContent)
            {
                //if (content.MenuItemNumber == item)
                if (true)
                {
                    //_claimRepository.dequ(content);
                    //allMenuContent.Remove(content);
                    Console.WriteLine("Item deleted.\n\n");
                    Console.WriteLine("Press <Enter> to continue.");
                    Console.ReadLine();
                    break;
                }
                else
                {
                   
                }
            }
        }

        private void DisplayAllClaims()
        {
            Console.Clear();
            Queue<ChallTwo_ClaimContent> allMenuContent = _claimRepository.GetDirectory();
            Console.WriteLine("ClaimID\tType\tDescription\t\t\tAmount\t\tDateOfAccident\tDateOfClaim\tIsValid");
            foreach (ChallTwo_ClaimContent content in allMenuContent)
            {
                Console.WriteLine($"{content.ClaimIDNumber}\t{content.ClaimType}\t{content.ClaimDesc}\t$ {Math.Round(content.ClaimAmount, 2)}\t\t{content.ClaimAccidentDate.ToString("d")}\t{content.ClaimFiledDate.ToString("d")}\t{content.ClaimIsValid}\t");
            }

            Console.WriteLine("Press <Enter> to continue.");
            Console.ReadLine();
        }
        private void ModifyExistingClaim()
        {
            Console.Clear();
            Console.WriteLine("Which claim do you want to modify?");
            var claimid = Console.ReadLine();
            Queue<ChallTwo_ClaimContent> allMenuContent = _claimRepository.GetDirectory();
            foreach (ChallTwo_ClaimContent content in allMenuContent)
            {
                if (content.ClaimIDNumber.ToString() == claimid)
                {
                    Console.WriteLine($"Claim ID: {content.ClaimIDNumber}\n" +
                        $"Claim Type: {content.ClaimType}\nClaim Description: {content.ClaimDesc}\nClaim Amount: $ {Math.Round(content.ClaimAmount, 2)}\nDate of accident: {content.ClaimAccidentDate.ToString("d")}\n" +
                        $"Date of filing: {content.ClaimFiledDate.ToString("d")}\nIsValid: {content.ClaimIsValid}\n\n");
                    Console.WriteLine("Do you want to modify with this claim now (y/n)\n");
                    var choice = Console.ReadLine().ToUpper();
                    if (choice == "Y")
                    {
                        Console.Write("Select the Claim item you would like to modify:\n" +
                                    "1. Type\n" +
                                    "2. Description\n" +
                                    "3. Amount\n" +
                                    "4. Accident Date\n" +
                                    "5. Claim Date\n" +
                                    "6. Validity\n");

                        bool test = true;
                        while (test)
                        {
                            switch (Console.ReadLine())
                            {
                                case "1":
                                    Console.Write("Select a claim type:\n" +
                                                    "1. Car\n" +
                                                    "2. Home\n" +
                                                    "3. Theft\n");
                                    bool testTwo = true;
                                    while (testTwo)
                                    {
                                        switch (Console.ReadLine())
                                        {
                                            case "1":
                                                content.ClaimType = ClaimType.Car;
                                                testTwo = false;
                                                break;
                                            case "2":
                                                content.ClaimType = ClaimType.Home;
                                                testTwo = false;
                                                break;
                                            case "3":
                                                content.ClaimType = ClaimType.Theft;
                                                testTwo = false;
                                                break;
                                        }
                                        if (testTwo == true)
                                        {
                                            Console.WriteLine("Invalid, try again");
                                        }
                                    }

                                    test = false;
                                    break;
                                case "2":
                                    test = false;
                                    break;
                                case "3":
                                    test = false;
                                    break;
                                case "4":
                                    test = false;
                                    break;
                                case "5":
                                    test = false;
                                    break;
                                case "6":
                                    test = false;
                                    break;
                            }
                            if (test == true)
                            {
                                Console.WriteLine("Invalid, try again");
                            }
                        }
                        Queue<ChallTwo_ClaimContent> allClaimContent = _claimRepository.GetDirectory();
                        foreach (ChallTwo_ClaimContent contentTwo in allClaimContent)
                        {
                            if (contentTwo.ClaimIDNumber.ToString() == claimid)
                            {
                                Console.WriteLine("What is the new claim type? :");
                                Console.ReadLine();
                            }
                        }
                        //_claimRepository.modif();
                        break;
                    }
                    break;
                }
                if (content.ClaimIDNumber.ToString() != claimid)
                {
                    Console.WriteLine("Invalid claim number. Please try again");
                }
            }

        }
        private void ActOnNextClaim()
        {
            Console.Clear();
            //Console.WriteLine("what claim do you want to work?");
            //var claimid = Console.ReadLine();
            Queue<ChallTwo_ClaimContent> allMenuContent = _claimRepository.GetDirectory();
            foreach (ChallTwo_ClaimContent content in allMenuContent)
            {
                //if (content.ClaimIDNumber.ToString() == claimid)
                {
                    Console.WriteLine($"Claim ID: {content.ClaimIDNumber}\n" +
                        $"Claim Type: {content.ClaimType}\nClaim Description: {content.ClaimDesc}\nClaim Amount: $ {Math.Round(content.ClaimAmount, 2)}\nDate of accident: {content.ClaimAccidentDate.ToString("d")}\n" +
                        $"Date of filing: {content.ClaimFiledDate.ToString("d")}\nIsValid: {content.ClaimIsValid}\n\n");
                    Console.WriteLine("Do you want to deal with this claim now (y/n)\n");
                    var choice = Console.ReadLine().ToUpper();
                    if (choice == "Y")
                    {
                        _claimRepository.RemoveClaim();
                        break;
                    }
                    break;
                }
            }
        }

        private void SeedClaimData()
        {
            ChallTwo_ClaimContent seedClaimOne = new ChallTwo_ClaimContent(1, ClaimType.Car, "Accident on 465               ", 400, DateTime.Parse("2018-4-25"), DateTime.Parse("2018-4-27"), true);
            ChallTwo_ClaimContent seedClaimTwo = new ChallTwo_ClaimContent(2, ClaimType.Home, "House fire in kitchen        ", 4000, DateTime.Parse("2018-4-11"), DateTime.Parse("2018-4-12"), true);
            ChallTwo_ClaimContent seedClaimThree = new ChallTwo_ClaimContent(3, ClaimType.Theft, "Stolen pancakes               ", 4, DateTime.Parse("2019-4-27"), DateTime.Parse("2019-6-1"), false);
            ChallTwo_ClaimContent seedClaimFour = new ChallTwo_ClaimContent(4, ClaimType.Car, "Hit and run                   ", 2000, DateTime.Parse("2019-4-1"), DateTime.Parse("2019-4-13"), true);

            _claimRepository.AddClaim(seedClaimOne);
            _claimRepository.AddClaim(seedClaimTwo);
            _claimRepository.AddClaim(seedClaimThree);
            _claimRepository.AddClaim(seedClaimFour);
        }
    }
}


using System;

namespace Challenge2
{
    class Program
    {
 
        static List<int> rolls = new List<int>();

        static void Main()
        {
            string filePath = "./Rolls.txt";
            if (File.Exists(filePath))
            {
                string[] arr = File.ReadAllLines(filePath);
                foreach (string s in arr)
                {
                    rolls.Add(int.Parse(s));
                }
            }
            while (true)
            {
                int inputNum;
                while (true)
                {
                    Console.writeLine("================================");
                    Console.WriteLine("1. Roll Dice");
                    Console.WriteLine("2. Calculate Key Values");
                    console.WriteLine("3 List Rolls");
                    console.WriteLine("4. Delete All Rolls");
                    console.WriteLine("5. Exit");
                    console.WriteLine("Input Number for your desired action:");
                    string input = Console.ReadLine().Trim();

                    
                    if (char.IsDigit(input, 0))
                    {

                        inputNum = (int)char.GetNumericValue(input[0]);
                        if (1 <= inputNum && inputNum <= 5)
                            break;
                    }
                    Console.Clear();
                    Console.WriteLine("Incorrect Input");
                    //Input filter
                }
                switch (inputNum)
                {
                    case 1:
                        dRoll();
                        break;
                    case 2:
                        calAverage();
                        break;
                    case 3:
                        ListAll();
                        break;
                    case 4:
                        Console.Clear();
                        using (StreamWriter writer = new StreamWriter("./rolls.txt", false))
                        {
                            writer.Write("");
                        }
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                        //Inputs
                }
            }
        }

        static void dRoll()
        {
            int inputNum;

            Console.Clear();
            while (true)
            {

                Console.WriteLine("How many dice would you like to roll?");
                string input = Console.ReadLine().Trim();
                if (int.TryParse(input, out inputNum))
                    break;
                Console.Clear();
                Console.WriteLine("Invalid Input");
            }
            Console.Clear();
            Random rnd = new Random();
            List<int> tempRolls = new List<int>();
            Console.WriteLine(inputNum);
            for (int i = 0; i < inputNum; i++)
            {
                int roll = rnd.Next(1, 6);
                rolls.Add(roll);
                tempRolls.Add(roll);
            }
            while (true)
            {
                using (StreamWriter writer = new StreamWriter("./rolls.txt", true))
                {
                    foreach (int roll in tempRolls)
                    {
                        Console.WriteLine(roll);
                        writer.WriteLine(roll);
                    }
                }
                Console.WriteLine("Would you like to return? (Y/N)");
                string yesNo = Console.ReadLine().Trim().ToUpper();
                if (yesNo[0] == 'Y')
                {
                    Console.Clear();
                    break;
                }
            }
        }
        //Rolls dice and writes to Rolls.txt and adds it to the list
        static void calAverage()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"The average of the rolls is: {rolls.Average()}");
                Console.WriteLine($"The total is {rolls.Sum()}");
                Console.WriteLine("Would you like to return? (Y/N)");
                string yesNo = Console.ReadLine().Trim().ToUpper();
                if (yesNo[0] == 'Y')
                {
                    Console.Clear();
                    break;
                }
            }
        }
        //Prints average
        static void ListAll()
        {
            while (true)
            {
                Console.Clear();
                foreach (int roll in rolls)
                {
                    Console.WriteLine(roll);
                }
                Console.WriteLine("Would you like to return? (Y/N)");
                string yesNo = Console.ReadLine().Trim().ToUpper();
                if (yesNo[0] == 'Y')
                {
                    Console.Clear();
                    break;
                }
            }
        }
        //lists all the rolls that are in Rolls.txt
    }
}

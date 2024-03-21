using System;

namespace FunctionChallenges
{
    class Program
    {
        private static object _;

        static void StringNumberProcessor(params object[] values)
        {
            int sum = 0;
            string sentence = "";

            foreach (object val in values)
            {
                if (val.GetType() == typeof(string))
                {
                    sentence += " " + val.ToString();
                }
                else if (val.GetType() == typeof(int))
                {
                    sum += Convert.ToInt32(val);
                }
            }
            Console.WriteLine($"{sentence}; {sum}");
        }

        // Challenge 2 Functions
        static string SwapObjects<T, Y>(ref T val1, Y val2)
        {
            try
            {
                throw new Exception(" Error: Objects must be of same types and have references");
            }
            catch (Exception e)
            {
                return $"{e.Message}";
            }
        }
        static string SwapObjects<T, Y>(T val1, Y val2)
        {
            try
            {
                if (val1.GetType() != val2.GetType())
                {
                    throw new Exception(" Error: Objects must be of same types");
                }

                if (val1.GetType() != typeof(string) && val1.GetType() != typeof(int))
                {
                    throw new Exception(" Error: Upsupported data type");
                }

                return SwapObjects(ref _, ref _);
            }
            catch (Exception e)
            {
                return $"{e.Message}";
            }
        }
        static string SwapObjects<T>(ref T val1, ref T val2)
        {
            try
            {
                if (val1.GetType() == typeof(string))
                {
                    if (val1.ToString()?.Length < 5 || val2.ToString()?.Length < 5)
                        throw new Exception(" Error: Length must be more than 5");
                }

                if (val1.GetType() == typeof(int))
                {
                    if (Convert.ToInt32(val1) < 18 || Convert.ToInt32(val2) < 18)
                        throw new Exception(" Error: Value must be more than 18");
                }

                (val1, val2) = (val2, val1);
                return $"{val1}, {val2}";
            }
            catch (Exception e)
            {
                return $"{e.Message}";
            }
        }

        // Challlenge 3 Function
        static void GuessingGame()
        {
            try
            {
                Console.WriteLine("Welcome To Guessing Game!");

                Random rnd = new();
                int number = rnd.Next(1, 11);

                while (true)
                {

                    Console.Write("Guess an integer number between 1 to 10 , or enter (q) to Quit a Game >>> ");
                    string input = Console.ReadLine() ?? "";

                    if (input.ToLower().Equals("q"))
                    {
                        Console.WriteLine($"The Answer is '{number}'\n-------End Game-------");
                        break;
                    }

                    if (!int.TryParse(input, out int guessedNumber) || guessedNumber > 10)
                    {
                        Console.WriteLine("Invalid input!\n");
                        continue;
                    }

                    if (guessedNumber != number)
                    {
                        Console.WriteLine("Wrong! try again");
                        continue;
                    }

                    Console.WriteLine($"Well Done! The correct number is {number}.");
                    break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void Main(string[] args)
        {
            // Challenge 1: String and Number Processor
            Console.WriteLine("Challenge 1: String and Number Processor");
            StringNumberProcessor("Hello", 100, 200, "World"); // Expected outcome: "Hello World; 300"
            StringNumberProcessor("Hello", "World", 800, "Happy", 200, "Coding"); // Expected outcome: "Hello World Happy Coding; 1000"

            // Challenge 2: Object Swapper
            Console.WriteLine("\nChallenge 2: Object Swapper");
            int num1 = 25, num2 = 30;
            int num3 = 10, num4 = 30;
            string str1 = "HelloWorld", str2 = "Programming";
            string str3 = "Hi", str4 = "Programming";

            Console.WriteLine(SwapObjects(ref num1, ref num2)); // Expected outcome: num1 = 30, num2 = 25  
            Console.WriteLine(SwapObjects(ref num3, ref num4)); // Error: Value must be more than 18

            Console.WriteLine(SwapObjects(ref str1, ref str2)); // Expected outcome: str1 = "Programming", str2 = "HelloWorld"
            Console.WriteLine(SwapObjects(ref str3, ref str4)); // Error: Length must be more than 5

            Console.WriteLine(SwapObjects(true, false)); // Error: Upsupported data type
            Console.WriteLine(SwapObjects(ref num1, str1)); // Error: Objects must be of same types

            Console.WriteLine($"Numbers: {num1}, {num2}");
            Console.WriteLine($"Strings: {str1}, {str2}");

            // // Challenge 3: Guessing Game
            Console.WriteLine("\nChallenge 3: Guessing Game");
            // Uncomment to test the GuessingGame method
            GuessingGame(); // Expected outcome: User input until the correct number is guessed or user inputs `Quit`

            // // Challenge 4: Simple Word Reversal
            // Console.WriteLine("\nChallenge 4: Simple Word Reversal");
            // string sentence = "This is the original sentence!";
            // string reversed = ReverseWords(sentence);
            // Console.WriteLine(reversed); // Expected outcome: "sihT si eht lanigiro !ecnetnes"
        }
    }
}

using System;

namespace ProgrammingAssignment1
{
    // IMPORTANT: Only add code in the section
    // indicated below. The code I've provided
    // makes your solution work with the 
    // automated grader on Coursera

    /// <summary>
    /// Programming Assignment 1
    /// </summary>
    class Program
    {
        // number to classify
        static int number;

        /// <summary>
        /// Programming Assignment 1
        /// </summary>
        /// <param name="args">command-line args</param>
        static void Main(string[] args)
        {
            // loop while there's more input
            string input = Console.ReadLine();
            while (input[0] != 'q')
            {
                // extract number from string
                GetInputValueFromString(input);

                // Add your code between this comment
                // and the comment below. You can of
                // course add more space between the
                // comments as needed
                string result = "";
                // check if number is 0
                if (number == 0)
                {
                    result = "e 0";
                }
                else
                {
                    // check if number is even
                    if (number % 2 == 0)
                    {
                        result += "e";
                    }
                    else
                    {
                        result += "o";
                    }
                    // check if number is negative
                    if (number < 0)
                    {
                        result += " -1";
                    }
                    else
                    {
                        result += " 1";
                    }
                }

                // print result
                Console.WriteLine(result);

                // Don't add or modify any code below
                // this comment
                input = Console.ReadLine();
            }
        }

        /// <summary>
        /// Extracts the number from the given input string
        /// </summary>
        /// <param name="input">input string</param>
        static void GetInputValueFromString(string input)
        {
            number = int.Parse(input);
        }
    }
}

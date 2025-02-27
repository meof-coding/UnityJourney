﻿using System;
using System.Collections.Generic;

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
                // Add your code between this comment
                // and the comment below. You can of
                // course add more space between the
                // comments as needed
                //print first 10 elements in the periodic table

                List<string> lines = new List<string> { "H", "He", "Li", "Be", "B", "C", "N", "O", "F", "Ne" };
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
                // Don't add or modify any code below
                // this comment
                input = Console.ReadLine();
            }
        }
    }
}

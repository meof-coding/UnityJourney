using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignment4
{
    /// <summary>
    /// Converts words to digits
    /// </summary>
    public class Digitizer
    {
        #region Fields

        // declare your Dictionary field and create the Dictionary object for it here
        private Dictionary<string, int> digitizer = new Dictionary<string, int>();

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public Digitizer()
        {
            // populate your dictionary field here
            digitizer.Add("zero", 0);
            digitizer.Add("one", 1);
            digitizer.Add("two", 2);
            digitizer.Add("three", 3);
            digitizer.Add("four", 4);
            digitizer.Add("five", 5);
            digitizer.Add("six", 6);
            digitizer.Add("seven", 7);
            digitizer.Add("eight", 8);
            digitizer.Add("nine", 9);
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Converts the given word to the corresponding digit.
        /// If the word isn't a valid digit name, returns -1
        /// </summary>
        /// <param name="word">word to convert</param>
        /// <returns>corresponding digit or -1</returns>
        public int ConvertWordToDigit(string word)
        {
            // delete the code below and add your code
            // to convert the word to a digit here
            int digit = -1;
            if (digitizer.ContainsKey(word.ToLower()))
            {
                digit = digitizer[word.ToLower()];
            }
            return digit;
        }

        #endregion
    }
}

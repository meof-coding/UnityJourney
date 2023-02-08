using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignment1
{
    /// <summary>
    /// A class holding personal data for a person
    /// </summary>
    public class PersonalData
    {
        #region Fields

        // declare your fields here
        //field city
        private string city;
        //field country
        private string country;
        //field first name
        private string firstName;
        //field last name
        private string lastName;
        //field middle name
        private string middleName;
        //field phone number
        private string phoneNumber;
        //field postal code
        private string postalCode;
        //field state
        private string state;
        //field street address
        private string streetAddress;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the person's first name
        /// </summary>
        public string FirstName
        {
            get
            {
                return firstName;
            }
        }

        /// <summary>
        /// Gets the person's middle name
        /// </summary>
        public string MiddleName
        {
            get
            {
                return middleName;
            }
        }

        /// <summary>
        /// Gets the person's last name
        /// </summary>
        public string LastName
        {
            get
            {
                return lastName;
            }
        }

        /// <summary>
        /// Gets the person's street address
        /// </summary>
        public string StreetAddress
        {
            get
            {
                return streetAddress;
            }
        }

        /// <summary>
        /// Gets the person's city or town
        /// </summary>
        public string City
        {
            get
            {
                return city;
            }
        }

        /// <summary>
        /// Gets the person's state or province
        /// </summary>
        public string State
        {
            get
            {
                // delete code below and replace with correct code
                return state;
            }
        }

        /// <summary>
        /// Gets the person's postal code
        /// </summary>
        public string PostalCode
        {
            get
            {
                // delete code below and replace with correct code
                return postalCode;
            }
        }

        /// <summary>
        /// Gets the person's country
        /// </summary>
        public string Country
        {
            get
            {
                // delete code below and replace with correct code
                return country;
            }
        }

        /// <summary>
        /// Gets the person's phone number (digits only, no 
        /// parentheses, spaces, or dashes)
        /// </summary>
        public string PhoneNumber
        {
            get
            {
                // delete code below and replace with correct code
                return phoneNumber;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// Reads personal data from a file. If the file
        /// read fails, the object contains an empty string for all
        /// the personal data
        /// </summary>
        /// <param name="fileName">name of file holding personal data</param>
        public PersonalData(string fileName)
        {
            // your code can assume we know the order in which the
            // values appear in the string; it's the same order as
            // they're listed for the properties above. We could do 
            // something more complicated with the names and values, 
            // but that's not necessary here


            // IMPORTANT: The mono compiler the automated grader uses
            // does NOT support the string Split method. You have to 
            // use the IndexOf method to find comma locations and the
            // Substring method to chop off the front of the string
            // after you extract each value to extract and save the
            // personal data

            //read data from txt file
            try
            {
                //read data from txt file
                string[] lines = File.ReadAllLines(fileName);
                List<string> info = new List<string>();
                //using index of to find comma position 
                int pos = 0;
                //get list of index of comma in lines
                foreach (var line in lines)
                {
                    while (pos < line.Length)
                    {
                        int commaPos = line.IndexOf(',', pos);
                        if (commaPos == -1)
                        {
                            commaPos = line.Length;
                        }
                        info.Add(line.Substring(pos, commaPos - pos));
                        pos = commaPos + 1;
                    }
                }

                //assign data from info to each fields
                firstName = 0 < info.Count ? info[0] : "";
                middleName = 1 < info.Count ? info[1] : "";
                lastName = 2 < info.Count ? info[2] : "";
                streetAddress = 3 < info.Count ? info[3] : "";
                city = 4 < info.Count ? info[4] : "";
                state = 5 < info.Count ? info[5] : "";
                postalCode = 6 < info.Count ? info[6] : "";
                country = 7 < info.Count ? info[7] : "";
                phoneNumber = 8 < info.Count ? info[8] : "";
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
        }

        #endregion
    }
}

using System;

namespace ProgrammingAssignment1
{
    /// <summary>
    /// An egg
    /// </summary>
    public class Egg
    {
        #region Fields

        int amountLeft;
        EggColor color;
        HowCooked howCooked = HowCooked.NotCooked;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="size">egg size</param>
        /// <param name="color">egg color</param>
        public Egg(int size, EggColor color)
        {
            // replace the line of code below with correct code
            //set the amountLeft field to the size parameter
            this.amountLeft = size;
            // replace the line of code below with correct code
            //set the color field to the color parameter
            this.color = color;

        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets how much egg is left to eat
        /// </summary>
        public int AmountLeft
        {
            get
            {
                // replace the line of code below with correct code
                //return the value of the amountLeft field.
                return this.amountLeft;
            }
        }

        /// <summary>
        /// Gets the color of the egg
        /// </summary>
        public EggColor Color
        {
            get
            {
                // replace the line of code below with correct code
                return this.color;
            }
        }

        /// <summary>
        /// Gets how the egg is cooked
        /// </summary>
        public HowCooked CookedStatus
        {
            get
            {
                // replace the line of code below with correct code
                return this.howCooked;
            }
        }

        /// <summary>
        /// Gets whether or not the egg is cooked
        /// </summary>
        public bool IsCooked
        {
            get
            {
                // replace the line of code below with correct code
                //return true if the egg is cooked and false if the egg isn't cooked
                return this.howCooked != HowCooked.NotCooked;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Cooks the egg
        /// </summary>
        /// <param name="howToCook">how the egg should be cooked</param>
        public void Cook(HowCooked howToCook)
        {
            if (this.howCooked == HowCooked.NotCooked)
            {
                this.howCooked = howToCook;
            }
        }

        /// <summary>
        /// Takes a bite of the given size from the egg. Only takes
        /// a bite if the egg is cooked
        /// </summary>
        /// <param name="size">size of the bite to take</param>
        public void TakeBite(int size)
        {
            /// Takes a bite of the given size from the egg. Only takes
            /// a bite if the egg is cooked
            if (this.IsCooked)
            {
                this.amountLeft -= size;
                //If the amount left is less than 0, then set the amount left to 0.
                if (this.amountLeft < 0)
                {
                    this.amountLeft = 0;
                }
            }
        }

        /// <summary>
        /// Dyes the egg the given color. Only white eggs can be dyed,
        /// and eggs can only be dyed blue
        /// </summary>
        /// <param name="color">color to dye the egg</param>
        public void Dye(EggColor color)
        {
            /// Dyes the egg the given color. Only white eggs can be dyed,
            /// and eggs can only be dyed blue
            if (this.color == EggColor.White && color == EggColor.Blue)
            {
                this.color = color;
            }
        }

        #endregion
    }
}

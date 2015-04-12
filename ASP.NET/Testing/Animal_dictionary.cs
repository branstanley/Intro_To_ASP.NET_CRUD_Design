// <copyright file="Animal_dictionary.cs" company="engi">
// Animal dictionary for the project.
// </copyright>
namespace Testing
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    /// <summary>
    /// Class for the animal portion of dictionary
    /// </summary>
    public class Animal_dictionary
    {
        /// <summary>
        /// String for breed
        /// </summary>
        private string breed;

        /// <summary>
        /// Float for weight
        /// </summary>
        private float weight;

        /// <summary>
        /// Float for age
        /// </summary>
        private float age;

        /// <summary>
        /// Initializes a new instance of the Animal_dictionary class.
        /// </summary>
        /// <param name="tempbreed">temporary string to set Breed</param>
        /// <param name="tempweight">temporary float to set Weight</param>
        /// <param name="tempage">temporary float to set Age</param>
        public Animal_dictionary(string tempbreed, float tempweight, float tempage)
        {
            this.Breed = tempbreed;
            this.Weight = tempweight;
            this.Age = tempage;
        }

        /// <summary>
        /// Gets or sets breed
        /// </summary>
        public string Breed
        {
            get
            {
                return breed;
            }

            set
            {
                breed = value;
            }
        }

        /// <summary>
        /// Gets or sets weight
        /// </summary>
        public float Weight
        {
            get
            {
                return weight;
            }

            set
            {
                weight = value;
            }
        }

        /// <summary>
        /// Gets or sets age
        /// </summary>
        public float Age
        {
            get
            {
                return age;
            }

            set
            {
                age = value;
            }
        }
    }
}

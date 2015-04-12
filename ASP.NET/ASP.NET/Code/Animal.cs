// <copyright file="Animal.cs" company="engi">
// Data model class for Animal Website
// </copyright>

namespace LUProj2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// Defines the data model.</summary>    
    public class Animal
    {
        /// <summary>
        /// Stores animal ID</summary> 
        private int id;

        /// <summary>
        /// Stores animal Breed</summary> 
        private string breed;

        /// <summary>
        /// Stores animal Weight</summary> 
        private float weight;

        /// <summary>
        /// Stores animal Age</summary> 
        private float age;

        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        /// <summary>
        /// Gets or sets Breed
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
        /// Gets or sets Weight
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
        /// Gets or sets Age
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
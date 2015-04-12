// <copyright file="Dictionary.cs" company="engi">
// Dictionary for the project.
// </copyright>
namespace Testing
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    /// <summary>
    /// Dictionary class to test Read
    /// </summary>
   public class Dictionary
    {
       /// <summary>
       /// Dictionary for testing Read function
       /// </summary>
      public static Dictionary<int, Animal_dictionary> ExpectedValues = new Dictionary<int, Animal_dictionary>()
       {
            { 1, new Animal_dictionary("Labrador", 50, 3) },
            { 2, new Animal_dictionary("Buldog", 34, 6) }
       };        
    }
}

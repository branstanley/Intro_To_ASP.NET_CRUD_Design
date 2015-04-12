// <copyright file="animalAccess.cs" company="engi">
// Model access class for Animal Website
// </copyright>

namespace LUProj2
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web;
    using Npgsql;
    using NpgsqlTypes;   

    /// <summary>
    /// Class for server Access and Crud functions
    /// </summary>    
    public class AnimalAccess
    {
        /// <summary>
        /// Function for creating new rows in Database</summary>        
        /// <param name="breed">String parameter for Breed</param>
        /// <param name="weight">String parameter for Weight</param>
        /// <param name="age">String parameter for Age</param>        
        public static void Create(string breed, string weight, string age)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1; Port=5432; Database=LU.ENG3675.Proj2; User Id=postgres; Password=Ir18ssantos;");
            
            conn.Open();

            using (NpgsqlCommand command = new NpgsqlCommand("insert into animals (breed, weight, age) values (:breedP, :weightP, :ageP)", conn))
            {
                command.Parameters.Add(new NpgsqlParameter("breedP", NpgsqlDbType.Varchar));
                command.Parameters.Add(new NpgsqlParameter("weightP", NpgsqlDbType.Real));
                command.Parameters.Add(new NpgsqlParameter("ageP", NpgsqlDbType.Real));

                command.Parameters[0].Value = breed;
                command.Parameters[1].Value = Convert.ToSingle(weight);
                command.Parameters[2].Value = Convert.ToSingle(age);
                    
                int rowsaffected;

                try
                {
                    rowsaffected = command.ExecuteNonQuery();

                    Console.WriteLine("It was added {0} lines in the table animals", rowsaffected);
                }
                finally
                {
                    conn.Close();
                }
            }            
        }

        /// <summary>
        /// Function to Read data from the database
        /// </summary>
        /// <returns>A list containing the data Read from the database</returns>
        public static List<Animal> Read()
        {
            List<Animal> list_animals = new List<Animal>();

            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1; Port=5432; Database=LU.ENG3675.Proj2; User Id=postgres; Password=Ir18ssantos;");
            
            conn.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("select * from animals order by id", conn);
            NpgsqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list_animals.Add(new Animal { Id = (int)reader[0], Breed = (string)reader[1], Weight = (float)reader[2], Age = (float)reader[3] });
            }

            conn.Close();            

            return list_animals;
        }

        /// <summary>
        /// Update Function to Update data in the database
        /// </summary>
        /// <param name="id">String parameter for id</param>
        /// <param name="breed">String parameter for breed</param>
        /// <param name="weight">String parameter for weight</param>
        /// <param name="age">String parameter for age</param>
        public static void Update(string id, string breed, string weight, string age)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1; Port=5432; Database=LU.ENG3675.Proj2; User Id=postgres; Password=Ir18ssantos;"))
            {
                conn.Open();

                using (NpgsqlCommand command = new NpgsqlCommand("update animals set breed= :breedP, weight= :weightP, age= :ageP where id= :idP", conn))
                {
                    command.Parameters.Add(new NpgsqlParameter("breedP", NpgsqlDbType.Varchar));
                    command.Parameters.Add(new NpgsqlParameter("weightP", NpgsqlDbType.Real));
                    command.Parameters.Add(new NpgsqlParameter("ageP", NpgsqlDbType.Real));
                    command.Parameters.Add(new NpgsqlParameter("idP", NpgsqlDbType.Integer));

                    command.Parameters[0].Value = breed;
                    command.Parameters[1].Value = Convert.ToSingle(weight);
                    command.Parameters[2].Value = Convert.ToSingle(age);
                    command.Parameters[3].Value = Convert.ToInt32(id);

                    int rowsaffected;

                    try
                    {
                        rowsaffected = command.ExecuteNonQuery();

                        Console.WriteLine("It was added {0} lines in the table animals", rowsaffected);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Delete function to Delete data from the database
        /// </summary>
        /// <param name="id">id to be deleted</param>
        public static void Delete(string id)
        {
            int idToDelete = Convert.ToInt32(id);            

            using (NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1; Port=5432; Database=LU.ENG3675.Proj2; User Id=postgres; Password=Ir18ssantos;"))
            {
                conn.Open();

                NpgsqlCommand cmd = new NpgsqlCommand("delete from animals where id= :idToDelete", conn);

                cmd.Parameters.Add(new NpgsqlParameter("idToDelete", NpgsqlDbType.Integer));
                cmd.Parameters[0].Value = idToDelete;

                int rowsaffected;

                try
                {
                    rowsaffected = cmd.ExecuteNonQuery();

                    Console.WriteLine("It was added {0} lines in the table animals", rowsaffected);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FintessCode.BL.Model
{
    /// <summary>
    /// User.
    /// </summary>
    [Serializable]
    public class User
    {
        #region properties

        public int Id { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        public int? GenderId { get; set; }
        public virtual Gender Gender { get; set; }

        /// <summary>
        /// Date of birth.
        /// </summary>
        public DateTime BirthDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Weight.
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Height.
        /// </summary>
        public double Height { get; set; }
        

        public virtual ICollection<Eating> Eatings { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }

        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }
        #endregion

        /// <summary>
        /// Create new User.
        /// </summary>
        /// <param name="name"> Name. </param>
        /// <param name="gender"> Gender. </param>
        /// <param name="birthDate"> Date of birth. </param>
        /// <param name="weight"> Weight. </param>
        /// <param name="height"> Height. </param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public User(string name,
            Gender gender,
            DateTime birthDate,
            double weight,
            double height)
        {
            #region condition check
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("User name cannot be empty or null.",nameof(name));
            }

            if(gender == null)
            {
                throw new ArgumentNullException("Gender cannot be null.", nameof(gender));
            }

            if(birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Imposible date of birth.", nameof(birthDate));
            }

            if(weight <= 0)
            {
                throw new ArgumentException("Weight cannot be less than or equal to zero.", nameof(weight));
            }

            if(height <= 0)
            {
                throw new ArgumentException("Height cannot be less than or equal to zero.", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        public User() { }

        public User(string name) 
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("User name cannot be empty or null.", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}

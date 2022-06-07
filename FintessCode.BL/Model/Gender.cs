using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FintessCode.BL.Model
{
    /// <summary>
    ///  Gender.
    /// </summary>
    [Serializable]
    public class Gender
    {
        public int Id { get; set; }

        /// <summary>
        /// Gender name.
        /// </summary>
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public Gender() { }

        /// <summary>
        /// Create new gender.
        /// </summary>
        /// <param name="name"> Gender name </param>
        /// <exception cref="ArgumentNullException"></exception>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Gender name cannot be empty or null", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

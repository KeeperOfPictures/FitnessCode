using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FintessCode.BL.Model
{
    [Serializable]
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }

        public double CaloriesPerMinute { get; set; }

        public Activity() { }

        public Activity(string name, double caloriesPerMinute)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name cannot be empty or null.", nameof(name));
            }

            if(caloriesPerMinute <= 0)
            {
                throw new ArgumentException("Calories cannot be less than or equal to zero.", nameof(caloriesPerMinute));
            }

            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

namespace FintessCode.BL.Model
{
    [Serializable]
    public class Food
    {
        public int Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Proteins.
        /// </summary>
        public double Proteins { get; set; }

        /// <summary>
        /// Fats.
        /// </summary>
        public double Fats { get; set; }

        /// <summary>
        /// Carbohydrates.
        /// </summary>
        public double Carbohydrates { get; set; }

        /// <summary>
        /// Calories.
        /// </summary>
        public double Calories { get; set; }


        public virtual ICollection<Eating> Eatings { get; set; }

        public Food() { }

        public Food(string name) : this(name, 0, 0, 0, 0) { }

        public Food(string name, double calories, double proteins, double fats, double carbohydates)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name cannot be empty or null.", nameof(name));
            }
            if(calories < 0)
            {
                throw new ArgumentException("Calories cannot be less than 0.", nameof(calories));
            }
            if (proteins < 0)
            {
                throw new ArgumentException("Proteins cannot be less than 0.", nameof(calories));
            }
            if (fats < 0)
            {
                throw new ArgumentException("Fats cannot be less than 0.", nameof(calories));
            }
            if (carbohydates < 0)
            {
                throw new ArgumentException("Carbohydates cannot be less than 0.", nameof(calories));
            }


            Name = name;
            Calories = calories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydates / 100.0;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

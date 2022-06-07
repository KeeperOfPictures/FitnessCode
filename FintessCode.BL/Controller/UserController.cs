using FintessCode.BL.Model;
using System;
using System.Runtime.Serialization.Formatters.Binary;

namespace FintessCode.BL.Controller
{
    /// <summary>
    /// User controller.
    /// </summary>
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Application user.
        /// </summary>
        public List<User> Users { get; }

        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Create a new user controller.
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Username cannot be empty.", nameof(userName));
            }

            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
            }
        }

        /// <summary>
        /// Get the saved list of users.
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersData()
        {
            return Load<User>() ?? new List<User>();
        }


        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            if (string.IsNullOrWhiteSpace(genderName))
            {
                throw new ArgumentNullException("Gender name cannot be empty.", nameof(genderName));
            }
            if(birthDate > DateTime.Now)
            {
                throw new ArgumentException("Invalid date format.", nameof(birthDate));
            }
            if(weight <= 0)
            {
                throw new ArgumentException("Weight cannot be less than or equal to 0.", nameof(weight));
            }
            if (height <= 0)
            {
                throw new ArgumentException("Height cannot be less than or equal to 0.", nameof(height));
            }

            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }

        /// <summary>
        /// Save user data.
        /// </summary>
        public void Save()
        {
            Save(Users);
        }
    }
}

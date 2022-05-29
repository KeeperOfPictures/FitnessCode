using FintessCode.BL.Model;
using System;
using System.Runtime.Serialization.Formatters.Binary;

namespace FintessCode.BL.Controller
{
    /// <summary>
    /// User controller.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// User.
        /// </summary>
        public User User { get;}

        /// <summary>
        /// Create new user controller.
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserController(string userName, string genderName, DateTime birthDay, double weight, double height)
        {
            // TODO: Checking

            var gender = new Gender(genderName);
            User = new User(userName, gender, birthDay, weight, height);
        }

        /// <summary>
        /// Save user data.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using(var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }

        /// <summary>
        /// Load user data.
        /// </summary>
        /// <returns> User. </returns>
        /// <exception cref="FileLoadException"></exception>
        public UserController()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            { 
               if(formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }

                //TODO: What to do if the user is not read?
            }
        }
     }
}

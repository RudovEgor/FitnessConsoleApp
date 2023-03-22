using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Contoller
{/// <summary>
 /// Контроллер пользователя.
 /// </summary>
    public class UserController
    {
        public User User { get; }
        public UserController(string userName, string genderName, DateTime birthDay, double weigth, double heigth)
        {
            var gender = new Gender(genderName);
            var user = new User(userName, gender, birthDay,weigth,heigth);


            User = user ?? throw new ArgumentNullException("Пользователь не может быть равен null", nameof(user));
        }
        /// <summary>
        /// Сохранение данных пользователя.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }
        /// <summary>
        /// Загрузка данных пользователя пользователя.
        /// </summary>
        public UserController()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User)
                {
                    User = User;
                }
            }
        }
        
    }
}

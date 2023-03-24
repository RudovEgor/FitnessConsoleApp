using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    [Serializable]
    public class User
    {/// <summary>
    /// Пользователь.
    /// </summary>
        public string Name { get; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public double Weight { get; set; }
        public double Heigth { get; set; }

        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }

        public User(string name, Gender gender, DateTime birthDate, double weigth, double heigth)
        {
            #region Проверка условий ввода
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Введите имя пользователя", nameof(name));
            }
            if (gender == null)
            {
                throw new ArgumentNullException("Введите пол", nameof(gender));
            }
            if (birthDate < DateTime.Parse("01.01.1900") && birthDate >= DateTime.Now) 
            {
                throw new ArgumentException("Введите корректную дату рождения", nameof(birthDate));
            }
            if (weigth <= 0)
            {
                throw new ArgumentException("Введите корректный ваш вес", nameof(weigth));
            }
            if (heigth <= 0)
            {
                throw new ArgumentException("Введите корректный ваш рост", nameof(heigth));
            }
            #endregion
            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Heigth = heigth;
            Weight = weigth;
        }
        public User(string name )
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Введите имя пользователя", nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
            return Name + " " + Age;
        }

    }
}

using Fitness.BL.Contoller;
using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.MainInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в приложение \"Fitness\"");
            Console.Write("Введите имя пользователя: ");
            var name = Console.ReadLine();
            
            var userController = new UserController(name);
            if (userController.IsNewUser)
            {
                Console.Write("Введите пол:");
                var gender = Console.ReadLine();
                var birthDate= ParseDateTime();
                var weigth = ParseDouble("вес");
                var heigth = ParseDouble("рост");
                userController.SetNewUserData(gender, birthDate, weigth, heigth);
            }
            Console.WriteLine(userController.CurrentUser);
            Console.ReadKey();
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write("Введите дату рождения(dd.mm.yyyy):");
                if (DateTime.TryParse(Console.ReadLine(), out  birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный формат даты рождения");
                }
            }
            return birthDate;
        }//парсинг даты

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Введите {name}:");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {name}");
                }
            }
        }//парсинг double чисел

    }
}

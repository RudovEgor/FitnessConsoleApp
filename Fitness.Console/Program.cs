using Fitness.BL.Contoller;
using Fitness.BL.Model;
using System;
using System.Collections.Generic;
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
            Console.WriteLine("Введите имя пользователя: ");
            var name = Console.ReadLine();
            
            var userController = new UserController(name);
            if (userController.IsNewUser)
            {
                Console.Write("Введите пол:");
                var gender = Console.ReadLine();
                DateTime birthDate;
                while (true)
                {


                    Console.Write("Введите дату рождения:");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime birthDay))
                    {

                    }
                    else
                    {
                        Console.WriteLine("Неверный формат даты рождения");
                    }
                }
                Console.Write("Введите вес:");
                var weigth = Console.ReadLine();
                Console.Write("Введите рост:");
                var heigth = Console.ReadLine();
                User.SetNewUserData();
            }
            Console.WriteLine(userController.CurrentUser);
            Console.ReadKey();
        }
    }
}

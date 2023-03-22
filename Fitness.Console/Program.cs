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
            Console.WriteLine("Введите пол");
            var gender = Console.ReadLine();
            Console.WriteLine("Введите дату рождения. Пример(01.01.2000 )");
            var dateBitrth = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Введите вес");
            var weigth = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите рост");
            var heigth = double.Parse(Console.ReadLine());

            var userController = new UserController(name,gender,dateBitrth,weigth,heigth);
            userController.Save();

            Console.ReadKey();
        }
    }
}

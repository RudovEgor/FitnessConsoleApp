﻿using Fitness.BL.Model;
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
        public User CurrentUser { get; }
        public List<User> Users { get; }
        public bool IsNewUser { get; } = false;
        public UserController(string userName)
        {
            if(string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым",nameof(userName));
            }
            Users = GetUsersData();
            CurrentUser = Users.SingleOrDefault(u => u.Name==userName);
            if(CurrentUser == null) 
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }
        public void SetNewUserData(string genderName, DateTime birthDate, double weigth=1,double heigth=1)
        {
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weigth;
            CurrentUser.Heigth = heigth;
            Save();
        }
        /// <summary>
        /// Получить список пользователей.
        /// </summary>
        private List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is List<User> users )
                {
                    return users;
                }
                else
                {
                    return new List<User>();
                }
            }
        }
        /// <summary>
        /// Сохранение данных пользователя.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Users);
            }
        }
    }
}

using Nik.Validate.Extensions;
using Nik.Validate.Models;
using System;

namespace Nik.Validate
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            User user = new User()
            {
                Mobile = "1351234567",
                Age = 23
            };
            Console.WriteLine(user.Validate().ErrorMessage);

            user.Mobile = "13512345678";
            user.Age = 200;
            Console.WriteLine(user.Validate().ErrorMessage);

            user.Age = 23;
            user.Height = 300;
            Console.WriteLine(user.Validate().ErrorMessage);
        }
    }
}
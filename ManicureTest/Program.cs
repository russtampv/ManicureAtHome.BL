using ManicureAtHome.BL;
using ManicureAtHome.BL.EF;
using System;
using System.IO;

namespace ManicureTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            var client = new Client()
            {
                Contact = new Contact
                {
                    FirstName = "*******",
                    LastName = "Айгуль",
                    InstagrammAddress = "aigul1989",
                    IsSupplier = false,
                    PhoneNumber = "+7950*****93",
                    Mail = "aigul@mail.ru"
                },
            };
            var EFClient = new ClientToEF();
            EFClient.WorkToClient.Add(client);
            var clientId = 7;
            if (EFClient.WorkToClient.Remove(clientId))
                Console.WriteLine("Клиент успешно удален!");
            else
                Console.WriteLine($"Клиент с идентификатором {clientId} - не обнаружен");
        }

    }
}

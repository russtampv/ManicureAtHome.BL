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
                    FirstName = "Пермяков",
                    LastName = "Антон",
                    InstagrammAddress = "antuan1989",
                    PhoneNumber = "+79506544554",
                    Mail = "antonio@mail.ru"
            };
            var EFClient = new ClientToEF();
            var result = EFClient.WorkToClient.Add(client);
            if (result.isAdded)
            {
                Console.WriteLine(result.desc);
            }
            var clientId = 7;
            if (EFClient.WorkToClient.Remove(clientId))
                Console.WriteLine("Клиент успешно удален!");
            else
                Console.WriteLine($"Клиент с идентификатором {clientId} - не обнаружен");
        }

    }
}

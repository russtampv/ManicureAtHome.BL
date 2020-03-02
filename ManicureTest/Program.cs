using ManicureAtHome.BL;
using ManicureAtHome.BL.EF;
using System;
using System.Collections.Generic;
using System.IO;

namespace ManicureTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            double dateTime = 0;
            var timeList = new List<TimeSpan?>()
            {
                new TimeSpan(1,30,20),
                new TimeSpan(1,40,50),
                new TimeSpan(2,40,20)
            };
            foreach (var time in timeList)
            {
                if (time == null)
                    continue;
                dateTime += time.Value.TotalMilliseconds;
            }
            var timSpan = TimeSpan.FromMilliseconds(dateTime);

            var client = new Client()
            {
                    FirstName = "Пермяков",
                    LastName = "Антон",
                    InstagrammAddress = "antuan1989",
                    PhoneNumber = "999506544554",
                    Mail = "antonio@mail.ru"
            };
            var efClient = new ClientToEF();
            var result = efClient.ClientWorker.Add(client);
            if (result.isAdded)
            {
                Console.WriteLine(result.desc);
            }
        }

    }
}

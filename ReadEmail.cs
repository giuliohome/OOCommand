using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReservationCmd
{
    public class ReadEmail : ConsoleCommand
    {
        public ReadEmail(Reservation r) : base(r)
        {
        }

        public override IReservation interpret()
        {
            Console.WriteLine("Enter Email");
            var line = Console.ReadLine();
            if (line.Equals("exit"))
            {
                return new ExitEscape();
            }
            if (line.Count(c => c.Equals('@')) == 1)
            {
                return new NextReservation(r => new Reservation()
                { Date = r.Date, Email = line, Name = r.Name, Quantity = r.Quantity }
                );
            }
            else
            {
                return new RetryError("this is not a Email");
            };
        }
    }
}

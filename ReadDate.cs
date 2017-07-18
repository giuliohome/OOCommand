using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReservationCmd
{

    public class ReadDate : ConsoleCommand
    {
        public ReadDate(Reservation r) : base(r)
        {
        }

        public override IReservation interpret()
        {
            Console.WriteLine("Enter Date");
            var line = Console.ReadLine();
            if (line.Equals("exit"))
            {
                return new ExitEscape();
            }
            DateTimeOffset date;
            if (DateTimeOffset.TryParse(line, out date))
            {
                return new NextReservation(r => new Reservation()
                { Date = date, Email = r.Email, Name = r.Name, Quantity = r.Quantity }
                );
            }
            else
            {
                return new RetryError("this is not a date");
            }
        }
    }
}

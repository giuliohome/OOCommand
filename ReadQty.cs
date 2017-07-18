using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReservationCmd
{
    public class ReadQty : ConsoleCommand
    {
        public ReadQty(Reservation r) : base(r)
        {
        }

        public override IReservation interpret()
        {
            Console.WriteLine("Enter Quantity");
            var line = Console.ReadLine();
            if (line.Equals("exit"))
            {
                return new ExitEscape();
            }
            int qty;
            if (int.TryParse(line, out qty))
            {
                return new NextReservation(r => new Reservation()
                { Date = r.Date, Email = r.Email, Name = r.Name, Quantity = qty }
                );
            }
            else
            {
                return new RetryError("this is not a quantity");
            };
        }
    }

}

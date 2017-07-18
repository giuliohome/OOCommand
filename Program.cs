using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReservationCmd
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = new Reservation();

            var readQty = new ReadQty(r);
            if (!readQty.Run(out r)) return;

            var readDate = new ReadDate(r);
            if (!readDate.Run(out r)) return;

            var readEmail = new ReadEmail(r);
            if (!readEmail.Run(out r)) return;

            Console.WriteLine("date {0} qty {1} email {2}", 
                r.Date, r .Quantity, r.Email);
            Console.ReadLine();
        }
    }
}

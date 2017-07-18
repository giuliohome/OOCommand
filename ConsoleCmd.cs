using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReservationCmd
{
    public abstract class ConsoleCommand
    {
        private Reservation current;
        public ConsoleCommand(Reservation r)
        {
            current = r;
        }
        public bool Exit(IResultReservation rr, out Reservation r)
        {
            var e = rr as ExitEscape;
            if (e != null)
            {
                Console.Write("exiting now");
                Console.ReadLine();
            }
            r = rr as Reservation;
            return r == null;
        }
        public abstract IReservation interpret();
        public Reservation ParseNext(NextReservation r)
        {
            return r.Next(current);
        }
        public void RetryParse(RetryError e)
        {
            Console.WriteLine(e.ErrorMsg);
        }
        public bool Run(out Reservation rr)
        {
            while(true)
            {
                var res = interpret();
                var exit = res as ExitEscape;
                if (exit != null)
                {
                    return !Exit(exit, out rr);
                }
                var retry = res as RetryError;
                if (retry != null)
                {
                    RetryParse(retry);
                    continue;
                }
                var parse = res as NextReservation;
                if (parse != null)
                {
                    return !Exit( ParseNext(parse), out rr);
                }
            }
        }
    }
}

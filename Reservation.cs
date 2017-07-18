using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReservationCmd
{
    public class Reservation : IResultReservation
    {
        public DateTimeOffset Date { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Quantity { get; set; }
    }
    public class NextReservation : IReservation
    {
        Func<Reservation, Reservation> f;
        public NextReservation(Func<Reservation, Reservation> next)
        {
            f = next;
        }
        public Reservation Next(Reservation r)
        {
            return f(r);
        }
    }
    public class RetryError : IReservation
    {
        public string ErrorMsg { get; }
        public RetryError(string error)
        {
            ErrorMsg = error;
        }
    }
    public class ExitEscape : IReservation, IResultReservation
    {

    }
}

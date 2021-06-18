using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB2Net
{
    class Ticket
    {
        public int TicketID { get; set; }
        public string FromStation { get; }
        public string ToStation { get; }
        public int CheckOutTime { get; }
        public int TrainID { get; }
        public string SecondNameTicket{get;}
        public string TicketType { get; set; }
        public int TicketCoast { get; set; }
        public Ticket(string fromStation, string toStation, int checkOutTime, int trainID, string secondNameTicket, string ticketType, int ticketcoast)
        {
            this.FromStation = fromStation;
            this.ToStation = toStation;
            this.CheckOutTime = checkOutTime;
            this.TrainID = trainID;
            this.SecondNameTicket = secondNameTicket;
            this.TicketType = ticketType;
            this.TicketCoast = ticketcoast;
        }
    }
}
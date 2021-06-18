using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB2Net
{
    class Client : User
    {
        public int Money { get; set; }
        public List<Ticket> Tickets = new List<Ticket>();

        public Client(string firstName, string secondName, string login, string password)
            :base(firstName,secondName,login,password)
        { 
        
        }

        public List<Train> GetTrainList(string destenition, int dateTime)
        {
            return this.system.GetTrainsForClient(destenition, dateTime);
        }

        public List<Place> GetPlaces(int trainID)
        {
            return this.system.GetPlacesForClient(trainID);
        }
    }
}


//public bool BuyPlace(string placeFrom, string placeTo, int trainID)
//{
//    this.system.BuyTicket(placeFrom, placeTo, trainID, this, 4);
//    return true;
//}

//public bool ReservePlace(string placeFrom, string placeTo, int trainID)
//{
//    this.system.ReserveTicket(placeFrom, placeTo, trainID, this,5);
//    return true;
//}
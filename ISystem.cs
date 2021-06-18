using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB2Net
{
    interface ISystem
    {
        public User ActualUser { get; set; }
        public List<User> AllUsers { get; set; }
        public List<Client> AllClients { get; set; }
        public List<Admin> AllAdmins { get; set; }
        public List<Train> AllTrains { get; set; }
        public List<Ticket> AllTicket { get; set; }

        public bool CreateNewClient(string firstName, string secondName, string login, string password);
        public Train GetTrain(int trainID);
        public void AddNewTrain(List<string> stations);
        public bool DeleteTrain(int trainID);
        public List<Train> GetTrainsForClient(string destenition, int dateTime);
        public List<Place> GetPlacesForClient(int trainID);
        public Ticket BuyTicket(string placeFrom, string placeTo, int trainID, Client client, List<string> placesId);
        public bool Autorization(string login, string password);
        public bool ClientType();
        public void ChangeTrainStatus(int trainID, bool status);
    }
}

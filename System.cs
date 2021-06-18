using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB2Net
{
    class System : ISystem
    {
        public List<User> AllUsers { get; set; }
        public List<Client> AllClients { get; set; }
        public List<Admin> AllAdmins { get; set; }
        public List<Train> AllTrains { get; set; }
        public List<Ticket> AllTicket { get; set; }
        private int Counter=0;
        public User ActualUser { get; set; }

        public System()
        {
            this.AllUsers = new List<User>();
            this.AllClients = new List<Client>();
            this.AllAdmins = new List<Admin>();
            this.AllTrains = new List<Train>();
            this.AllTicket = new List<Ticket>();

            Train tr1 = new Train();
            tr1.TrainID = 1;
            tr1.Stations.Add("Station1");
            tr1.Stations.Add("Station2");
            tr1.Stations.Add("Station3");
            tr1.GoTime = 8;
            Train tr2 = new Train();
            tr2.TrainID = 2;
            tr2.Stations.Add("Station4");
            tr2.Stations.Add("Station5");
            tr2.Stations.Add("Station1");
            tr2.GoTime = 10;
            Train tr3 = new Train();
            tr3.TrainID = 3;
            tr3.Stations.Add("Station3");
            tr3.Stations.Add("Station2");
            tr3.Stations.Add("Station4");
            tr3.GoTime = 10;
            Train tr4 = new Train();
            tr4.TrainID = 4;
            tr4.Stations.Add("Station5");
            tr4.Stations.Add("Station1");
            tr4.Stations.Add("Station2");
            tr4.GoTime = 8;
            Train tr5 = new Train();
            tr5.TrainID = 5;
            tr5.Stations.Add("Station3");
            tr5.Stations.Add("Station4");
            tr5.Stations.Add("Station5");
            tr5.GoTime = 10;

            this.AllTrains.Add(tr1);
            this.AllTrains.Add(tr2);
            this.AllTrains.Add(tr3);
            this.AllTrains.Add(tr4);
            this.AllTrains.Add(tr5);
        }

        public bool CreateNewClient(string firstName, string secondName, string login, string password)
        {
            this.AllClients.Add(new Client(firstName,secondName,login,password));
            return true;
        }

        public Train GetTrain(int trainID)
        {
            Train tr = null;
            foreach (Train train in this.AllTrains)
            {
                if(trainID == train.TrainID)
                {
                    tr = train;
                }
            }
            if (tr != null)
            {
                return tr;
            }
            else
            {
                throw new LogicException("No Train with Id");
            }
        }

        public void AddNewTrain(List<string> stations)
        {
            Train train = new Train();
            train.Stations = stations;
        }

        public bool DeleteTrain(int trainID)
        {
            this.AllTrains.Remove(GetTrain(trainID));
            return true;
        }

        public List<Train> GetTrainsForClient(string destenition, int dateTime)
        {
            List<Train> trainForClient = new List<Train>();
            foreach (Train t in this.AllTrains)
            {
                if (t.GoTime == dateTime)
                {
                    foreach (string s in t.Stations)
                    {
                        if (s == destenition)
                        {
                            trainForClient.Add(t);
                        }
                    }
                }
            }
            return trainForClient;
        }

        public List<Place> GetPlacesForClient(int trainID)
        {
            List<Place> pl = null;
            foreach (Train t in AllTrains)
            {
                if (t.TrainID == trainID)
                {
                    pl=t.GetFreePlaces();
                }
            }
            if (pl != null)
            {
                return pl;
            }
            else
            {
                throw new LogicException("Error");
            }
        }

        public Ticket BuyTicket(string placeFrom, string placeTo, int trainID, Client client, List<string> placesId)
        {
            Train train = this.GetTrain(trainID);
            Place place = train.Places[Convert.ToInt32(placesId[0]) - 1];
            placesId.Remove(placesId[0]);
            foreach (string p in placesId)
            {
                train.Places[Convert.ToInt32(p) - 1].State = false;
                place = place + train.Places[Convert.ToInt32(p) - 1];  //використання бінарного оператора (перегруженого)
            }
            Ticket ticket = new Ticket(placeFrom, placeTo,train.GoTime,train.TrainID,client.SecondName, "Payed", place.Coast);
            ticket.TicketID = Counter;
            Counter = Counter+1;
            client.Tickets.Add(ticket);
            return ticket;
        }

        public Client GetClient(string login)
        {
            Client client = null;
            foreach (User u in this.AllUsers)
            {
                if (u.CheckLogin(login))
                {
                    if(typeof(Client) == u.GetType())
                    {
                        client = (Client)u;
                    }
                }
            }
            if (client != null)
            {
                return client;
            }
            else
            {
                throw new Exception("Error");
            }
        }

        public Ticket ReserveTicket(string placeFrom, string placeTo, int trainID, Client client, List<string> placesId)
        {
            Train train = this.GetTrain(trainID);
            Place place = train.Places[Convert.ToInt32(placesId[0]) - 1];
            placesId.Remove(placesId[0]);
            foreach (string p in placesId)
            {
                train.Places[Convert.ToInt32(p) - 1].State = false;
                place = place + train.Places[Convert.ToInt32(p) - 1];//використання бінарного оператора (перегруженого)
            }
            Ticket ticket = new Ticket(placeFrom, placeTo, train.GoTime, train.TrainID, client.SecondName, "Reserved", place.Coast);
            ticket.TicketID = Counter;
            Counter = Counter + 1;
            client.Tickets.Add(ticket);
            return ticket;
        }

        public bool Autorization(string login, string password)
        {
            foreach (User user in this.AllUsers)
            {
                if (user.CheckLogin(login) && user.CheckPassword(password))
                {
                    this.ActualUser = user;
                    return true;
                }
            }
            return false;
        }

        public bool ClientType()
        {
            if (this.ActualUser.GetType() == typeof(Client))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ChangeTrainStatus(int trainID, bool status)
        {
            this.GetTrain(trainID).ChangeStatus(status);
        }
    } 
}
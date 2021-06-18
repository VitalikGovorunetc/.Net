using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB2Net
{
    class ViewConsole
    {
        public ISystem System;
        public int TrainID;
        public ViewConsole(System system)
        {
            this.System = system;
            this.ConsoleAutorization();
        }

        public void Continue()
        {
            int Step = 0;
            Console.WriteLine("1. Обрати потяг \n2. Переглянути мої квитки\n3. Купити квиток \n4. Забронювати квиток");

            switch (Console.ReadLine())
            {
                case "1":
                    Step = 1;
                    Console.WriteLine("Мiсце призначення: ");
                    string dest = Console.ReadLine();
                    Console.WriteLine("Час вiдбуття: ");
                    this.ChooseTrain(dest, Convert.ToInt32(Console.ReadLine()));
                    Console.WriteLine("Впишiть ID обраного потягу: ");
                    this.TrainID = Convert.ToInt32(Console.ReadLine());
                    this.Continue();
                    break;
                case "2":
                    this.ShowTickets(this.System.AllClients[0]);
                    this.Continue();
                    break;
                case "3":
                    Console.WriteLine("Оберiть мiсце");
                    this.GetPlaces(this.TrainID);
                    //this.BuyTicket(this.System.GetTrain(this.TrainID), Convert.ToInt32(Console.ReadLine()));
                    this.Continue();
                    break;
                case "4":
                    Console.WriteLine("Оберiть мiсце");
                    this.GetPlaces(this.TrainID);
                    // this.ReserveTicket(this.System.GetTrain(this.
                    //TrainID), Convert.ToInt32(Console.ReadLine()));
                    this.Continue();
                    break;
            }
            Console.ReadLine();
        }

        public void ChooseTrain(string dest, int time)
        {
            this.ShowTrains(this.System.GetTrainsForClient(dest, time));
        }

        public void GetPlaces(int number)
        {
            this.ShowPlaces(this.System.GetPlacesForClient(number));
            
        }

        public void ShowTrains(List<Train> trains)
        {
            foreach (Train tr in trains)
            {
                Console.WriteLine(tr.TrainID);
                Console.WriteLine(tr.WorkingStatus);
                Console.WriteLine("\n");
            }
        }

        public void ShowPlaces(List<Place> places)
        {
            foreach (Place place in places)
            {
                Console.WriteLine(place.Number);
            }
        }

        public void ShowTicket(Ticket ticket)
        {
            Console.WriteLine("Мiсце виїзду: " + ticket.FromStation);
            Console.WriteLine("Кiнцева: " + ticket.ToStation);
            Console.WriteLine("Прiзвище: " + ticket.SecondNameTicket);
        }

        //public void BuyTicket(Train train, int placeID)
        //{
        //    this.ShowTicket(this.System.BuyTicket(train.Stations[0], train.Stations[train.Stations.Count - 1], train.TrainID, System.AllClients[0], placeID));
        //}

        //public void ReserveTicket(Train train, int placeID)
        //{
        //    this.ShowTicket(this.System.ReserveTicket(train.Stations[0], train.Stations[train.Stations.Count - 1], train.TrainID, System.AllClients[0], placeID));
        //}

        public void ShowTickets(Client client)
        {
            foreach (Ticket t in client.Tickets)
            {
                Console.WriteLine(t.TicketID);
                Console.WriteLine(t.TicketType);
            }
        }

        public void ConsoleAutorization()
        {
            Console.WriteLine("Введіть логiн: ");
            string login = Console.ReadLine();
            Console.WriteLine("Введіть пароль: ");
            string pass = Console.ReadLine();
            if (this.System.Autorization(login, pass))
            {
                if (this.System.ClientType())
                {
                    Console.WriteLine("Клиент вошел");
                    this.ClientContinue();
                }
                else
                {
                    Console.WriteLine("Админ зашел");
                    this.AdminContinue();
                }
            }
            else
            {
                Console.WriteLine("Error");
                this.ConsoleAutorization();
            }
        }

        public void ClientContinue()
        {
            Console.WriteLine("1. Обрати потяг \n2. Переглянути мої квитки\n3. Сплатити квиток\n4. Інформація клієнта\n5. Вийти\n");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Мiсце призначення: ");
                    string dest = Console.ReadLine();
                    Console.WriteLine("Час вiдбуття: ");
                    int time = Convert.ToInt32(Console.ReadLine());
                    this.ShowTrains(this.System.GetTrainsForClient(dest,time));
                    Console.WriteLine("Впишiть ID обраного потягу: ");
                    int trainId = Convert.ToInt32(Console.ReadLine());
                    this.ShowPlaces(this.System.GetTrain(trainId).GetFreePlaces());
                    Console.WriteLine("Нужное количество мест");
                    this.ShowTicket(this.System.BuyTicket("Station5", dest, trainId, (Client)this.System.ActualUser, this.ChoosePlaces(this.System.GetTrain(trainId).GetFreePlaces(), Convert.ToInt32(Console.ReadLine()))));
                    this.ClientContinue();
                    break;
                case "2":
                    this.ShowTickets((Client)this.System.ActualUser);
                    this.ClientContinue();
                    break;
                case "3":

                    break;
                case "4":
                    this.ShowClient((Client)this.System.ActualUser);
                    this.ClientContinue();
                    break;
                case "5":
                    this.ConsoleAutorization();
                    break;
            }

        }
        public void AdminContinue()
        {
            Console.WriteLine("1. Додати новий потяг \n2. Змінити статус потягу\n3. Видалити потяг\n4. Інформація адміна\n5. Вийти\n");
            switch (Console.ReadLine())
            {
                case "1":
                    this.System.AddNewTrain(this.SelectStationsForTrain(Convert.ToInt32(Console.ReadLine())));
                    this.AdminContinue();
                    break;
                case "2":
                    this.ShowTrains(this.System.AllTrains);
                    Console.WriteLine("Впишите ID поезда: ");
                    int trainID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Выберите статус: \n1. Рабочий\n2. Нерабочий");
                    bool status;
                    if (Console.ReadLine() == "1")
                    {
                        status = true;
                    }
                    else
                    {
                        status = false;
                    }
                    this.System.ChangeTrainStatus(trainID, status);
                    this.AdminContinue();
                    break;
                case "3":
                    this.ShowTrains(this.System.AllTrains);
                    Console.WriteLine("Какой поезд удалть?");
                    int train_ID = Convert.ToInt32(Console.ReadLine());
                    this.System.DeleteTrain(train_ID);
                    this.AdminContinue();
                    break;
            }
        }


        public List<string> ChoosePlaces(List<Place> places, int count)
        {
            List<string> selectedPlaces = new List<string>();
            for (int i = 1; i <= count; i++)
            {
                Console.WriteLine("Введите место: ");
                selectedPlaces.Add(Console.ReadLine());
            }
            return selectedPlaces;
        }

        public void ShowClient(Client client)
        {
            Console.WriteLine(client.FirstName);
            Console.WriteLine(client.SecondName);
            Console.WriteLine(client.Money);
            Console.WriteLine(client.Tickets.Count);
        }
        public List<string> SelectStationsForTrain(int count)
        {
            List<string> selectedStations = new List<string>();
            for (int i = 1; i <= count; i++)
            {
                Console.WriteLine("Введите станцыю: ");
                selectedStations.Add(Console.ReadLine());
            }
            return selectedStations;
        }
    }
}

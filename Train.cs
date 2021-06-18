using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB2Net
{
    class Train
    {
        public int TrainID { get; set; }
        public bool WorkingStatus = true;
        public List<string> Stations = new List<string>();
        public List<Place> Places = new List<Place>();
        public int GoTime { get; set;}

        public Train()
        {
            for (int i = 1; i <= 10; i++)
            {
                this.Places.Add(new Place(i.ToString(),500,true));
            }
        }

        public List<Place> GetFreePlaces()
        {
            List<Place> freeplaces = new List<Place>();  
            foreach (Place p in this.Places)
            {
                if(p.State == true)
                {
                    freeplaces.Add(p);
                }
            }
            return freeplaces;
        }

        public Place GetPlace(string number)
        {
            Place pl = null;
            foreach (Place p in this.Places)
            { 
                if(p.Number == number) 
                {
                    pl = p;
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

        public void ChangeStatus(bool workingStatus)
        {
            this.WorkingStatus = workingStatus;
        }
    }
}

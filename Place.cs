using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB2Net
{
    class Place
    {
        public string Number { get; set; }
        public int Coast { get; set; }
        public bool State { get; set; }
        public Place(string number, int coast, bool state)
        {
            this.Number = number;
            this.Coast = coast;
            this.State = state;
        }
        public static Place operator +(Place p1, Place p2)//бінарний оператор
        {
            return new Place(p1.Number +" and "+ p2.Number, p1.Coast + p2.Coast, true);
        }

        public static Place operator ++(Place p1)//унарний оператр
        {
            p1.Coast += 100;
            return p1;
        }

        public static bool operator >=(Place p1, Place p2)//оператор порівняння
        {
            return p1.Coast >= p2.Coast;
        }

        public static bool operator <=(Place p1, Place p2)//оператор порівняння
        {
            return p1.Coast <= p2.Coast;
        }

        public static bool operator &(Place p1, Place p2) //логічний оператор
        {
            return p1.State & p2.State;
        }
    }
}

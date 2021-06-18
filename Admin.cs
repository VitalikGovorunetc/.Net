using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB2Net
{
    class Admin : User
    {
        public bool Active = true;
        public Admin(string firstName, string secondName, string login, string password)
            : base(firstName, secondName, login, password)
        {

        }
        public bool AddNewTrain(List<string> stations)
        {
            this.system.AddNewTrain(stations);
            return true;
        }
        public bool DeleteTrain(int trainID)
        {
            this.system.DeleteTrain(trainID);
            return true;
        }

        public override bool CheckLogin(string login)
        {
            if (login == this.Login && this.Active)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}   
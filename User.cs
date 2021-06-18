using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB2Net
{
    abstract class User
    {
        public string FirstName { get; }
        public string SecondName { get; }
        public int UserID { get; set; }
        public string Login { get; }
        private string Password;
        public System system { get; set; }

        public User(string firstName, string secondName, string login, string password)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.Login = login;
            this.Password = password;
        }

        public bool CheckPassword(string password)
        {
            if (password == this.Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual bool CheckLogin(string login)
        {
            if (login == this.Login)
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

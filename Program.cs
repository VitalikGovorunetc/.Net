using System;
using System.Collections.Generic;
using System.Data;

namespace LB2Net
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Admin admen = new Admin("Victor", "Kavunnik", "VicKav","asddsa12");
            Client cl1 = new Client("Vitalik","Govorunetc","VitGov","qwerty12");
            System sys = new System();

            sys.AllAdmins.Add(admen);
            sys.AllClients.Add(cl1);

            cl1.system = sys;
            admen.system = sys;


            sys.AllUsers.Add(new Client("Vitalik", "Govorunetc", "client", "client"));
            sys.AllUsers.Add(new Client("Kavynnik", "Victor", "client1", "client1"));
            sys.AllUsers.Add(new Client("Yatsyk", "Dmitro", "client2", "client2"));
            sys.AllUsers.Add(new Admin("Admin", "Admin", "admin", "admin"));

            ViewConsole vc = new ViewConsole(sys);

        }
    }
}

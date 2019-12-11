using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courseWork.Classes
{
    [Serializable]
    public class Worker
    {
        public enum Vocation
        {
            Worker,
            Manager
        };

        public string Login { get; set; }

        public string Password { get; set; }

        public Vocation Profession { get; set; }

        public Worker(string log,string pass,Vocation prof)
        {
            Login = log;
            Password = pass;
            Profession = prof;
        }
        public Worker()
        {

        }
    }
}

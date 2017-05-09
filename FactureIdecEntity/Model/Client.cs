using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace FactureIdecEntity
{
    public partial class Client
    {

        public static Client GetNewClient()
        {
            Client c = new Client();
            c.Id = -1;
            c.Del = false;
            c.Id = -1;
            return c;
        }

        public bool Del { get; set; }
    }
}

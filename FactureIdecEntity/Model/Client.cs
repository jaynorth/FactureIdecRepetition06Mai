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
            
            c.Del = false;
            c.New = true;
          
            return c;
        }

        public bool Del { get; set; }

        public bool New { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookSeller
{
    class ClientInfo
    {
        public string FirstName;
        public string LastName;
        public string Street;
        public string City;
        public string Province;
        public string Zip;
        public string E_Mail;
        public int Books_purchased;
        public int Books_hired;

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}

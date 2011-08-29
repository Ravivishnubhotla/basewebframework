using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GmapApplication.Appcode
{
    public class Address
    {



        private string country;
        private string state;
        private string city;
        private string county;
        private string zipCode;
        private string address1;
        private string address2;
        private string address3;

        public string Country
        {
            get { return country; }
            set { country = value; }
        }

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string County
        {
            get { return county; }
            set { county = value; }
        }

        public string ZipCode
        {
            get { return zipCode; }
            set { zipCode = value; }
        }

        public string Address1
        {
            get { return address1; }
            set { address1 = value; }
        }

        public string Address2
        {
            get { return address2; }
            set { address2 = value; }
        }

        public string Address3
        {
            get { return address3; }
            set { address3 = value; }
        }
    }
}
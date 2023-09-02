using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace End2EndTests.Damp
{
    internal class CustomerNico : CustomerInfo
    {
        public CustomerNico()
        {
            email = "norschel@xpirit.com";
            name = "Nico Orschel";
            street = "Irgendwo in Eschborn";
            town = "Eschborn";
            postalcode = "60606";
            cc = "4303651055386607";
            expdate = "09/28";
        }
    }

    internal class CustomerMarcel : CustomerInfo
    {
        internal CustomerMarcel()
        {
            email = "mdevries@xpirit.com";
            name = "Marcel de Vries";
            street = "Kerkhofweg 12";
            town = "Warnsveld";
            postalcode = "1213VB";
            cc = "1111222233334444";
            expdate = "08/28";
        }

    }

    internal class CustomerInfo
    {
        internal string email { get; set; }

        internal string name { get; set; }
        internal string street { get; set; }
        internal string town  { get; set; }
        internal string postalcode { get; set; }
        internal string cc { get; set; }
        internal string expdate { get; set; }
    }

}

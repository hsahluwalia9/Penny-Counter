using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A5_Group6
{
    class Data
    {
        //Data for days on the listbox binded to column 0 on listbox
        public double Days
        {
            get;
            set;
        }
        //Data for pay on the listbox binded to column 1 on listbox
        public double Pay
        {
            get;
            set;
        }

        //Days and Pay are shown as strings in the txt file as stated below
        public override string ToString()
        {
            return "Day "+ Days.ToString() + ": $" + Pay.ToString();
        }
    }
}

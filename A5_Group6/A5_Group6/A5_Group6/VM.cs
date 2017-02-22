using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace A5_Group6
{
    class VM: INotifyPropertyChanged
    {
        //Defining user entry of days
        public int _dayEntry;

        public int DayEntry
        {
            get { return _dayEntry; }
            set { _dayEntry = value; OnPropertyChanged(); }
        }

        //Defining list of days and salary that will be shown in listbox
        ObservableCollection<Data> _payList = new ObservableCollection<Data>();

        public ObservableCollection<Data> PayList
        {
            get { return _payList; }
            set { _payList = value; OnPropertyChanged(); }
        }

        public void Calc()
        {
            //Variable for number of pennies accumulated per day
            double penny = 0;
            //Variable for total salary accumulated throughout period
            double total = 0;
            //Increment variable for doubling salary each day.
            double increment = 2;

            //for loop that runs until counter variable n reaches the number of days entered.
            for (int n=0; n<_dayEntry; n++)
            {
                Data d = new Data();
                //adds 1 day to each value of n
                d.Days = n + 1;
                //stores pennies gained for a given day
                penny = Math.Pow(increment, d.Days - 1);
                //stores total pennies accumulated throughout period
                total = total + penny;
                //stores total value to pay in listbox and converts it to $
                d.Pay = total / 100;
                _payList.Add(d);
            }
        }
        const String DIRNAME = "C:\\Project";
        const String FILENAME = "Pay.txt";
        public void Save()
        {
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string fullpath = Path.Combine(path, DIRNAME);
            Directory.CreateDirectory(fullpath);
            string fullname = Path.Combine(fullpath, FILENAME);
            StreamWriter sw = File.AppendText(fullname);

            foreach (Data d in PayList)
            {
                sw.WriteLine(d);
            }
            sw.Close();
        }


        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string caller = null)
        {

            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(caller));
            }
        }
        #endregion
    }
}

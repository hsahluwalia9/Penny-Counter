using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace A5_Group6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VM vm;
        public MainWindow()
        {
            InitializeComponent();
            vm = new VM();
            DataContext = vm;
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            //runs Calc() from VM class that calculates salary and outputs on listbox
            vm.Calc();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // checks if user left entry to zero and entered a valid integer before saving.
            if (vm.DayEntry == 0)
            {
                MessageBox.Show("Please enter a valid integer and click show first.");
            }else
            {
                vm.Save();
                MessageBox.Show("Your File has been saved.");
            }
            
        }
    }
}

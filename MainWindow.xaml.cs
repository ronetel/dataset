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
using yp1.DataSet1TableAdapters;

namespace yp1
{
   
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Pageframe.Content = new FirstPage();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Pageframe.Content = new secondPage();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Pageframe.Content = new ThirdPage();
        }
    }
}

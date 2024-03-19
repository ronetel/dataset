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
using DS3.DataSet1TableAdapters;

namespace DS3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmployeesTableAdapter emp = new EmployeesTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
            grid_view.ItemsSource = emp.GetDataView();
           

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            grid_view.Columns[0].Visibility = Visibility.Collapsed;
            grid_view.Columns[4].Visibility = Visibility.Collapsed;
        }
    }
}

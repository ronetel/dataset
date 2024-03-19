using DS4.DataSet4TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
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

namespace DS4
{
    /// <summary>
    /// Логика взаимодействия для secondPage.xaml
    /// </summary>
    public partial class secondPage : Page
    {
        EmployeesTableAdapter emp = new EmployeesTableAdapter();
        PositionsTableAdapter pos = new PositionsTableAdapter();
        public secondPage()
        {
            InitializeComponent();
            grid_emp.ItemsSource = emp.GetData();
            Combo_emp.ItemsSource = pos.GetData();
            Combo_emp.DisplayMemberPath = "title";
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            grid_emp.ItemsSource = emp.SerarchByNameEmp(name_emp.Text);
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            grid_emp.ItemsSource = emp.GetData();
        }

        private void Combo_emp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Combo_emp.ItemsSource != null)
            {
                var id = (int)(Combo_emp.SelectedItem as DataRowView).Row[0];
                grid_emp.ItemsSource = emp.FiltetByPosID(id);
            }
        }
    }
}

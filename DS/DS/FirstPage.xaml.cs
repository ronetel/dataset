using DS.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace DS
{
    /// <summary>
    /// Логика взаимодействия для FirstPage.xaml
    /// </summary>
    public partial class FirstPage : Page
    {
        DepartmentsTableAdapter Departments = new DepartmentsTableAdapter();
        public FirstPage()
        {
            InitializeComponent();
            grid_dep.ItemsSource = Departments.GetData();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            object id = (grid_dep.SelectedItem as DataRowView).Row[0];
            Departments.UpdateQuery(titel.Text, Convert.ToInt32(id));
            grid_dep.ItemsSource = Departments.GetData();
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            Departments.InsertQuery(titel.Text);
            grid_dep.ItemsSource = Departments.GetData();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object id = (grid_dep.SelectedItem as DataRowView).Row[0];
                Departments.DeleteQuery(Convert.ToInt32(id));
                grid_dep.ItemsSource = Departments.GetData();
            }
            catch
            {
                MessageBox.Show("Ошибка!!!");
                
            }

        }

        private void grid_dep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object tite = (grid_dep.SelectedItem as DataRowView).Row[1];
            titel.Text = tite.ToString();
        }
    }
}

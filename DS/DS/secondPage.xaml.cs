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
            id_pos.ItemsSource = pos.GetData();
            id_pos.DisplayMemberPath = "title";
            
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            object id = (grid_emp.SelectedItem as DataRowView).Row[0];
            object title = (id_pos.SelectedItem as DataRowView).Row[0];
            emp.UpdateQuery(name_emp.Text,surname_emp.Text, midlename_emp.Text,Convert.ToInt32(title), hire_date.Text, Convert.ToInt32(salary) ,Convert.ToInt32(id));
            grid_emp.ItemsSource = emp.GetData();
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            object title = (id_pos.SelectedItem as DataRowView).Row[0];
            emp.InsertQuery(name_emp.Text, surname_emp.Text, midlename_emp.Text, Convert.ToInt32(title), hire_date.Text, Convert.ToInt32(salary.Text));
            grid_emp.ItemsSource = emp.GetData();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object id = (grid_emp.SelectedItem as DataRowView).Row[0];
                emp.DeleteQuery(Convert.ToInt32(id));
                grid_emp.ItemsSource = emp.GetData();
            }
            catch 
            { 
                MessageBox.Show("Ошибка");
            }
        }
        private void grid_emp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object name = (grid_emp.SelectedItem as DataRowView).Row[1];
            name_emp.Text = name.ToString();

            object surname = (grid_emp.SelectedItem as DataRowView).Row[2];
            surname_emp.Text = surname.ToString();

            object midlename = (grid_emp.SelectedItem as DataRowView).Row[3];
            midlename_emp.Text = midlename.ToString();

            object date = (grid_emp.SelectedItem as DataRowView).Row[5];
            hire_date.Text = date.ToString();

            object salar = (grid_emp.SelectedItem as DataRowView).Row[6];
            salary.Text = salar.ToString();
        }
    }
}

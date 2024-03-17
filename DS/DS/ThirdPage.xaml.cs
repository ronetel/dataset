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
    /// Логика взаимодействия для ThirdPage.xaml
    /// </summary>
    public partial class ThirdPage : Page
    {
        PositionsTableAdapter pos = new PositionsTableAdapter();
        DepartmentsTableAdapter dep = new DepartmentsTableAdapter();
        public ThirdPage()
        {
            InitializeComponent();
            grid_pos.ItemsSource = pos.GetData();
            id_dep.ItemsSource = dep.GetData();
            id_dep.DisplayMemberPath = "name_dep";
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            object id = (grid_pos.SelectedItem as DataRowView).Row[0];
            object name_dep = (id_dep.SelectedItem as DataRowView).Row[0];
            pos.UpdateQuery(title.Text, Convert.ToInt32(name_dep), Convert.ToInt32(id));
            grid_pos.ItemsSource = pos.GetData();
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            object name_dep = (id_dep.SelectedItem as DataRowView).Row[0];
            pos.InsertQuery(title.Text, Convert.ToInt32(name_dep));
            grid_pos.ItemsSource = pos.GetData();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object id = (grid_pos.SelectedItem as DataRowView).Row[0];
                pos.DeleteQuery(Convert.ToInt32(id));
                grid_pos.ItemsSource = pos.GetData();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void grid_pos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object name = (grid_pos.SelectedItem as DataRowView).Row[1];
            title.Text = name.ToString();
        }
    }
}

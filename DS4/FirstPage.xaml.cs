using DS4.DataSet4TableAdapters;
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

namespace DS4
{
    /// <summary>
    /// Логика взаимодействия для FirstPage.xaml
    /// </summary>
    public partial class FirstPage : Page
    {
        DepartmentsTableAdapter dep = new DepartmentsTableAdapter();
        
        public FirstPage()
        {
            InitializeComponent();
            grid_dep.ItemsSource = dep.GetData();
            Combo_dep.ItemsSource = dep.GetData();
            Combo_dep.DisplayMemberPath = "name_dep";
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            grid_dep.ItemsSource = dep.GetData();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            grid_dep.ItemsSource = dep.SearchByNameDep(name_dep.Text);

        }

        private void Combo_dep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Combo_dep.ItemsSource != null)
            {
                grid_dep.ItemsSource = dep.FilterByNameDep((Combo_dep.SelectedItem as DataRowView).Row[1].ToString());
            }
        }
    }
}

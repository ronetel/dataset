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
            Combo_pos.ItemsSource = dep.GetData();
            Combo_pos.DisplayMemberPath = "name_dep";
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            grid_pos.ItemsSource = pos.SesrchByTitle(title.Text);
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            grid_pos.ItemsSource = pos.GetData();
        }

        private void Combo_pos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Combo_pos.ItemsSource != null)
            {
                var id = (int)(Combo_pos.SelectedItem as DataRowView).Row[0];
                grid_pos.ItemsSource = pos.FiltrByDepID(id);
            }
        }
    }
}

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

namespace UI_Layer
{
    /// <summary>
    /// Interaction logic for Counting.xaml
    /// </summary>
    public partial class Counting : Page
    {
        public Counting()
        {
            InitializeComponent();
        }
        private void Button_CountStock_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("CountAll.xaml", UriKind.Relative));
        }

        private void Button_AddStock_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("AddSupply.xaml", UriKind.Relative));
        }

        private void Button_AddOrDeleteCategory_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("AddCategory.xaml", UriKind.Relative));
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("ChooseFunctionality.xaml", UriKind.Relative));
        }
    }
}

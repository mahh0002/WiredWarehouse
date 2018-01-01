using System;
using System.Windows;
using System.Windows.Controls;


namespace UI_Layer
{
    /// <summary>
    /// Interaction logic for ChooseFunctionality.xaml
    /// </summary>
    public partial class ChooseFunctionality : Page
    {
        public ChooseFunctionality()
        {
            InitializeComponent();
        }
        private void Button_Count_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Counting.xaml", UriKind.Relative));
        }

        private void Button_Overview_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Overview.Xaml", UriKind.Relative));
        }
    }
}

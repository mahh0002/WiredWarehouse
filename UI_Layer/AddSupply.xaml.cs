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
using Domain_Layer;

namespace UI_Layer
{
    /// <summary>
    /// Interaction logic for AddSupply.xaml
    /// </summary>
    public partial class AddSupply : Page
    {
        Controller controller = Controller.GetInstance();
        public AddSupply()
        {
            InitializeComponent();

            controller.LoadValuesIntoComboBox(comboBox_Category);
        }
        private void Button_AddStock_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_Name.Text != "")
            {
                MessageBox.Show(controller.C_AddSupply(textBox_Name.Text, textBox_Description.Text, textBox_Amount.Text, textBox_Unit.Text, textBox_Building.Text, comboBox_Category.SelectedValue.ToString()));
            }
            else
            {
                MessageBox.Show("You must assign a name to the stock.");
            }
        }
        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Counting.Xaml", UriKind.Relative));
        }
    }
}

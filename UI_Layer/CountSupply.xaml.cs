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
using System.Windows.Shapes;
using Domain_Layer;

namespace UI_Layer
{
    /// <summary>
    /// Interaction logic for CountSupply.xaml
    /// </summary>
    public partial class CountSupply : Window
    {
        Controller controller = Controller.GetInstance();
        private string SelectedMonth { get; set; }
        private string SelectedYear { get; set; }

        public CountSupply(string selectedMonth, string selectedYear)
        {
            InitializeComponent();

            SelectedMonth = selectedMonth;
            SelectedYear = selectedYear;

            foreach (Control control in Grid_CountSupply.Children)
            {
                if (control.Name.Contains("TextBox") && !control.Name.Contains("CountSupply"))
                {
                    TextBox tempTextBox = (TextBox)control;
                    tempTextBox.IsEnabled = false;
                }
            }
            controller.LoadValuesIntoList();

            TextBox_ID.Text = controller.officeSuppliesValues[0];
            TextBox_Name.Text = controller.officeSuppliesValues[1];
            TextBox_Description.Text = controller.officeSuppliesValues[2];
            TextBox_Amount.Text = controller.officeSuppliesValues[3];
            TextBox_Unit.Text = controller.officeSuppliesValues[4];
            TextBox_Building.Text = controller.officeSuppliesValues[5];
            TextBox_CategoryTitle.Text = controller.officeSuppliesValues[6];

            TextBox_CountSupply.Focus();
        }
        private void Button_CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_SaveChanges_Click(object sender, RoutedEventArgs e)
        {

            Int32.TryParse(TextBox_CountSupply.Text, out int countSupplyAmount);

            MessageBox.Show(controller.C_CountSupply(countSupplyAmount, SelectedMonth, SelectedYear, Int32.Parse(TextBox_ID.Text)));

            this.Close();
        }
    }
}

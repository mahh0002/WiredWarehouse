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
    /// Interaction logic for EditSupplyRepo.xaml
    /// </summary>
    public partial class EditSupplyRepo : Window
    {
        Controller controller = Controller.GetInstance();
        public EditSupplyRepo()
        {
            InitializeComponent();

            textBox_ID.IsReadOnly = true;

            controller.LoadValuesIntoList();

            textBox_ID.Text = controller.officeSuppliesValues[0];
            textBox_Name.Text = controller.officeSuppliesValues[1];
            textBox_Description.Text = controller.officeSuppliesValues[2];
            textBox_Amount.Text = controller.officeSuppliesValues[3];
            textBox_Unit.Text = controller.officeSuppliesValues[4];
            textBox_Building.Text = controller.officeSuppliesValues[5];

            controller.LoadValuesIntoComboBox(comboBox_Category);
        }
        private void button_CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(controller.C_ConfirmEdit(textBox_ID.Text, textBox_Name.Text, textBox_Description.Text, textBox_Amount.Text,
                textBox_Unit.Text, textBox_Building.Text, comboBox_Category.SelectedValue.ToString()));

            this.DialogResult = true;
            this.Close();
        }

        private void button_Delete_Click(object sender, RoutedEventArgs e)
        {
            var deleteConfirmation = MessageBox.Show("Are you sure that you want to delete this stock?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (deleteConfirmation == MessageBoxResult.Yes)
            {
                controller.C_DeleteOfficeSupply(Int32.Parse(textBox_ID.Text));

                this.DialogResult = true;
                this.Close();
            }
        }
    }
}

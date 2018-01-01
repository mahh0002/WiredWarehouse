using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Domain_Layer;

namespace UI_Layer
{
    /// <summary>
    /// Interaction logic for AddCategory.xaml
    /// </summary>
    public partial class AddCategory : Page
    {
        Controller controller = Controller.GetInstance();
        public AddCategory()
        {
            InitializeComponent();
            controller.SetCategoryListViewSource(listView_Categories);
        }
        private void Button_AddCategory_Click(object sender, RoutedEventArgs e)
        {
            Controller controller = Controller.GetInstance();
            controller.C_AddCategory(TextBox_NewCategoryName.Text);
            controller.SetCategoryListViewSource(listView_Categories);
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Counting.Xaml", UriKind.Relative));
        }

        private void ListView_Categories_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if ((sender as ListView).SelectedItem != null)
            {
                var deleteConfirmation = MessageBox.Show("Are you sure you want to delete this category?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (deleteConfirmation == MessageBoxResult.Yes)
                {
                    controller.CastSelectedListViewItem((sender as ListView).SelectedItem);
                    controller.LoadValuesIntoList();

                    controller.C_DeleteCategory(controller.officeSuppliesValues[6]);
                    controller.SetCategoryListViewSource(listView_Categories);
                }
            }
        }
    }
}

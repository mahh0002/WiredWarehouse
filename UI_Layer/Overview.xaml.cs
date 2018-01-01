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
    /// Interaction logic for Overview.xaml
    /// </summary>
    public partial class Overview : Page
    {
        Controller controller = Controller.GetInstance();
        public Overview()
        {
            InitializeComponent();

            LoadSource();
            CategorizeList();
        }
        private void ListView_Overview_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if ((sender as ListView).SelectedItem != null)
            {
                controller.CastSelectedListViewItem((sender as ListView).SelectedItem);

                EditSupplyRepo editSupplyRepo = new EditSupplyRepo();
                editSupplyRepo.ShowDialog();

                if (editSupplyRepo.DialogResult == true)
                {
                    LoadSource();
                    CategorizeList();
                }
            }
        }

        private void LoadSource()
        {
            controller.SetListViewSource(listView_Overview);
        }

        private void CategorizeList()
        {
            CollectionView collectionView = (CollectionView)CollectionViewSource.GetDefaultView(listView_Overview.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("categoryTitle");
            collectionView.GroupDescriptions.Add(groupDescription);
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("ChooseFunctionality.Xaml", UriKind.Relative));
        }
    }
}

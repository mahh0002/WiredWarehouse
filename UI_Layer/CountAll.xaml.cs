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
    /// Interaction logic for CountAll.xaml
    /// </summary>
    public partial class CountAll : Page
    {
        Controller controller = Controller.GetInstance();
        Dictionary<int, string> convertToMonth = new Dictionary<int, string>();
        private string SelectedMonth { get; set; }
        private string SelectedYear { get; set; }
        public CountAll()
        {
            InitializeComponent();

            convertToMonth.Add(1, "January");
            convertToMonth.Add(2, "February");
            convertToMonth.Add(3, "March");
            convertToMonth.Add(4, "April");
            convertToMonth.Add(5, "May");
            convertToMonth.Add(6, "June");
            convertToMonth.Add(7, "July");
            convertToMonth.Add(8, "August");
            convertToMonth.Add(9, "September");
            convertToMonth.Add(10, "October");
            convertToMonth.Add(11, "November");
            convertToMonth.Add(12, "December");

            GetSelectedDateTimeAndPresent();
            LoadSource();
            CategorizeList();
        }
        private void Calendar_SelectMonth_DisplayModeChanged(object sender, CalendarModeChangedEventArgs e)
        {
            if (Calendar_SelectMonth.DisplayMode != CalendarMode.Year)
            {
                Calendar_SelectMonth.DisplayMode = CalendarMode.Year;
            }
        }

        private void Calendar_SelectMonth_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            base.OnPreviewMouseLeftButtonUp(e);

            if (Mouse.Captured is Calendar || Mouse.Captured is System.Windows.Controls.Primitives.CalendarItem)
            {
                Mouse.Capture(null);
            }

            GetSelectedDateTimeAndPresent();
        }

        private void GetSelectedDateTimeAndPresent()
        {
            DateTime selectedDateTime = Calendar_SelectMonth.DisplayDate;

            Calendar_SelectMonth.SelectedDate = selectedDateTime;

            SelectedMonth = convertToMonth.First(x => x.Key == selectedDateTime.Month).Value;
            SelectedYear = selectedDateTime.Year.ToString();

            Label_SelectedMonthYear.Content = String.Format("{0} {1}", SelectedMonth, SelectedYear);
        }

        private void ListView_CountSupplies_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if ((sender as ListView).SelectedItem != null)
            {
                controller.CastSelectedListViewItem((sender as ListView).SelectedItem);

                CountSupply countSupply = new CountSupply(SelectedMonth, SelectedYear);
                countSupply.ShowDialog();

                if (countSupply.DialogResult == true)
                {
                    LoadSource();
                    CategorizeList();
                }
            }
        }

        private void LoadSource()
        {
            controller.SetListViewSource(ListView_CountSupplies);
        }

        private void CategorizeList()
        {
            CollectionView collectionView = (CollectionView)CollectionViewSource.GetDefaultView(ListView_CountSupplies.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("categoryTitle");
            collectionView.GroupDescriptions.Add(groupDescription);
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Counting.Xaml", UriKind.Relative));
        }
    }
}

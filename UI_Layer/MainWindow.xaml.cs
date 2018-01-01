using System;
using System.Windows;
using System.Windows.Controls;

namespace UI_Layer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //Start-up procedure
            InitializeComponent();
            mainWindow.Navigate(new ChooseFunctionality());

        }
    }
}

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

namespace SchoolRegister.Desktop
{
    /// <summary>
    /// Interaction logic for SelectionWindow.xaml
    /// </summary>
    public partial class SelectionWindow : Window
    {
        public SelectionWindow()
        {
            InitializeComponent();
            //this.listBox.ItemsSource
            listView.Items.Add("Math");
            listView.Items.Add("English");
            listView.Items.Add("P.E.");
        }

        private void exitbuttonClick(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }

        private void gradesButtonClick(object sender, RoutedEventArgs e)
        {
            var grades = new StudentWindow();
            grades.Show();
        }



        private void listView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            listView2.Items.Add("4a");
            listView2.Items.Add("4b");
            listView2.Items.Add("4c");
        }

        private void listView2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            listView3.Items.Add("Ivaylo Bachvarov");
            listView3.Items.Add("Radoslav Georgiev");
            listView3.Items.Add("Antonia Iordanova");
            listView3.Items.Add("Pavlin Gergov");
        }
    }
}

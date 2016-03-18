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
    /// Interaction logic for StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        public StudentWindow()
        {
            InitializeComponent();
        }

        private void backButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void notifButton(object sender, RoutedEventArgs e)
        {
            var sendNotifcation = new SendNotificationWindow();
            sendNotifcation.ShowDialog();
        }
    }
}

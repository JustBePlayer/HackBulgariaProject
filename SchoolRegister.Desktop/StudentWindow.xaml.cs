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
            listView.Items.Add("Ivaylo Bachvarov");
            listView.Items.Add("Radoslav Georgiev");
            listView.Items.Add("Antonia Iordanova");
            listView.Items.Add("Pavlin Gergov");

            listView1.Items.Add("6, 2, 4");
            listView1.Items.Add("6, 6, 4");
            listView1.Items.Add("5, 5, 6");
            listView1.Items.Add("6, 4, 5");
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
        
        private void addGradebutton(object sender, RoutedEventArgs e)
        {
            var addGrade = new EditGradesWindow();
            addGrade.ShowDialog();
        }
    }
}

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

namespace SchoolRegister.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void signInButtonClick(object sender, RoutedEventArgs e)
        {
            var selectionWindow = new SelectionWindow();
            selectionWindow.Show();
            this.Close();
        }
        
        private void exitButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void mouseDownWindow(object sender, MouseButtonEventArgs e)
        {
            if (forgottenPasswordLabel.IsMouseOver)
                forgottenPasswordClick(sender, e);

            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void forgottenPasswordClick(object sender, MouseButtonEventArgs e)
        {
            var forgottenPass = new ForgottenPasswordForm();
            forgottenPass.Show();
            this.Close();
        }
        
    }
}

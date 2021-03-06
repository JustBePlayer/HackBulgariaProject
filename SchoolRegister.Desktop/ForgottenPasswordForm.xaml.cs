﻿using System;
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
    /// Interaction logic for ForgottenPasswordForm.xaml
    /// </summary>
    public partial class ForgottenPasswordForm : Window
    {
        public ForgottenPasswordForm()
        {
            InitializeComponent();
        }

        private void mouseDownWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void backButtonClick(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void resetButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Email was sent!");
        }
    }
}

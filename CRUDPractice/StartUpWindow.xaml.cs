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
using static CRUDPractice.User;

namespace CRUDPractice
{
    /// <summary>
    /// Interaction logic for StartUpWindow.xaml
    /// </summary>
    public partial class StartUpWindow : Window
    {
        public StartUpWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Text;

            using (var context = new DataContext())
            {
                User user = context.Users.SingleOrDefault(u => u.Username == username && u.Password == password);

                if (user != null)
                {
                    if (user.Userrole == "Admin")
                    {
                        MainWindow2 adminMainWindow = new MainWindow2();
                        this.Visibility = Visibility.Hidden;
                        adminMainWindow.Show();
                    }
                    else
                    {
                        MessageBox.Show("Access Denied! You do not have admin privileges.", "Access Denied");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Access Denied");
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Text;

            using (var context = new DataContext())
            {
                User user = context.Users.SingleOrDefault(u => u.Username == username && u.Password == password);

                if (user != null)
                {
                    if (user.Userrole == "User")
                    {
                        MainWindow normalUserMainWindow = new MainWindow();
                        this.Visibility = Visibility.Hidden;
                        normalUserMainWindow.Show();
                    }
                    else
                    {
                        MessageBox.Show("Access Denied! You do not have user privileges.", "Access Denied");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Access Denied");
                }
            }
        }





        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    string username = UsernameTextBox.Text;
        //    string password = PasswordBox.Text;

        //    using (var context = new DataContext())
        //    {
        //        User user = context.Users.SingleOrDefault(u => u.Username == username && u.Password == password);

        //        if (user.Userrole == "User")
        //        {
        //            MainWindow normalUserMainWindow = new MainWindow();
        //            this.Visibility = Visibility.Hidden;
        //            normalUserMainWindow.Show();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Wrong Data", "Access Denied!");
        //        }

        //    }
        //}

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            System.Windows.Application.Current.Shutdown();
        }
    }
}

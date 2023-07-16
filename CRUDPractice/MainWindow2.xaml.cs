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
using System.Xml.Linq;

namespace CRUDPractice
{
    public partial class MainWindow2 : Window
    {
        public List<User> DatabaseUsers { get; private set; }
        public MainWindow2()
        {
            InitializeComponent();
        }

        public void Create2()
        {
            using (DataContext context = new DataContext())
            {

                var username = UserNameTextBox.Text;
                var password = PassWordTextBox.Text;
                var userrole = UserroleTextBox.Text;
                
                if(!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(userrole))
                {
                    context.Users.Add(new User() { Username = username, Password = password ,Userrole = userrole });
                    context.SaveChanges();
                    MessageBox.Show("You have successfully created a new entry", "DONE!");

                    UserNameTextBox.Text = string.Empty;
                    PassWordTextBox.Text = string.Empty;
                    UserroleTextBox.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Enter the relevant data", "ERROR!");
                }

            }

        }

        public void Read2()
        {
            using (DataContext context = new DataContext())
            {
                DatabaseUsers = context.Users.ToList();
                UserList.ItemsSource = DatabaseUsers;
            }
        }

        public void Update2()
        {
            using (DataContext context = new DataContext())
            {
                User selectedUser = UserList.SelectedItem as User;
                var username = UserNameTextBox.Text;
                var password = PassWordTextBox.Text;
                var userrole = UserroleTextBox.Text;
                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(userrole))
                
                {

                    if(selectedUser != null)
                    {
                        User User = context.Users.Find(selectedUser.Id);
                        User.Username = username;
                        User.Password = password;
                        User.Userrole = userrole;

                        context.SaveChanges();
                        MessageBox.Show("You have successfully updated the selected entry", "DONE!");

                        UserNameTextBox.Text = string.Empty;
                        PassWordTextBox.Text = string.Empty;
                        UserroleTextBox.Text = string.Empty;
                    }
                    else
                    {
                        MessageBox.Show("Select a User to edit", "Error");
                    }
                    

                }
                else if (selectedUser == null)
                {
                    MessageBox.Show("Select An User", "ERROR!");
                }
                else
                {
                    MessageBox.Show("Enter the relevant data", "ERROR!");
                }


            }
        }
        public void Delete2()
        {
            using (DataContext context = new DataContext())
            {
                User selectedUser = UserList.SelectedItem as User;
                if (selectedUser != null)
                {
                    User user = context.Users.Find(selectedUser.Id);
                    context.Remove(user);
                    context.SaveChanges();
                    MessageBox.Show("You have successfully deleted the selected entry", "DONE!");

                }
                else
                {
                    MessageBox.Show("Select a Entry", "ERROR!");
                }

            }

        }

        private void CreateButton_Click2(object sender, RoutedEventArgs e)
        {
            Create2();
            Read2();
            
        }

        private void ReadButton_Click2(object sender, RoutedEventArgs e)
        {
            Read2();
        }

        private void UpdateButton_Click2(object sender, RoutedEventArgs e)
        {
            Update2();
            Read2();
            
        }

        private void DeleteButton_Click2(object sender, RoutedEventArgs e)
        {
            Delete2();
            Read2();
            
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            StartUpWindow startUp = new StartUpWindow();
            this.Visibility = Visibility.Hidden;
            startUp.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //this.Close();
            System.Windows.Application.Current.Shutdown();
        }
    }
}

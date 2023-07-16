using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace CRUDPractice
{
    public partial class MainWindow : Window
    {
        public List<Student> DatabaseStudents { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
        }
        public void Create()
        {
            using (DataContext context = new DataContext())
            {

                var name = NameTextBox.Text;
                var department = DepartmenttextBox.Text;

                
                if(!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(department))
                {
                    context.Students.Add(new Student() { Name = name, Department = department });
                    context.SaveChanges();
                    MessageBox.Show("You have successfully created a new entry", "DONE!");

                    NameTextBox.Text = string.Empty;
                    DepartmenttextBox.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Enter the relevant data", "ERROR!");
                }
            }
        }



        public void Read()
        {
            using (DataContext context = new DataContext())
            {
                DatabaseStudents = context.Students.ToList();
                StudentList.ItemsSource = DatabaseStudents;
            }
        }

        public void Update()
        {
            using (DataContext context = new DataContext())
            {
                Student selectedStudent = StudentList.SelectedItem as Student;
                var name = NameTextBox.Text;
                var department = DepartmenttextBox.Text;
                
                if(!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(department))
                {
                    if(selectedStudent != null)
                    {
                        Student student = context.Students.Find(selectedStudent.Id);
                        student.Name = name;
                        student.Department = department;
                        context.SaveChanges();
                        MessageBox.Show("You have successfully updated the selected entry", "DONE!");

                        NameTextBox.Text = string.Empty;
                        DepartmenttextBox.Text = string.Empty;
                    }
                    else
                    {
                        MessageBox.Show("Select A student to edit", "Error");
                    }
                    
                }
                else if (selectedStudent == null)
                {
                    MessageBox.Show("select a student to edit", "ERROR!");
                }
                else
                {
                    MessageBox.Show("Enter the relevant data", "ERROR!");
                }

            }
        }

        public void Delete()
        {
            using (DataContext context = new DataContext())
            {
                Student selectedStudent = StudentList.SelectedItem as Student;
                if (selectedStudent != null)
                {
                    Student student = context.Students.Find(selectedStudent.Id);
                    context.Remove(student);
                    context.SaveChanges();
                    MessageBox.Show("You have successfully deleted the selected entry", "DONE!");

                }
                else
                {
                    MessageBox.Show("Select a Entry", "ERROR!");
                }
            }

        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            Create();
            Read();

        }

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            Read();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Update();
            Read();

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Delete();
            Read();

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            StartUpWindow startUp2 = new StartUpWindow();
            this.Visibility = Visibility.Hidden;
            startUp2.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //this.Close();
            System.Windows.Application.Current.Shutdown();
        }


    }
}
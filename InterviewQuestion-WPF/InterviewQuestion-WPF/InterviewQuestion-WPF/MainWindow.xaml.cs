using InterviewQuestion_WPF.Bussiness;
using InterviewQuestion_WPF.DataAccess;
using InterviewQuestion_WPF.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;

namespace InterviewQuestion_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly clsStudentBO _studentBO;
        public MainWindow()
        {
            InitializeComponent();
            _studentBO = new clsStudentBO();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var students = _studentBO.GetAll();
            cmbStudents.ItemsSource = students;
            cmbStudents.DisplayMemberPath = "DisplayName";
            cmbStudents.SelectedIndex = 0;
        }

        private void cmbStudents_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            clsStudent student = (clsStudent)cmbStudents.SelectedItem;

            if (student != null)
            {
                lblUserId.Content = student.UserId;
                lblFirstName.Content = student.FirstName;
                lblLastName.Content = student.LastName;
                lblDisplayName.Content = student.DisplayName;
            }

            if (cmbStudents.SelectedIndex == 0)
            {
                btnDelete.IsEnabled = false;
                btnUpdate.IsEnabled = false;
            }
            else
            {
                btnDelete.IsEnabled = true;
                btnUpdate.IsEnabled = true;
            }

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            clsStudent student = (clsStudent)cmbStudents.SelectedItem;
            SaveStudentWindow saveStudentWindow = new SaveStudentWindow(student);
            saveStudentWindow.Closed += UpdateStudentsList;
            saveStudentWindow.ShowDialog();
        }

        private void UpdateStudentsList(object s, EventArgs args)
        {
            cmbStudents.ItemsSource = _studentBO.GetAll();
            cmbStudents.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            SaveStudentWindow saveStudentWindow = new SaveStudentWindow();
            saveStudentWindow.Closed += UpdateStudentsList;
            saveStudentWindow.ShowDialog();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            clsStudent student = (clsStudent)cmbStudents.SelectedItem;
            if (_studentBO.Delete(student.UserId))
            {
                MessageBox.Show("Student deleted successfully.");
                cmbStudents.ItemsSource = _studentBO.GetAll();
                cmbStudents.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Student could not be deleted.");
            }
        }
    }
}

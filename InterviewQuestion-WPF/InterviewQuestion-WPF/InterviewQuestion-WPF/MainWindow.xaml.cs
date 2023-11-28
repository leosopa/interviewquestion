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
        /// <summary>
        /// A reference to the clsStudentBO class to handle all the business logic related to Student.
        /// </summary>
        private readonly clsStudentBO _studentBO;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += Window_Loaded;

            //Initialize the clsStudentBO class to be availiable in all main window life cycle.
            _studentBO = new clsStudentBO();
        }

        #region Events

        /// <summary>
        /// This method is called when the window is loaded.
        /// Load all the students in the combo box.
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var students = _studentBO.GetAll();
            cmbStudents.ItemsSource = students;
            cmbStudents.SelectedIndex = 0;
        }

        /// <summary>
        /// This method is called when the user clicks on the Add button.
        /// Create a new SaveStudentWindow, set a handler to the closed event to update or combo box and then show the Save Student window.
        /// </summary>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            SaveStudentWindow saveStudentWindow = new SaveStudentWindow();
            saveStudentWindow.Closed += UpdateStudentsList;
            saveStudentWindow.ShowDialog();
        }

        /// <summary>
        /// This method is called when the user changes a selected student in the combo box.
        /// After the user selects a student, show the student information in the labels.
        /// Add a check to disable the delete and update buttons when the user selects the first item in the combo box.
        /// </summary>
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

        /// <summary>
        /// This method is called when the user clicks on the Update button.
        /// Then, get the selected student from the combo box and pass it to the SaveStudentWindow by a overloaded constructor.
        /// Set a handler to the closed event to update or combo box and then show the Save Student window.
        /// </summary>
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            clsStudent student = (clsStudent)cmbStudents.SelectedItem;
            SaveStudentWindow saveStudentWindow = new SaveStudentWindow(student);
            saveStudentWindow.Closed += UpdateStudentsList;
            saveStudentWindow.ShowDialog();
        }

        /// <summary> 
        /// This method is called when the user clicks on the Delete button.
        /// Get the selected student from the combo box and pass it to the Delete method in the clsStudentBO class.
        /// If the delete operation succeeds or fails, show to the user a message and update the combo box.
        /// </summary>
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

        /// <summary>
        /// This methodo is the handler for the closed event in the SaveStudentWindow.
        /// Update the list of students in the combo box with the new student added or updated.
        /// </summary>
        private void UpdateStudentsList(object s, EventArgs args)
        {
            cmbStudents.ItemsSource = _studentBO.GetAll();
            cmbStudents.SelectedIndex = 0;
        }

        #endregion
    }
}

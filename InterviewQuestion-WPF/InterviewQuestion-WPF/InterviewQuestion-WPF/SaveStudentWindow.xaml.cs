using InterviewQuestion_WPF.Bussiness;
using InterviewQuestion_WPF.DataAccess;
using InterviewQuestion_WPF.Model;
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

namespace InterviewQuestion_WPF
{
    /// <summary>
    /// Interaction logic for SaveStudent.xaml
    /// </summary>
    public partial class SaveStudentWindow : Window
    {
        /// <summary>
        /// A student object to be used to update the student information.
        /// </summary>
        private clsStudent? _student;

        /// <summary>
        /// A reference to the clsStudentBO class to handle the add and update operations.
        /// </summary>
        private clsStudentBO _studentBO;

        #region Constructors

        /// <summary>
        /// A constructor without parameters that creates a new clsStudentBO object and lets the _student object null.
        /// </summary>
        public SaveStudentWindow()
        {
            InitializeComponent();
            _studentBO = new clsStudentBO();
        }

        /// <summary>
        /// A constructor that receives a clsStudent object to update the student information.
        /// Fill the fields with the student information and disable the user id field for the user not to change it.
        /// </summary>
        /// <param name="student"></param>
        public SaveStudentWindow(clsStudent student)
        {
            InitializeComponent();
            FillData(student);
            _studentBO = new clsStudentBO();
            txtUserId.IsEnabled = false;
        }
        #endregion

        #region Methods

        /// <summary>
        /// This method fills the fields with the parameter student information.
        /// </summary>
        private void FillData(clsStudent student)
        {
            _student = student;
            txtUserId.Text = student.UserId;
            txtFirstName.Text = student.FirstName;
            txtLastName.Text = student.LastName;
            txtDisplayName.Text = student.DisplayName;
        }

        /// <summary>
        /// This methodo validates if all the fields are filled.
        /// </summary>
        private bool ValidateFields()
        {
            if (string.IsNullOrEmpty(txtUserId.Text) ||
                    string.IsNullOrEmpty(txtFirstName.Text) ||
                    string.IsNullOrEmpty(txtLastName.Text) ||
                    string.IsNullOrEmpty(txtDisplayName.Text))
            {
                return false;
            }
            return true;
        }

        #endregion

        #region Events
        /// <summary>
        /// This method is called when the user clicks on the Save button.
        /// First of all, validate if all the fields are filled, then
        /// try to add or update the student information.
        /// In try block, check if the _student object is null, if it is null,
        /// create a new student object and call the Add method from the clsStudentBO class.
        /// IF the _student object is not null, update the student information and call the Update method.
        /// In case of the User Id already exists, catch an StudentAlreadyExistsException and show a message to the user.
        /// </summary>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            bool result = false;
            if (ValidateFields())
            {
                try
                {
                    if (_student == null)
                    {
                        _student = new clsStudent(txtUserId.Text,
                                                  txtFirstName.Text,
                                                  txtLastName.Text,
                                                  txtDisplayName.Text);
                        result = _studentBO.Add(_student);
                    }
                    else
                    {
                        _student.FirstName = txtFirstName.Text;
                        _student.LastName = txtLastName.Text;
                        _student.DisplayName = txtDisplayName.Text;
                        result = _studentBO.Update(_student);
                    }

                    if (result)
                    {
                        MessageBox.Show("Student saved successfully.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error saving student.");
                        _student = null;
                    }
                }
                catch (Exception err)
                {
                    if (err is StudentAlreadyExistsException)
                    {
                        MessageBox.Show(err.Message);
                    }
                    else
                    {
                        MessageBox.Show("Error saving student.");
                    }
                    _student = null;
                }
            }
            else
            {
                MessageBox.Show("All fields are required. Please fill them out.");
            }


        }


        /// <summary>
        /// This method is called when the user clicks on the Cancel button and closes the window.
        /// </summary>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}

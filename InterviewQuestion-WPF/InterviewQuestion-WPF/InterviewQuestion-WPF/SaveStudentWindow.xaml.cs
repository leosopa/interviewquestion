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

        private clsStudent? _student;
        private clsStudentBO _studentBO;

        public SaveStudentWindow(clsStudent student)
        {
            InitializeComponent();
            FillData(student);
            _studentBO = new clsStudentBO();
            txtUserId.IsEnabled = false;
        }

        private void FillData(clsStudent student)
        {
            _student = student;
            txtUserId.Text = student.UserId;
            txtFirstName.Text = student.FirstName;
            txtLastName.Text = student.LastName;
            txtDisplayName.Text = student.DisplayName;
        }

        public SaveStudentWindow()
        {
            InitializeComponent();
            _studentBO = new clsStudentBO();
        }

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

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

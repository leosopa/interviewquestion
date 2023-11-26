using InterviewQuestion_WPF.DataAccess;
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

        public SaveStudentWindow(clsStudent student)
        {
            InitializeComponent();
            FillData(student);
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
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            bool result = false;

            if (_student == null)
            {
                _student = new clsStudent(txtUserId.Text,
                                          txtFirstName.Text,
                                          txtLastName.Text,
                                          txtDisplayName.Text);
                result = Util.Add(_student);
            }
            else
                result = Util.Update(_student);

            if (result)
            {
                MessageBox.Show("Student saved successfully");
                this.Close();
            }
            else
                MessageBox.Show("Error saving student");
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

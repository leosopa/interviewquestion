using InterviewQuestion_WPF.ViewModel;
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

namespace InterviewQuestion_WPF.View
{
    /// <summary>
    /// This user control is used to show the details of a student.
    /// In XAML file, I bound the controls' properties to the ViewModel's properties.
    /// The combo box is bound to the list of students.
    /// When the user change the selected item in the combo box, the ViewModel's properties are updated and the UI is updated with the new values.
    /// </summary>
    public partial class StudentDetails : UserControl
    {
        public StudentDetails()
        {   
            InitializeComponent();

        }
    }
}

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
    /// This control is used to save a student.
    /// I used a UserControl because I want to reuse it in the MainWindow.
    /// In the XAML file, I bound the controls' properties to the ViewModel's properties.
    /// </summary>
    public partial class SaveStudent : UserControl
    {
        public SaveStudent()
        {
            InitializeComponent();
        }
    }
}

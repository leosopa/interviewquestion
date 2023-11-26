using InterviewQuestion_WPF.DataAccess;
using InterviewQuestion_WPF.Model;
using InterviewQuestion_WPF.ViewModel;
using InterviewQuestion_WPF.ViewModel.Base;
using System.Windows;
using System.Windows.Controls;

namespace InterviewQuestion_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new clsStudentViewModel();
            InitializeComponent();
            this.SizeToContent = SizeToContent.Height;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            clsStudentViewModel clsStudentViewModel = (clsStudentViewModel)DataContext;
            clsStudentViewModel.IsDetailVisible = true;
            clsStudentViewModel.IsCommandsVisible = true;
            clsStudentViewModel.IsSaveVisible = false;
            clsStudentViewModel.UpdateStudentsList();
        }
    }
}

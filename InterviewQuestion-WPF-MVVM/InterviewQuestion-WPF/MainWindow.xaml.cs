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
            this.SizeToContent = SizeToContent.WidthAndHeight;
            this.ResizeMode = ResizeMode.NoResize;
        }


        /// <summary>
        /// This method is called when the SaveStudent view are visible and the user clicks on the cancel button.
        /// This is the only method that is called from the view because I want to keep the view as simple as possible and all operations are executed in the ModelView.
        /// </summary>
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

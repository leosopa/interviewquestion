using InterviewQuestion_WPF.DataAccess;
using InterviewQuestion_WPF.Model;
using InterviewQuestion_WPF.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace InterviewQuestion_WPF.ViewModel
{
    public class clsStudentViewModel : clsViewModelBase
    {
        private readonly clsStudentRepository _studentRepository = new clsStudentRepository();
        private bool _isUpdate = false;

        #region Properties

        /// <summary>
        /// Defines the selected student.
        /// </summary>
        private clsStudent? _student = null;
        public clsStudent? Student
        {
            get { return _student; }
            set
            {
                _student = value;
                OnPropertyChanged();
            }
        }


        /// <summary>
        /// Defines the list of students.
        /// </summary>
        private List<clsStudent> _students = new List<clsStudent>();
        public List<clsStudent> Students
        {
            get { return _students; }
            set
            {
                _students = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Defines if the Save button is visible or not.
        /// </summary>
        private bool _isSaveVisible = false;
        public bool IsSaveVisible
        {
            get { return _isSaveVisible; }
            set
            {
                _isSaveVisible = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Defines if the student details are visible or not.
        /// </summary>
        private bool _isDetailVisible = true;
        public bool IsDetailVisible
        {
            get { return _isDetailVisible; }
            set
            {
                _isDetailVisible = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Defines if the commands Add, Update and Delete are visible or not.
        /// </summary>
        private bool _isCommandsVisible = true;
        public bool IsCommandsVisible
        {
            get { return _isCommandsVisible; }
            set
            {
                _isCommandsVisible = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Defines if the user id field can be edited or not.
        /// </summary>
        private bool _isUserIdEnabled = true;
        public bool IsUserIdEnabled
        {
            get { return _isUserIdEnabled; }
            set
            {
                _isUserIdEnabled = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public ICommand? AddCommand { get; }
        public ICommand? DeleteCommand { get; }
        public ICommand? UpdateCommand { get; }
        public ICommand? SaveCommand { get; }   

        /// <summary>
        /// Verifies if the selected student is not null and if the UserId is not the default value.
        /// If the UserId is the default value, the command cannot be executed.
        /// </summary>
        private bool CanExecuteCommand()
        {
            if (Student != null && !Student.UserId.Equals("---"))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Verifies if the selected student is not null and if all the fields in the SaveStudent control are filled.
        /// If any of the Students properties are null or empty, the command cannot be executed.
        /// </summary>
        private bool CanExecuteSaveCommand()
        {
            if (Student != null 
                && !Student.UserId.Equals(string.Empty)
                && !Student.FirstName.Equals(string.Empty)
                && !Student.LastName.Equals(string.Empty)
                && !Student.DisplayName.Equals(string.Empty))
                return true;
            else
                return false;
        }

        /// <summary>
        /// When the Update button in iew is clicked, the IsCommandsVisible and IsDetailVisible properties are set to false and the IsSaveVisible property is set to true.
        /// By the MVVM pattern, when the IsSaveVisible property is set to true, the SaveStudent control is visible, and the StudentDetails and Commands buttons are hidden.
        /// In order to update a student, the UserId field cannot be edited.
        /// </summary>
        /// <param name="obj"></param>
        private void UpdateStudent(object obj)
        {
            IsCommandsVisible = false;
            IsDetailVisible = false;
            IsSaveVisible = true;
            IsUserIdEnabled = false;
            _isUpdate = true;
        }

        /// <summary>
        /// When the Delete button in view is clicked, the DeleteStudent method is called.
        /// The selected student from the combo box is deleted from the database by the repository class.
        /// After that, the Students and the Selected Student are refreshed.
        /// </summary>
        /// <param name="obj"></param>
        private void DeleteStudent(object obj)
        {

            if (_studentRepository.DeleteStudent(Student))
                MessageBox.Show("Student deleted successfully!");
            else
                MessageBox.Show("Error deleting student!");
            Students = _studentRepository.GetAllStudents();
            Student = Students.FirstOrDefault();
        }


        /// <summary>
        /// When the Add button in view is clicked, the IsCommandsVisible and IsDetailVisible properties are set to false and the IsSaveVisible property is set to true.
        /// In add operations the user id field can be edited.
        /// I created a new clsStudent object to be used in the SaveStudent control because we want to add a new student, not to update a selected one.
        /// </summary>
        private void AddStudent(object obj)
        {
            Student = new clsStudent();
            IsCommandsVisible = false;
            IsDetailVisible = false;
            IsSaveVisible = true;
            IsUserIdEnabled = true;
        }

        /// <summary>
        /// This method is called when the Save button in view is clicked.
        /// First after all, if need to verify if the Student property is not null.
        /// Then we need to verify if the Student exists in the database. 
        /// If the Student does not exists, we need to add it to the database.
        /// If the Student exists, we need to update it in the database.
        /// After that, the Students and the Selected Student are refreshed and the SaveStudent control is hidden to show the StudentDetails and Commands buttons.
        /// </summary>
        private void SaveStudent(object obj)
        {
            if (Student != null)
            {
                bool result = false;
                if (!_isUpdate)
                {
                    try
                    {
                        result = _studentRepository.AddStudent(Student);
                    }
                    catch (StudentAlreadyExistsException e)
                    {
                        MessageBox.Show(e.Message);
                        return;
                    }
                }
                else
                {
                    result = _studentRepository.UpdateStudent(Student);
                }

                if (result)
                    MessageBox.Show("Student saved successfully!");
                else
                    MessageBox.Show("Error saving student!");

                string studentId = Student.UserId;
                Students = _studentRepository.GetAllStudents();
                Student = Students.FirstOrDefault(s => s.UserId == studentId);
                IsCommandsVisible = true;
                IsDetailVisible = true;
                IsSaveVisible = false;
                _isUpdate = false;
            }
        }


        #endregion

        #region Methods

        /// <summary>
        /// This method updates the Students list with the data from the database and define the selected student for the first line.
        /// I created this method to avoid repeating the code in case I need to create a new action in addition to the SaveStudent method.
        /// </summary>
        public void UpdateStudentsList()
        {
            Students = _studentRepository.GetAllStudents();
            Student = Students.FirstOrDefault();
        }
        #endregion

        /// <summary>
        /// Creates a new instance of clsStudentViewModel.
        /// When the constructor is called, the Students property is initialized with the data from the database.
        /// The Student property is initialized with the first student from the Students list.
        /// This two properties are binded to the UI. The Students property is binded to the ComboBox ItemSource and the Student property is binded to the Combobox SelectedItem.
        /// The add command is binded to the Add button and does not needs a predicate to be executed because the Add button is always enabled.
        /// For the Delete and Update commands we need to specify a predicate to indicate if the command can be executed or not.
        /// To the save command we need to specify a predicate to indicate if the command can be executed or not. The predicate verify if all the fields are filled.
        /// </summary>
        public clsStudentViewModel()
        {
            Students = _studentRepository.GetAllStudents();
            Student = Students.FirstOrDefault();
            AddCommand = new clsRelayCommand(AddStudent);
            SaveCommand = new clsRelayCommand(SaveStudent, f => CanExecuteSaveCommand());
            DeleteCommand = new clsRelayCommand(DeleteStudent, f => CanExecuteCommand());
            UpdateCommand = new clsRelayCommand(UpdateStudent, f => CanExecuteCommand());
        }

        
    }
}

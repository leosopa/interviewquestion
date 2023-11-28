using InterviewQuestion_WPF.DataAccess;
using InterviewQuestion_WPF.Model;
using InterviewQuestion_WPF.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InterviewQuestion_WPF.ViewModel
{
    public class clsStudentViewModel : clsViewModelBase
    {
        private readonly clsStudentRepository _studentRepository = new clsStudentRepository();

        #region Properties
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

        #endregion

        #region Commands

        public ICommand? AddCommand { get; }
        public ICommand? DeleteCommand { get; }
        public ICommand? UpdateCommand { get; }
        public ICommand? SaveCommand { get; }   

        private bool CanExecuteCommand()
        {
            if (Student != null && !Student.UserId.Equals("---"))
                return true;
            else
                return false;
        }

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

        private void UpdateStudent(object obj)
        {
            IsCommandsVisible = false;
            IsDetailVisible = false;
            IsSaveVisible = true;
        }

        private void DeleteStudent(object obj)
        {
            _studentRepository.DeleteStudent(Student);
            Students = _studentRepository.GetAllStudents();
            Student = Students.FirstOrDefault();
        }

        private void AddStudent(object obj)
        {
            Student = new clsStudent();
            IsCommandsVisible = false;
            IsDetailVisible = false;
            IsSaveVisible = true;
        }

        private void SaveStudent(object obj)
        {
            if (Student != null)
            {
                if (Students.FirstOrDefault(s => s.UserId == Student.UserId) == null)
                {
                    _studentRepository.AddStudent(Student);
                }
                else
                {
                    _studentRepository.UpdateStudent(Student);
                }
                string studentId = Student.UserId;
                Students = _studentRepository.GetAllStudents();
                Student = Students.FirstOrDefault(s => s.UserId == studentId);
                IsCommandsVisible = true;
                IsDetailVisible = true;
                IsSaveVisible = false;
            }
        }


        #endregion

        #region Methods
        public void UpdateStudentsList()
        {
            Students = _studentRepository.GetAllStudents();
            Student = Students.FirstOrDefault();
        }
        #endregion

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

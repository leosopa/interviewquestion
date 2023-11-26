using InterviewQuestion_WPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestion_WPF.DataAccess
{
    public class clsStudentRepository
    {

        public List<clsStudent> GetAllStudents()
        {

            return Util.GetStudents();

        }

        public bool AddStudent(clsStudent student)
        {
            return Util.AddStudent(student);
        }

        internal bool DeleteStudent(clsStudent? student)
        {
            return Util.DeleteStudent(student.UserId);
        }

        public bool UpdateStudent(clsStudent student)
        {
            return Util.UpdateStudent(student);
        }
    }
}

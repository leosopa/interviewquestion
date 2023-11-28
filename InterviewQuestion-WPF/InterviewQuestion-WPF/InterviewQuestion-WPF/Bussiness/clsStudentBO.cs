using InterviewQuestion_WPF.DataAccess;
using InterviewQuestion_WPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestion_WPF.Bussiness
{
    public class clsStudentBO
    {

        public bool Add(clsStudent student)
        {
            clsStudent clsStudent = Util.GetStudentById(student.UserId);

            if (clsStudent != null)
            {
                throw new StudentAlreadyExistsException("User ID already exists. Please choose a different one.");
            }

            return Util.AddStudent(student);
        }

        public bool Delete(string uid)
        {
            return Util.DeleteStudent(uid);
        }

        public List<clsStudent> GetAll()
        {
            return Util.GetStudents();
        }

        public bool Update(clsStudent student)
        {
            return Util.UpdateStudent(student);
        }

    }
}

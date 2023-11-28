using InterviewQuestion_WPF.DataAccess;
using InterviewQuestion_WPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestion_WPF.Bussiness
{
    /// <summary>
    /// Class to handle all the business logic related to Student.
    /// Here we can add rules to validate or add any other logic related to Student.
    /// The reason that we are not using the same methods from Util class is the we can add some business logic here.
    /// </summary>
    public class clsStudentBO
    {
        /// <summary>
        /// List all students in the repository. 
        /// </summary>
        /// <returns>A list of clsStudents objects</returns>
        public List<clsStudent> GetAll()
        {
            return Util.GetStudents();
        }

        /// <summary>
        /// Add a new student to the repository.
        /// Here we verify if the user id already exists because we don't use a database and we don't have a unique constraint on the user id.
        /// </summary>
        /// <param name="student"></param>
        /// <returns>A boolean value that represents the success or failure of the insert operation.</returns>
        /// <exception cref="StudentAlreadyExistsException"></exception>
        public bool Add(clsStudent student)
        {
            clsStudent clsStudent = Util.GetStudentById(student.UserId);

            if (clsStudent != null)
            {
                throw new StudentAlreadyExistsException("User ID already exists. Please choose a different one.");
            }

            return Util.AddStudent(student);
        }

        /// <summary>
        /// Delete a student from the repository.
        /// </summary>
        /// <param name="uid">The User Id</param>
        /// <returns>A boolean value that represents the success or failure of the delete operation.</returns>
        public bool Delete(string uid)
        {
            return Util.DeleteStudent(uid);
        }

        /// <summary>
        /// Update a student in the repository.
        /// </summary>
        /// <param name="student">A clsStudent object to update in the repository</param>
        /// <returns>A boolean value that represents the success or failure of the update.</returns>
        public bool Update(clsStudent student)
        {
            return Util.UpdateStudent(student);
        }

    }
}

using InterviewQuestion_WPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestion_WPF.DataAccess
{
    /// <summary>
    /// Represents the Student Repository
    /// Here the program access the data from the database. 
    /// In this case the database is a file and is accessed using the Util class.
    /// By this way, we can also access the data from a database using ADO.NET or Entity Framework whitout changing the code in the ViewModel.
    /// </summary>
    public class clsStudentRepository
    {
        /// <summary>
        /// This method returns all the students from the database
        /// </summary>
        /// <returns>A list of clsStudent objects.</returns>
        public List<clsStudent> GetAllStudents()
        {

            return Util.GetStudents();

        }

        /// <summary>
        /// This method add a student to the repository.
        /// </summary>
        /// <param name="student">A clsStudent object to save</param>
        /// <returns>A boolean value that represents the success or failure of the add operation.</returns>
        public bool AddStudent(clsStudent student)
        {

            clsStudent clsStudent = Util.GetStudentById(student.UserId);

            if (clsStudent != null)
            {
                throw new StudentAlreadyExistsException("User ID already exists. Please choose a different one.");
            }

            return Util.AddStudent(student);
        }

        /// <summary>
        /// This method delete a student from the repository.
        /// </summary>
        /// <param name="student">a clsStudent object to delete</param>
        /// <returns>A boolean value that represents the success or failure of the delete operation.</returns>
        internal bool DeleteStudent(clsStudent? student)
        {
            return Util.DeleteStudent(student.UserId);
        }

        /// <summary>
        /// This method update a student from the repository.
        /// </summary>
        /// <param name="student">a clsStudent object to update</param>
        /// <returns>A boolean value that represents the success or failure of the update operation.</returns>
        public bool UpdateStudent(clsStudent student)
        {
            return Util.UpdateStudent(student);
        }
    }
}

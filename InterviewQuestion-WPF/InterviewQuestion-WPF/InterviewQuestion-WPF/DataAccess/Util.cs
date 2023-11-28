using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using InterviewQuestion_WPF.Model;

namespace InterviewQuestion_WPF.DataAccess
{
    /// <summary>
    /// Our repository is a file.
    /// This class is used to access the data in the file.
    /// </summary>
    public static class Util
    {
     
        /// <summary>
        /// This method reads the file, create and then returns a list of clsStudent objects.
        /// </summary>
        /// <returns>The list of students in the database.</returns>
        internal static List<clsStudent> GetStudents()
        {
            List<clsStudent> students = new List<clsStudent>();
            string[] lines = File.ReadAllLines(@"DataAccess\StudentData.txt");
            foreach (string line in lines)
            {
                string[] tokens = line.Split(',');
                clsStudent student = new(tokens[0].Trim(),
                                         tokens[1].Trim(),
                                         tokens[2].Trim(),
                                         tokens[3].Trim());
                students.Add(student);
            }
            return students;
        }

        /// <summary>
        /// This method returns a clsStudent object by its User Id from the file.
        /// </summary>
        /// <param name="uid">The Student Unique Id</param>
        /// <returns>A clsStudent object that represents that UID or null</returns>
        internal static clsStudent GetStudentById(string uid)
        {
            List<clsStudent> students = GetStudents();

            clsStudent student = students.FirstOrDefault(s => s.UserId == uid);

            return student;
        }

        /// <summary>
        /// This method adds a new student to the file.
        /// </summary>
        /// <param name="student">A clsStudent object to insert in the file.</param>
        /// <returns>A boolean value that represents the success or failure of the add operation.</returns>
        internal static bool AddStudent(clsStudent student)
        {
            bool added = false;

            string studentLine = string.Format("{0}, {1}, {2}, {3}", student.UserId, student.FirstName, student.LastName, student.DisplayName);

            try
            {
                using (StreamWriter file = new(@"DataAccess\StudentData.txt", append: true))
                {
                    file.WriteLine(studentLine);
                }
                added = true;
            }
            catch (IOException e)
            {
                System.Console.WriteLine("The file could not be read:");
                System.Console.WriteLine(e.Message);
            }
            return added;
        }

        /// <summary>
        /// This method deletes a student from the file.
        /// </summary>
        /// <param name="uid">The Student Unique Id to delete</param>
        /// <returns>A boolean value that represents the success or failure of the delete.</returns>
        internal static bool DeleteStudent(string uid)
        {

            bool deleted = false;

            List<clsStudent> students = GetStudents();

            clsStudent student = students.FirstOrDefault(s => s.UserId == uid);

            if (student != null)
            {
                students.Remove(student);

                using (StreamWriter file = new(@"DataAccess\StudentData.txt", append: false))
                {
                    foreach (clsStudent s in students)
                    {
                        try
                        {
                            string studentLine = string.Format("{0}, {1}, {2}, {3}", s.UserId, s.FirstName, s.LastName, s.DisplayName);

                            file.WriteLine(studentLine);
                        }
                        catch (IOException e)
                        {
                            System.Console.WriteLine("The file could not be read:");
                            System.Console.WriteLine(e.Message);
                        }
                    }
                }

                deleted = true;
            }

            return deleted;
        }

        /// <summary>
        /// This method updates a student in the file.
        /// </summary>
        /// <param name="student">A clsStudent object to update</param>
        /// <returns>A boolean value that represents the success or failure of the update operation.</returns>
        internal static bool UpdateStudent(clsStudent student)
        {
            bool updated = false;

            List<clsStudent> students = GetStudents();

            clsStudent oldStudent = students.FirstOrDefault(s => s.UserId == student.UserId);

            if (oldStudent != null)
            {
                oldStudent.FirstName = student.FirstName;
                oldStudent.LastName = student.LastName;
                oldStudent.DisplayName = student.DisplayName;

                using (StreamWriter file = new(@"DataAccess\StudentData.txt", append: false))
                {
                    foreach (clsStudent s in students)
                    {
                        try
                        {
                            string studentLine = string.Format("{0}, {1}, {2}, {3}", s.UserId, s.FirstName, s.LastName, s.DisplayName);

                            file.WriteLine(studentLine);
                        }
                        catch (IOException e)
                        {
                            System.Console.WriteLine("The file could not be read:");
                            System.Console.WriteLine(e.Message);
                        }
                    }
                }

                updated = true;
            }

            return updated;
        }
    }
}

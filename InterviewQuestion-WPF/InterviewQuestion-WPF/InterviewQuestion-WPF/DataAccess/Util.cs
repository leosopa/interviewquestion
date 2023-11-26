using System;
using System.Collections.Generic;
using System.IO;

namespace InterviewQuestion_WPF.DataAccess
{
    public static class Util
    {
        public static List<clsStudent> GetStudents()
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

        public static bool DeleteStudent(clsStudent selectedItem)
        {
            return true;
        }

        internal static bool Add(clsStudent student)
        {
            return true;
        }

        internal static bool Update(clsStudent student)
        {
            return true;
        }
    }
}

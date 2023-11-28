using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestion_WPF.Bussiness
{
    /// <summary>
    /// As I don't have a database, and I use a file to store the data, I created this Exception to handle 
    /// when a student already exists in the repository.
    /// </summary>
    public class StudentAlreadyExistsException : Exception
    {
        public StudentAlreadyExistsException(string? message) : base(message)
        {
        }
    }
}

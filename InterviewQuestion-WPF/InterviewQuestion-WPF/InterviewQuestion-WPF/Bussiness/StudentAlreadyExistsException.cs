using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestion_WPF.Bussiness
{
    /// <summary>
    /// As we don't have a database, and we use a file to store the data, we create this Exception to handle 
    /// when a student already exists in the repository.
    /// </summary>
    public class StudentAlreadyExistsException : Exception
    {
        public StudentAlreadyExistsException(string? message) : base(message)
        {
        }
    }
}

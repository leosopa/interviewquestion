using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestion_WPF.Bussiness
{
    public class StudentAlreadyExistsException : Exception
    {
        public StudentAlreadyExistsException(string? message) : base(message)
        {
        }
    }
}

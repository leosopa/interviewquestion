using System;
using System.Runtime.Serialization;

namespace InterviewQuestion_WPF.DataAccess
{
    [Serializable]
    internal class StudentAlreadyExistsException : Exception
    {
        public StudentAlreadyExistsException()
        {
        }

        public StudentAlreadyExistsException(string? message) : base(message)
        {
        }

        public StudentAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected StudentAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
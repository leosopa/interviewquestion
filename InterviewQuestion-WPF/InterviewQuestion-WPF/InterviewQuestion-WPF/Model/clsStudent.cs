namespace InterviewQuestion_WPF.Model
{
    /// <summary>
    /// Class to represent a Student.
    /// </summary>
    public class clsStudent
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }

        public clsStudent(string uid,
                          string fn,
                          string ln,
                          string dn)
        {
            UserId = uid;
            FirstName = fn;
            LastName = ln;
            DisplayName = dn;
        }
    }
}

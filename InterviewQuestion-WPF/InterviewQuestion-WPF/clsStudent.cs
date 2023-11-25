namespace InterviewQuestion_WPF
{
    public class clsStudent
    {
        public string UserId;
        public string FirstName;
        public string LastName;
        public string DisplayName;

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

namespace InterviewQuestion_WPF.Model
{
    public class clsStudent
    {
        private string userId;
        private string firstName;
        private string lastName;
        private string displayName;

        public string UserId { get => userId; set => userId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string DisplayName { get => displayName; set => displayName = value; }

        public clsStudent(string uid,
                          string fn,
                          string ln,
                          string dn)
        {
            userId = uid;
            FirstName = fn;
            LastName = ln;
            DisplayName = dn;
        }
        public clsStudent()
        {
            userId = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            DisplayName = string.Empty;
        }
    }
}

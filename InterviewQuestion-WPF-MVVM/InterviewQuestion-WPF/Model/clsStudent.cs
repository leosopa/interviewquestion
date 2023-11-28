namespace InterviewQuestion_WPF.Model
{
    /// <summary>
    /// Represents a Student
    /// Encapsulate the data from the database.
    /// I needed to change the original class to add properties that can be bound to the UI.
    /// </summary>
    public class clsStudent
    {

        #region Properties
        private string userId;
        private string firstName;
        private string lastName;
        private string displayName;

        public string UserId { get => userId; set => userId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string DisplayName { get => displayName; set => displayName = value; }
        #endregion

        #region Constructors
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
        #endregion
    }
}

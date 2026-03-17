namespace CW.FreelanceWork.Model
{
    public class User
    {
        public int UserID { get; set; }
        public string FIO { get; set; }
        public string UserPhone { get; set; }   // used as password
        public string UserMail { get; set; }    // used as login
        public string UserSkills { get; set; }
        public int RoleID { get; set; }
        public Role Role { get; set; }
    }
}

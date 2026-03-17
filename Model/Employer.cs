namespace CW.FreelanceWork.Model
{
    public class Employer
    {
        public int EmployerID { get; set; }
        public string FIO { get; set; }          // company name
        public string INN { get; set; }
        public string EmployerPhone { get; set; } // used as password
        public string EmployerMail { get; set; }  // used as login
    }
}

namespace CW.FreelanceWork.Model
{
    public class OrderBoard
    {
        public int OrderBoardID { get; set; }
        public string Order { get; set; }
        public int EmployerID { get; set; }
        public int? UserID { get; set; }
        public Employer Employer { get; set; }
        public User User { get; set; }
    }
}

namespace EF_Multilayer.ViewModels
{
    public class EmployeeVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
    public class SkillsVM
    {
        public int SkillId { get; set; }
        public string TechName { get; set; }
        public decimal? WorkExp { get; set; }
        public decimal? Rating { get; set; }
        public int EmployeeId { get; set; }
    }
    public class DetailsVM
    {
        public int DetailId { get; set; }
        public string SystemName { get; set; }
        public string SeatCode { get; set; }
        public string IpAddress { get; set; }
        public int EmployeeId { get; set; }
    }
}

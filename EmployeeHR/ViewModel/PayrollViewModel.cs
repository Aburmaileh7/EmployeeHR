namespace EmployeeHR.ViewModel
{
    public class PayrollViewModel
    {

        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime PayrollDate { get; set; }
        public decimal Bonus { get; set; }
        public decimal SocialSecurityAmount { get; set; }
        public float? Leaves { get; set; }
        public decimal NetSalary { get; set; }
        public DateTime TS { get; set; }
        public string CreatedBy { get; set; }
        public string EmployeeFullName { get; set; }
        public string BasicSalary { get; set; }
    }
}

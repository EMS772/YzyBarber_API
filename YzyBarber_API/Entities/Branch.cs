namespace YzyBarber_API.Entities
{
    public class Branch
    {
        public int BranchId { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public string BranchName { get; set; }
        public string BranchPhone { get; set; }
        public string Address { get; set; }
    }
}

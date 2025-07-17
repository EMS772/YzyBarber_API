namespace YzyBarber_API.Entities
{
    public class Barber
    {
        public int BarberId { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public string BarberName { get; set; }
        public string Phone { get; set; }
    }
}

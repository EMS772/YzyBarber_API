namespace YzyBarber_API.DTO_s.AppointmentDTO_s
{
    public class CreateAppointmentDTO
    {
        public int ClientId { get; set; }
        public int BarberId { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Schedule { get; set; }
        public bool IsAdult { get; set; }
        public string PaymentMethod { get; set; }
        public string AppointmentStatus { get; set; }
    }
}

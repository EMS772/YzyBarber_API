using System.Drawing;

namespace YzyBarber_API.Entities
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int BarberId { get; set; }
        public Barber Barber { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Schedule { get; set; }
        public bool IsAdult { get; set; }
        public string PaymentMethod { get; set; }
        public string AppointmentStatus { get; set; }
    }
}

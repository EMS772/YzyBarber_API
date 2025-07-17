using YzyBarber_API.DTO_s.AppointmentDTO_s;

namespace YzyBarber_API.Interfaces
{
    public interface IAppointmentService
    {
        public List<AppointmentDTO> GetAppointments();
        public AppointmentDTO CreateAppointment(CreateAppointmentDTO Appointment);
        public AppointmentDTO UpdateAppointment(int Id, CreateAppointmentDTO Appointment);
        public void DeleteAppointment(int Id);
    }
}

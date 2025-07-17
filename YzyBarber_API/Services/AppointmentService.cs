using YzyBarber_API.Data;
using YzyBarber_API.DTO_s.AppointmentDTO_s;
using YzyBarber_API.Entities;
using YzyBarber_API.Interfaces;

namespace YzyBarber_API.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly BarberDbContext _dbcontext;

        public AppointmentService(BarberDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public AppointmentDTO CreateAppointment(CreateAppointmentDTO dto)
        {
            var exists = _dbcontext.Appointments.Any(a =>
            a.ClientId == dto.ClientId &&
            a.Date == dto.Date &&
            a.Schedule == dto.Schedule);

            if (exists)
                throw new ArgumentException("This client already has an appointment on that date and time.");

            var appointment = new Appointment
            {
                ClientId = dto.ClientId,
                BarberId = dto.BarberId,
                Date = dto.Date,
                Schedule = dto.Schedule,
                IsAdult = dto.IsAdult,
                PaymentMethod = dto.PaymentMethod,
                AppointmentStatus = dto.AppointmentStatus
            };

            _dbcontext.Appointments.Add(appointment);
            _dbcontext.SaveChanges();

            return new AppointmentDTO
            {
                AppointmentId = appointment.AppointmentId,
                ClientId = appointment.ClientId,
                BarberId = appointment.BarberId,
                Date = appointment.Date,
                Schedule = appointment.Schedule,
                IsAdult = appointment.IsAdult,
                PaymentMethod = appointment.PaymentMethod,
                AppointmentStatus = appointment.AppointmentStatus
            };
        }

        public void DeleteAppointment(int id)
        {
            var appointment = _dbcontext.Appointments.FirstOrDefault(a => a.AppointmentId == id);
            if (appointment == null)
                throw new ArgumentException("Appointment not found");

            _dbcontext.Appointments.Remove(appointment);
            _dbcontext.SaveChanges();
        }

        public List<AppointmentDTO> GetAppointments()
        {
            return _dbcontext.Appointments
                .Select(a => new AppointmentDTO
                {
                    AppointmentId = a.AppointmentId,
                    ClientId = a.ClientId,
                    BarberId = a.BarberId,
                    Date = a.Date,
                    Schedule = a.Schedule,
                    IsAdult = a.IsAdult,
                    PaymentMethod = a.PaymentMethod,
                    AppointmentStatus = a.AppointmentStatus
                }).ToList();
        }

        public AppointmentDTO UpdateAppointment(int id, CreateAppointmentDTO dto)
        {
            var exists = _dbcontext.Appointments.Any(a =>
            a.ClientId == dto.ClientId &&
            a.Date == dto.Date &&
            a.Schedule == dto.Schedule);

            if (exists)
            {
                throw new ArgumentException("This client already has an appointment on that date and time.");
            }

            var appointment = _dbcontext.Appointments.FirstOrDefault(a => a.AppointmentId == id);
            if (appointment == null)
                throw new ArgumentException("Appointment not found");

            appointment.ClientId = dto.ClientId;
            appointment.BarberId = dto.BarberId;
            appointment.Date = dto.Date;
            appointment.Schedule = dto.Schedule;
            appointment.IsAdult = dto.IsAdult;
            appointment.PaymentMethod = dto.PaymentMethod;
            appointment.AppointmentStatus = dto.AppointmentStatus;

            _dbcontext.SaveChanges();

            return new AppointmentDTO
            {
                ClientId = appointment.ClientId,
                BarberId = appointment.BarberId,
                Date = appointment.Date,
                Schedule = appointment.Schedule,
                IsAdult = appointment.IsAdult,
                PaymentMethod = appointment.PaymentMethod,
                AppointmentStatus = appointment.AppointmentStatus
            };
        }
    }
}

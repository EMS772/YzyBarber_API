using YzyBarber_API.DTO_s.BarberDTO_s;

namespace YzyBarber_API.Interfaces
{
    public interface IBarberService
    {
        public List<BarberDTO> GetBarbers();
        public BarberDTO CreateBarber(CreateBarberDTO Barber);
        public BarberDTO UpdateBarber(int Id, CreateBarberDTO Barber);
        public void DeleteBarber(int Id);

    }
}

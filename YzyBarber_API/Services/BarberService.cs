using YzyBarber_API.Data;
using YzyBarber_API.DTO_s.BarberDTO_s;
using YzyBarber_API.Entities;
using YzyBarber_API.Interfaces;

namespace YzyBarber_API.Services
{
    public class BarberService : IBarberService
    {
        private readonly BarberDbContext _dbcontext;
        public BarberService(BarberDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public BarberDTO CreateBarber(CreateBarberDTO Barber)
        {
            var exists = _dbcontext.Barbers.Any(b =>
            b.BarberName == Barber.BarberName &&
            b.Phone == Barber.Phone);

            if (exists)
            {
                throw new ArgumentException("There is already a barber with the same name and phone number.");
            }

            var barber = new Barber
            {
                BranchId = Barber.BranchId,
                BarberName = Barber.BarberName,
                Phone = Barber.Phone
            };
            _dbcontext.Barbers.Add(barber);
            _dbcontext.SaveChanges();
            return new BarberDTO
            {

                BranchId = barber.BranchId,
                BarberName = barber.BarberName,
                Phone = barber.Phone
            };
        }

        public void DeleteBarber(int Id)
        {
            var barber = _dbcontext.Barbers.FirstOrDefault(b => b.BarberId == Id);
            if (barber == null)
            {
                throw new ArgumentException("Barber not found");
            }
            _dbcontext.Remove(barber);
            _dbcontext.SaveChanges();
        }

        public List<BarberDTO> GetBarbers()
        {
            var barbers = _dbcontext.Barbers.Select(b => new BarberDTO
            {
                BarberId=b.BarberId,
                BranchId = b.BranchId,
                BarberName = b.BarberName,
                Phone = b.Phone
            }).ToList();
            return barbers;
        }

        public BarberDTO UpdateBarber(int Id, CreateBarberDTO Barber)
        {


            var barber = _dbcontext.Barbers.FirstOrDefault(b => b.BarberId == Id);
            if (barber == null)
            {
                throw new ArgumentException("Barber not found");
            }
            barber.BranchId = Barber.BranchId;
            barber.BarberName = Barber.BarberName;
            barber.Phone = Barber.Phone;
            _dbcontext.SaveChanges();
            return new BarberDTO
            {
                BranchId = barber.BranchId,
                BarberName = barber.BarberName,
                Phone = barber.Phone
            };
        }
    }
}

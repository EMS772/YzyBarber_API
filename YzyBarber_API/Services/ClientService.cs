using YzyBarber_API.Data;
using YzyBarber_API.DTO_s.ClientDTO_s;
using YzyBarber_API.Entities;
using YzyBarber_API.Interfaces;

namespace YzyBarber_API.Services
{
    public class ClientService : IClientService
    {
        private readonly BarberDbContext _dbcontext;
        public ClientService(BarberDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public ClientDTO CreateClient(CreateClientDTO client)
        {
            var exists = _dbcontext.Clients.Any(c =>
            c.Email == client.Email ||
            c.Phone == client.Phone);

            if (exists)
            {
                throw new ArgumentException("There is already a customer with the same email or phone number.");
            }

            var Client = new Client
            {
                Name = client.Name,
                Password = BCrypt.Net.BCrypt.HashPassword(client.Password),
                Email = client.Email,
                Phone = client.Phone
            };

            _dbcontext.Clients.Add(Client);
            _dbcontext.SaveChanges();

            return new ClientDTO
            {
                ClientId = Client.ClientId,
                Name = Client.Name,
                Email = Client.Email,
                Phone = Client.Phone
            };
        }

        public void DeleteClient(int ClienteId)
        {
            var client = _dbcontext.Clients.FirstOrDefault(c => c.ClientId == ClienteId);
            if (client == null)
            {
                throw new ArgumentException("Client not found");
            }
            _dbcontext.Remove(client);
            _dbcontext.SaveChanges();
        }

        public List<ClientDTO> GetClients()
        {
            return _dbcontext.Clients.Select(c => new ClientDTO
            {
                ClientId = c.ClientId,
                Name = c.Name,
                Email = c.Email,
                Phone = c.Phone
            }).ToList();
        }

        public ClientDTO UpdateClient(int Id, CreateClientDTO Cliente)
        {
            var client = _dbcontext.Clients.FirstOrDefault(c => c.ClientId == Id);
            if (client == null)
            {
                throw new ArgumentException("Client not found");
            }
            client.Name = Cliente.Name;
            client.Password = BCrypt.Net.BCrypt.HashPassword(Cliente.Password);
            client.Email = Cliente.Email;
            client.Phone = Cliente.Phone;

            _dbcontext.Update(client);
            _dbcontext.SaveChanges();

            return new ClientDTO
            {
                Name = client.Name,
                Email = client.Email,
                Phone = client.Phone
            };
        }
    }
}

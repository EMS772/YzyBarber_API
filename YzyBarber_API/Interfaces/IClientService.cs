using YzyBarber_API.DTO_s.ClientDTO_s;

namespace YzyBarber_API.Interfaces
{
    public interface IClientService
    {
        public List<ClientDTO> GetClients();
        public ClientDTO CreateClient(CreateClientDTO Client );
        public ClientDTO UpdateClient(int Id,CreateClientDTO Cliente);
        public void DeleteClient(int ClienteId);
    }
}

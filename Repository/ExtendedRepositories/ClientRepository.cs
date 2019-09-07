using Models;
using System.Linq;
using Models.DataModels;

namespace Repository.ExtendedRepositories
{
    public interface IClientRepository : IRepository<Client>
    {
        Client GetByPhonenumber(string Phonenumber);
        IQueryable<Client> GetByPhonenumbers(params string[] Phonenumbers);
    }
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(ApplicationDbContext context) : base(context) { }
        public Client GetByPhonenumber(string Phonenumber)
        {
            return (from client in context.Clients
                    where client.Phonenumber == Phonenumber && !client.IsDeleted
                    select client).SingleOrDefault();
        }
        public IQueryable<Client> GetByPhonenumbers(params string[] Phonenumbers)
        {
            return from client in context.Clients
                   where Phonenumbers.Contains(client.Phonenumber) && !client.IsDeleted
                   select client;
        }
    }
}

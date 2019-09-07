using Models.DataModels;
using System.Collections.Generic;

namespace BusinessLogic.Interfaces
{
    public interface IClientManager
    {
        IEnumerable<string> GetCloseMatches(string Phonenumber, int sensitivity);
        Client GetClient(string Phonenumber);
    }
}

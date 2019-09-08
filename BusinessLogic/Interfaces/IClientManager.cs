using Models.DataModels;
using Services.DTOs;
using System.Collections.Generic;

namespace BusinessLogic.Interfaces
{
    public enum RegisterResult { Ok, UsernameExists, PhonenumberExists }
    public interface IClientManager
    {
        IEnumerable<string> GetCloseMatches(string Phonenumber, int sensitivity);
        Client GetClient(string Phonenumber);
        RegisterResult RegisterClient(UserRegisterRequest user);
    }
}

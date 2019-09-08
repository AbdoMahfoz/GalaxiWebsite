using BusinessLogic.Interfaces;
using Repository.ExtendedRepositories;
using System.Linq;
using System;
using System.Collections.Generic;
using Models.DataModels;
using Services.DTOs;
using Services;

namespace BusinessLogic.Implementations
{
    public class ClientManager : IClientManager
    {
        private readonly IClientRepository Clients;
        private readonly IAuth Auth;
        public ClientManager(IClientRepository Clients, IAuth Auth)
        {
            this.Clients = Clients;
            this.Auth = Auth;
        }
        public Client GetClient(string Phonenumber)
        {
            return Clients.GetByPhonenumber(Phonenumber);
        }
        public IEnumerable<string> GetCloseMatches(string Phonenumber, int sensitivity)
        {
            IQueryable<string> Numbers = from client in Clients.GetAll() select client.Phonenumber;
            int[,] dp = new int[100, 100];
            List<KeyValuePair<int, string>> Results = new List<KeyValuePair<int, string>>();
            foreach(string Suspect in Numbers)
            {
                for (int i = Suspect.Length; i >= 0; i--)
                {
                    for (int j = Phonenumber.Length; j >= 0; j--)
                    {
                        if (j == Phonenumber.Length) dp[i, j] = Suspect.Length - i;
                        else if (i == Suspect.Length) dp[i, j] = Phonenumber.Length - j;
                        else
                        {
                            if (Suspect[i] == Phonenumber[j]) dp[i, j] = dp[i + 1, j + 1];
                            else dp[i, j] = Math.Min(dp[i + 1, j + 1], Math.Min(dp[i + 1, j], dp[i, j + 1])) + 1;
                        }
                    }
                }
                Results.Add(new KeyValuePair<int, string>(dp[0, 0], Suspect));
            }
            return from result in Results
                   where result.Key <= sensitivity
                   orderby result.Key ascending
                   select result.Value;
        }
        public RegisterResult RegisterClient(UserRegisterRequest user)
        {
            if(Clients.PhonenumberExists(user.Phonenumber))
            {
                return RegisterResult.PhonenumberExists;
            }
            Client client = Helpers.MapTo<Client>(user);
            client.UserId = Auth.Register(new UserAuthenticationRequest
                            {
                                Username = user.Username,
                                Password = user.Password
                            },
                            UserRole.User);
            if(client.UserId == -1)
            {
                return RegisterResult.UsernameExists;
            }
            Clients.Insert(client).Wait();
            return RegisterResult.Ok;
        }
    }
}

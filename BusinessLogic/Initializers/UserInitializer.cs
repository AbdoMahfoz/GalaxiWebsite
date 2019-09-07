using BusinessLogic.Interfaces;
using Models.DataModels;
using Repository.ExtendedRepositories;
using Services.DTOs;

namespace BusinessLogic.Initializers
{
    public class UserInitializer : BaseInitializer
    {
        private readonly IAuth auth;
        private readonly IUserRepository Users;
        public UserInitializer(IAuth auth, IUserRepository Users)
        {
            this.auth = auth;
            this.Users = Users;
        }
        public override void Initialize()
        {
            if(!Users.AdminExists())
            {
                auth.Register(new UserAuthenticationRequest
                {
                    Username = "Admin",
                    Password = "AdminAdmin"
                },
                UserRole.Admin);
            }
        }
    }
}

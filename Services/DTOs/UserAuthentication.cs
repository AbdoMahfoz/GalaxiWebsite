namespace Services.DTOs
{
    public class UserAuthenticationRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class UserAuthenticationResult
    {
        public int UserId { get; set; }
        public string Token { get; set; }
        public int ExpiresIn { get; set; }
        public UserAuthenticationResult() { }
        public UserAuthenticationResult(int UserId, string Token, int ExpiresIn)
        {
            this.UserId = UserId;
            this.Token = Token;
            this.ExpiresIn = ExpiresIn;
        }
    }
    public class UserRegisterRequest : UserAuthenticationRequest
    {
        public string Phonenumber { get; set; }
        public string Name { get; set; }
        public int FacultyId { get; set; }
        public string Email { get; set; }
        public int Year { get; set; }
    }
}

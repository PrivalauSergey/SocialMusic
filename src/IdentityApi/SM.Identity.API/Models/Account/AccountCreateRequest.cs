namespace SM.Identity.API.Models.Account
{
    public class AccountCreateRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
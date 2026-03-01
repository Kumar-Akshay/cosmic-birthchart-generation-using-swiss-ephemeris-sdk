namespace CosmicGame.Shared.Models.Request
{
    public class LoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string deviceinfo { get; set; }
        public bool IsRemember { get; set; }
    }
}

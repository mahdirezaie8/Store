namespace Store.Domain.Core.Dtos.UserDtos
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public decimal Wallet { get; set; }
    }
}

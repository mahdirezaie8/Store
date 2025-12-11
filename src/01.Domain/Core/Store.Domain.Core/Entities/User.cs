using System.ComponentModel.DataAnnotations;

namespace Store.Domain.Core.Entities
{
    public class User:BaseClass
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public decimal Wallet {  get; set; }
        public List<Order> orders { get; set; } = [];
    }
}

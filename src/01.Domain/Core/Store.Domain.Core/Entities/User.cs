using Microsoft.AspNetCore.Identity;
using Store.Domain.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Store.Domain.Core.Entities
{
    public class User:BaseClass
    {
        public string FullName { get; set; }
        public decimal Wallet {  get; set; }
        public bool IsActive { get; set; } = true;
        public IdentityUser<int> IdentityUser { get; set; }
        public int IdentityUserId { get; set; }
        public List<Order> orders { get; set; } = [];
    }
}

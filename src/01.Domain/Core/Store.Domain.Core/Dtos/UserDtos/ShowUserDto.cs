using Store.Domain.Core.Enums;

namespace Store.Domain.Core.Dtos.UserDtos
{
    public class ShowUserDto
    {
        public int Id { get; set; } 
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public bool IsActive { get; set; }
        public RoleEnum Role { get; set; }
    }
}

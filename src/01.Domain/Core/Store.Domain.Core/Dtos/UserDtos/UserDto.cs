using Store.Domain.Core.Enums;

namespace Store.Domain.Core.Dtos.UserDtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public RoleEnum Role { get; set; }
        public bool IsActive { get; set; }
    }
}

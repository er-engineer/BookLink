using Core.Entities.Abstract;

namespace Core.Entities.DTOs
{
    public class UserToRegisterDto : IDto
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

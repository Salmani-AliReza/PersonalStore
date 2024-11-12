namespace Personal_Store.Application.Services.Users.Commands.UpdateUser
{
    public class RequestUpdateUserDTO
    {
        public long ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }

        public List<RolesInUpdateUserDTO> Roles { get; set; }
    }
}

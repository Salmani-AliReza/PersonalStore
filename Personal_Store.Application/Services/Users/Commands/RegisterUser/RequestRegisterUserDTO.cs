namespace Personal_Store.Application.Services.Users.Commands.RegisterUser
{
    public class RequestRegisterUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public List<RolesInRegisterUserDTO> Roles { get; set; }
    }

}

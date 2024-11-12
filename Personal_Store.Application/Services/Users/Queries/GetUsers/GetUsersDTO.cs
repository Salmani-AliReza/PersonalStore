namespace Personal_Store.Application.Services.Users.Queries.GetUsers
{
    public class GetUsersDTO
    {
        public long ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public long[] Roles { get; set; }
    }

}

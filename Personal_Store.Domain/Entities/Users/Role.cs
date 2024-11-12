namespace Personal_Store.Domain.Entities.Users
{
    public class Role
    {
        public long ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserInRole> UserInRoles { get; set; }
    }
}

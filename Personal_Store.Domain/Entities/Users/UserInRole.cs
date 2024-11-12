namespace Personal_Store.Domain.Entities.Users
{
    public class UserInRole
    {
        public long ID { get; set; }

        public virtual User User { get; set; }
        public long UserID { get; set; }

        public virtual Role Role { get; set; }
        public long RoleID { get; set; }
    }
}

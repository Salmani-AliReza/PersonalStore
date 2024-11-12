using Personal_Store.Application.Interfaces.Contexts;
using Personal_Store.Common.DataTransferObjects;

namespace Personal_Store.Application.Services.Users.Commands.UserStatusChange
{
    public class UserStatusChangeService : IUserStatusChangeService
    {

        private readonly IDataBaseContext _context;

        public UserStatusChangeService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDTO Execute(long UserID)
        {
            var user = _context.Users.Find(UserID);
            if (user == null)
            {
                return new ResultDTO()
                {
                    IsSuccess = false,
                    Message = "کاربر مورد نظر برای تغییر وضعیت پیدا نشد"
                };
            }
            user.IsActive = !user.IsActive;
            _context.SaveChanges();
            string strStatus = user.IsActive == true ? "فعال" : "غیر فعال";
            return new ResultDTO()
            {
                IsSuccess = true,
                Message = $"کاربر با موفقیت {strStatus} شد!"
            };
        }
    }
}

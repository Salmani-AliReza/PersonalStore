using Personal_Store.Application.Interfaces.Contexts;
using Personal_Store.Common.DataTransferObjects;

namespace Personal_Store.Application.Services.Users.Commands.RemoveUser
{
    public class RemoveUserService : IRemoveUserService
    {
        private readonly IDataBaseContext _context;

        public RemoveUserService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDTO Execute(long userID)
        {
            var user = _context.Users.Find(userID);
            if (user == null)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "کاربر مورد نظر یافت نشد"
                };
            }
            user.RemoveTime = DateTime.Now;
            user.IsRemoved = true;
            _context.SaveChanges();
            return new ResultDTO
            {
                IsSuccess = true,
                Message = "کاربر مورد نظر با موفقیت حذف شد"
            };
        }
    }
}

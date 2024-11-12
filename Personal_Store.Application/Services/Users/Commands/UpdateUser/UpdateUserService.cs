using Personal_Store.Application.Interfaces.Contexts;
using Personal_Store.Common.DataTransferObjects;
using Personal_Store.Domain.Entities.Users;


namespace Personal_Store.Application.Services.Users.Commands.UpdateUser
{
    public class UpdateUserService : IUpdateUserService
    {
        private readonly IDataBaseContext _context;

        public UpdateUserService(IDataBaseContext context)
        {
            _context = context;
        }

        ResultDTO IUpdateUserService.Execute(RequestUpdateUserDTO request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.Email))
                {
                    return new ResultDTO()
                    {
                        IsSuccess = false,
                        Message = "ایمیل نمی تواند خالی باشد"
                    };
                }
                if (string.IsNullOrWhiteSpace(request.FirstName))
                {
                    return new ResultDTO()
                    {
                        IsSuccess = false,
                        Message = "نام نمی تواند خالی باشد"
                    };
                }
                if (string.IsNullOrWhiteSpace(request.LastName))
                {
                    return new ResultDTO()
                    {
                        IsSuccess = false,
                        Message = "نام خانوادگی نمی تواند خالی باشد"
                    };
                }
                bool PasswordMustUpdate = true;
                if (string.IsNullOrWhiteSpace(request.Password) && string.IsNullOrWhiteSpace(request.RePassword))
                {
                    PasswordMustUpdate = false;
                }
                if (PasswordMustUpdate)
                {
                    if (string.IsNullOrWhiteSpace(request.Password))
                    {
                        return new ResultDTO()
                        {
                            IsSuccess = false,
                            Message = "گذرواژه نمی تواند خالی باشد"
                        };
                    }
                    if (string.IsNullOrWhiteSpace(request.RePassword))
                    {
                        return new ResultDTO()
                        {
                            IsSuccess = false,
                            Message = "تکرار گذرواژه نمی تواند خالی باشد"
                        };
                    }
                    if (request.Password != request.RePassword)
                    {
                        return new ResultDTO()
                        {
                            IsSuccess = false,
                            Message = "گذرواژه و تکرار گذرواژه با هم برابر نیستند"
                        };
                    };
                }
                var user = _context.Users.Find(request.ID);
                if (user == null)
                {
                    return new ResultDTO
                    {
                        IsSuccess = false,
                        Message = "کاربر مورد نظر یافت نشد"
                    };
                }
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.Email = request.Email;
                user.Phone = request.Phone;
                List<UserInRole> UserInRoles = new List<UserInRole>();
                foreach (var item in request.Roles)
                {
                    var role = _context.Roles.Find(item.ID);
                    UserInRoles.Add(new UserInRole
                    {
                        Role = role,
                        RoleID = role.ID,
                        User = user,
                        UserID = user.ID
                    });
                }
                user.UserInRoles = UserInRoles;
                if (PasswordMustUpdate)
                {
                    user.Password = request.Password;
                }
                _context.SaveChanges();

                return new ResultDTO
                {
                    IsSuccess = true,
                    Message = "کاربر مورد نظر با موفقیت ویرایش شد"
                };
            }
            catch (Exception)
            {
                return new ResultDTO()
                {
                    IsSuccess = false,
                    Message = "ثبت نام با موفقیت انجام نشد"
                };
            }
        }
    }
}

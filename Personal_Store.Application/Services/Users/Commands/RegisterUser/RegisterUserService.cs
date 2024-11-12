using Personal_Store.Application.Interfaces.Contexts;
using Personal_Store.Common.DataTransferObjects;
using Personal_Store.Domain.Entities.Users;

namespace Personal_Store.Application.Services.Users.Commands.RegisterUser
{
    public class RegisterUserService : IRegisterUserService
    {
        private readonly IDataBaseContext _context;

        public RegisterUserService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDTO<ResultRegisterUserDTO> Execute(RequestRegisterUserDTO request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.Email))
                {
                    return new ResultDTO<ResultRegisterUserDTO>()
                    {
                        Data = new ResultRegisterUserDTO()
                        {
                            UserID = 0
                        },
                        IsSuccess = false,
                        Message = "ایمیل نمی تواند خالی باشد"
                    };
                }
                if (string.IsNullOrWhiteSpace(request.FirstName))
                {
                    return new ResultDTO<ResultRegisterUserDTO>()
                    {
                        Data = new ResultRegisterUserDTO()
                        {
                            UserID = 0
                        },
                        IsSuccess = false,
                        Message = "نام نمی تواند خالی باشد"
                    };
                }
                if (string.IsNullOrWhiteSpace(request.LastName))
                {
                    return new ResultDTO<ResultRegisterUserDTO>()
                    {
                        Data = new ResultRegisterUserDTO()
                        {
                            UserID = 0
                        },
                        IsSuccess = false,
                        Message = "نام خانوادگی نمی تواند خالی باشد"
                    };
                }
                if (string.IsNullOrWhiteSpace(request.Password))
                {
                    return new ResultDTO<ResultRegisterUserDTO>()
                    {
                        Data = new ResultRegisterUserDTO()
                        {
                            UserID = 0
                        },
                        IsSuccess = false,
                        Message = "گذرواژه نمی تواند خالی باشد"
                    };
                }
                if (string.IsNullOrWhiteSpace(request.RePassword))
                {
                    return new ResultDTO<ResultRegisterUserDTO>()
                    {
                        Data = new ResultRegisterUserDTO()
                        {
                            UserID = 0
                        },
                        IsSuccess = false,
                        Message = "تکرار گذرواژه نمی تواند خالی باشد"
                    };
                }
                if (request.Password != request.RePassword)
                {
                    return new ResultDTO<ResultRegisterUserDTO>
                    {
                        Data = new ResultRegisterUserDTO()
                        {
                            UserID = 0
                        },
                        IsSuccess = false,
                        Message = "گذرواژه و تکرار گذرواژه با هم برابر نیستند"
                    };
                };

                User user = new User()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Phone = request.Phone,
                    Password = request.Password
                };
                List<UserInRole> userInRoles = new List<UserInRole>();
                foreach (var item in request.Roles)
                {
                    var role = _context.Roles.Find(item.ID);
                    userInRoles.Add(new UserInRole
                    {
                        Role = role,
                        RoleID = role.ID,
                        User = user,
                        UserID = user.ID
                    });
                }
                user.UserInRoles = userInRoles;

                _context.Users.Add(user);
                _context.SaveChanges();

                return new ResultDTO<ResultRegisterUserDTO>()
                {
                    IsSuccess = true,
                    Message = "ایجاد کاربر با موفقیت انجام شد",
                    Data = new ResultRegisterUserDTO()
                    {
                        UserID = user.ID,
                    }
                };
            }
            catch (Exception)
            {
                return new ResultDTO<ResultRegisterUserDTO>()
                {
                    Data = new ResultRegisterUserDTO()
                    {
                        UserID = 0
                    },
                    IsSuccess = false,
                    Message = "ثبت نام با موفقیت انجام نشد"
                };
            }
        }
    }

}

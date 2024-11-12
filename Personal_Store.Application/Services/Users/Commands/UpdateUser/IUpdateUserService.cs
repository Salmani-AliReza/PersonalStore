using Personal_Store.Application.Services.Users.Commands.RegisterUser;
using Personal_Store.Common.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Personal_Store.Application.Services.Users.Commands.UpdateUser
{
    public interface IUpdateUserService
    {
        ResultDTO Execute(RequestUpdateUserDTO request);
    }
}

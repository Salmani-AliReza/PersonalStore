using Personal_Store.Common.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Store.Application.Services.Users.Commands.RegisterUser
{
    public interface IRegisterUserService
    {
        ResultDTO<ResultRegisterUserDTO> Execute(RequestRegisterUserDTO request);
    }
}

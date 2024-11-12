using Personal_Store.Application.Interfaces.Contexts;
using Personal_Store.Common.DataTransferObjects;

namespace Personal_Store.Application.Services.Users.Queries.GetRoles
{
    public class GetRolesService : IGetRolesService
    {
        private readonly IDataBaseContext _context;

        public GetRolesService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDTO<List<RolesDTO>> Execute()
        {
            var roles = _context.Roles.Select(p => new RolesDTO
            {
                ID = p.ID,
                Name = p.Name
            }).ToList();
            return new ResultDTO<List<RolesDTO>>()
            {
                IsSuccess = true,
                Message = "",
                Data = roles
            };
        }
    }
}

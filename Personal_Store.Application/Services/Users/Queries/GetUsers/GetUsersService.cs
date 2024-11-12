using Personal_Store.Application.Interfaces.Contexts;
using Personal_Store.Common;
using Personal_Store.Domain.Entities.Users;

namespace Personal_Store.Application.Services.Users.Queries.GetUsers
{
    public class GetUsersService : IGetUsersService
    {
        private readonly IDataBaseContext _context;
        public GetUsersService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultGetUserDTO Execute(RequestGetUsersDTO request)
        {
            var query = _context.Users.AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.SearchKey))
            {
                query = query.Where(
                    p => p.FirstName.Contains(request.SearchKey) &&
                    p.LastName.Contains(request.SearchKey) &&
                    p.Email.Contains(request.SearchKey)
                );
            }
            int rowsCount = 0;
            var usersList = query.ToPaged(request.Page, 20, out rowsCount).Select(p => new GetUsersDTO
            {
                ID = p.ID,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Email = p.Email,
                Phone = p.Phone,
                IsActive = p.IsActive
            }).ToList();

            foreach (var user in usersList)
            {
                var roles = _context.UserInRoles.Where(x => x.UserID == user.ID).Select(r => r.RoleID).ToArray();
                user.Roles = roles;
            }

            return new ResultGetUserDTO
            {
                Rows = rowsCount,
                Users = usersList
            };
        }
    }

}

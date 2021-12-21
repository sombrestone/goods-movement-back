using System.Linq;
using goods_movement_back.Model;

namespace goods_movement_back.QueryService
{
    public class UserQueryService
    {
        private readonly AppContext _context;

        public UserQueryService(AppContext context)
        {
            _context = context;
        }

        public Worker Find(string login) =>
            (from worker in _context.Workers
                join role in _context.Roles on worker.RoleId equals role.Id
                where (worker.Login == login)
                select new Worker
                {
                    Id =worker.Id,
                    Login=worker.Login,
                    Password = worker.Password,
                    Firstname = worker.Firstname,
                    Lastname = worker.Lastname,
                    Patronymic = worker.Patronymic,
                    DepartmentId = worker.DepartmentId,
                    RoleId = role.Id,
                    Role = role
                }).FirstOrDefault();

        public bool IsExists(string login) =>
            _context.Workers.Any(x => x.Login == login);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using goods_movement_back.Model;
using goods_movement_back.ModelView.Worker;
using goods_movement_back.QueryService;
using AppContext = goods_movement_back.Model.AppContext;

namespace goods_movement_back.Service
{
    public class UserService
    {
        private readonly AppContext _context;
        private readonly UserQueryService _queryService;
        
        public UserService(AppContext context,UserQueryService queryService)
        {
            _context = context;
            _queryService = queryService;
        }

        public Worker Find(string login) => _queryService.Find(login);

        public bool NewUser(WorkerRegistrationModel user)
        {
            if (_queryService.IsExists(user.Login)) return false;
            _context.Workers.Add(new Worker
            {
                Id = Guid.NewGuid(),
                Login = user.Login,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Patronymic = user.Patronymic,
                DepartmentId = user.DepartmentId,
                RoleId = _context.Roles.FirstOrDefault().Id,
                Password = HashPassword(user.Password)
            });
            _context.SaveChanges();
            return true;
        }

        public static string HashPassword(string password)
        {
            return password;
        }

        public bool CheckPassword(Worker user, string password) =>
            HashPassword(password) == Find(user.Login).Password;
        
        public ClaimsIdentity GetIdentity(Worker user)
        {
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Login),
                    new Claim(ClaimTypes.Role, user.Role.Name),
                    new Claim(type: "firstname",value: user.Firstname),
                    new Claim(type: "lastname",value: user.Lastname),
                    new Claim(type: "patronymic",value: user.Patronymic),
                    new Claim(type: "role",value: user.Role.Name),
                    new Claim(type: "name",value: user.Login),
                    new Claim(type: "departmentId",value: user.DepartmentId.ToString())
                };
                ClaimsIdentity claimsIdentity =
                    new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                        ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }
            return null;
        }

       
    }
}
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using goods_movement_back.Model;
using goods_movement_back.ModelView.Unit;
using goods_movement_back.ModelView.Worker;
using goods_movement_back.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using AppContext = goods_movement_back.Model.AppContext;

namespace goods_movement_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly UserService _service;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly AppContext _context;

        public UserController(UserService service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }
        
        [HttpPost]
        [Route("token")]
        public object Token([FromBody] WorkerLoginModel model)
        {
            Worker user =  _service.Find(model.Login);
            if (user == null) return NotFound("Пользователь не найден.");
            if (!(_service.CheckPassword(user,model.Password)))
                throw new Exception("Неверный пароль.");
            return new {token= GetToken(user)};
        }

        [Authorize]
        [HttpPost("token-valid")]
        public async Task<IActionResult> TokenValid()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]);
            string token = Request.Headers["Authorization"];
            if (token.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                token = token["Bearer ".Length..].Trim();

            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero,
                ValidateLifetime = true,
                RequireExpirationTime = true
            }, out var validatedToken);

            Worker user =  _service.Find(User.Claims.FirstOrDefault(x => 
                x.Type.Equals("name", StringComparison.OrdinalIgnoreCase))?.Value);
            if (user == null) return NotFound("Пользователь не найден.");
            return Ok(new {token= GetToken(user)});
        }
        
        private string GetToken(Worker user)
        {
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(1),
                claims: _service.GetIdentity(user).Claims,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]))
                    , SecurityAlgorithms.HmacSha256)
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        
        
        //[Authorize(Roles = "admin")]
        [HttpPost]
        [Route("registration")]
        public async Task<IActionResult> Registration([FromBody] WorkerRegistrationModel user)
        {
            if (_service.NewUser(user)) return Ok("Пользователь успешно зарегистрирован");
            else return Conflict("Пользователь существует.");
        }
        
        //[Authorize(Roles = "admin")]
        [HttpGet]
        public  IEnumerable<WorkerModel> Get()
        {
            return _mapper.Map<List<WorkerModel>>(_context.Workers.ToList());
        }
        
        //[Authorize(Roles = "admin")]
        [HttpGet("{id:guid}")]
        public void Delete([FromRoute] Guid id)
        {
            var user = _context.Workers.Where(x => x.Id == id).FirstOrDefault();
            _context.Workers.Remove(user);
            _context.SaveChanges();
        }

    }
}
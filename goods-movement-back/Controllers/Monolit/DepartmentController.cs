using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using goods_movement_back.Model;
using goods_movement_back.ModelView.Department;
using goods_movement_back.ModelView.Shop;
using goods_movement_back.ModelView.Unit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppContext = goods_movement_back.Model.AppContext;

namespace goods_movement_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly AppContext _context;
        private readonly IMapper _mapper;

        public DepartmentController(AppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DepartmentModel>), 200)]
        public IEnumerable<DepartmentModel> Get() =>
            (from department in _context.Departments
                join shop in _context.Shops on department.ShopId equals shop.Id
                select new DepartmentModel
                {
                    Id = department.Id,
                    Name = department.Name,
                    ShopId = shop.Id,
                    ShopName = shop.Name
                }).ToList();
        

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(DepartmentModel), 200)]
        public DepartmentModel Get([FromRoute] Guid id) =>
            Get().Where(x => x.Id == id).FirstOrDefault();
        
        
        [HttpGet("get-by-shop/{id:guid}")]
        [ProducesResponseType(typeof(DepartmentModel), 200)]
        public IEnumerable<DepartmentModel> GetByShop([FromRoute] Guid id) =>
            Get().Where(x => x.ShopId == id);


        [HttpPost]
        public Guid Post([FromBody] DepartmentSaveModel departmentSave)
        {
            var department = _mapper.Map<Department>(departmentSave);
            department.Id = Guid.NewGuid();
            _context.Departments.Add(department);
            _context.SaveChanges();
            return department.Id;
        }

        [HttpPut]
        public void Put([FromBody] DepartmentUpdateModel department)
        {
            _context.Departments.Update(_mapper.Map<Department>(department));
            _context.SaveChanges();
        }


        [HttpDelete("{id:guid}")]
        public void Delete(Guid id)
        {
            _context.Departments.Remove(_context.Departments.Find(id));
            _context.SaveChanges();
        }
        
    }
}
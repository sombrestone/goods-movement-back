using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using goods_movement_back.Model;
using goods_movement_back.ModelView.Unit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppContext = goods_movement_back.Model.AppContext;

namespace goods_movement_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {

        private readonly AppContext _context;
        private readonly IMapper _mapper;

        public UnitController(AppContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UnitUpdateModel>), 200)]
        public IEnumerable<UnitUpdateModel> Get()=>
            _mapper.Map<List<UnitUpdateModel>>(_context.Units.ToList());
        

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(UnitUpdateModel), 200)]
        public UnitUpdateModel Get([FromRoute] Guid id)=>
            _mapper.Map<UnitUpdateModel>(_context.Units.Where(x => x.Id == id).FirstOrDefault());
        

        
        [HttpPost]
        public Guid Post([FromBody] UnitSaveModel unitSave)
        {
            var unit = _mapper.Map<Unit>(unitSave);
            unit.Id = Guid.NewGuid();
            _context.Units.Add(unit);
            _context.SaveChangesAsync();
            return unit.Id;
        }

        [HttpPut]
        public void Put([FromBody] UnitUpdateModel unit)
        {
            _context.Units.Update(_mapper.Map<Unit>(unit));
            _context.SaveChangesAsync();
        }

        
        [HttpDelete("{id:guid}")]
        public void Delete(Guid id)
        {
            _context.Units.Remove(_context.Units.Find(id));
            _context.SaveChangesAsync();
        }
    }
}

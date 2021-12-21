using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using goods_movement_back.Model;
using goods_movement_back.ModelView.Supplier;
using goods_movement_back.ModelView.VAT;
using Microsoft.AspNetCore.Mvc;
using AppContext = goods_movement_back.Model.AppContext;

namespace goods_movement_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VatController : ControllerBase
    {
        private readonly AppContext _context;
        private readonly IMapper _mapper;
        
        public VatController(AppContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
                
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<VAT>), 200)]
        public IEnumerable<VAT> Get()=>
            _context.Vats.ToList();
                
        
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(VAT), 200)]
        public VAT Get([FromRoute] Guid id)=>
            _context.Vats.Where(x => x.Id == id).FirstOrDefault();
                
        
        [HttpPost]
        public Guid Post([FromBody] VatSaveModel vatSave)
        {
            var vat = _mapper.Map<VAT>(vatSave);
            vat.Id = Guid.NewGuid();
            _context.Vats.Add(vat);
            _context.SaveChanges();
            return vat.Id;
        }
        
        [HttpPut]
        public void Put([FromBody] VatUpdateModel vat)
        {
            _context.Vats.Update(_mapper.Map<VAT>(vat));
            _context.SaveChanges();
        }
        
                
        [HttpDelete("{id:guid}")]
        public void Delete(Guid id)
        {
            _context.Vats.Remove(_context.Vats.Find(id));
            _context.SaveChanges();
        }
    }
}
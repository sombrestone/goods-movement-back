using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using goods_movement_back.Model;
using goods_movement_back.ModelView.Supplier;
using Microsoft.AspNetCore.Mvc;
using AppContext = goods_movement_back.Model.AppContext;

namespace goods_movement_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController: ControllerBase
    {
        private readonly AppContext _context;
        private readonly IMapper _mapper;
        
        public SupplierController(AppContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
                
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SupplierModel>), 200)]
        public IEnumerable<SupplierModel> Get()=>
            _mapper.Map<List<SupplierModel>>(_context.Suppliers.ToList());
                
        
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(SupplierModel), 200)]
        public SupplierModel Get([FromRoute] Guid id)=>
            _mapper.Map<SupplierModel>(_context.Suppliers.Where(x => x.Id == id).FirstOrDefault());
                
        
        [HttpPost]
        public Guid Post([FromBody] SupplierSaveModel supplierSave)
        {
            var supplier = _mapper.Map<Supplier>(supplierSave);
            supplier.Id = Guid.NewGuid();
            _context.Suppliers.Add(supplier);
            _context.SaveChangesAsync();
            return supplier.Id;
        }
        
        [HttpPut]
        public void Put([FromBody] SupplierUpdateModel supplier)
        {
            _context.Suppliers.Update(_mapper.Map<Supplier>(supplier));
            _context.SaveChangesAsync();
        }
        
                
        [HttpDelete("{id:guid}")]
        public void Delete(Guid id)
        {
            _context.Suppliers.Remove(_context.Suppliers.Find(id));
            _context.SaveChangesAsync();
        }
    }
}
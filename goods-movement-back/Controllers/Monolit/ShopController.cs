using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using goods_movement_back.Model;
using goods_movement_back.ModelView.Shop;
using goods_movement_back.ModelView.Unit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppContext = goods_movement_back.Model.AppContext;

namespace goods_movement_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly AppContext _context;
        private readonly IMapper _mapper;
        
        public ShopController(AppContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
                
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ShopModel>), 200)]
        public IEnumerable<ShopModel> Get()=>
            _mapper.Map<List<ShopModel>>(_context.Shops.ToList());
                
        
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(ShopModel), 200)]
        public ShopModel Get([FromRoute] Guid id)=>
            _mapper.Map<ShopModel>(_context.Shops.Where(x => x.Id == id).FirstOrDefault());
                
        
        [HttpPost]
        public Guid Post([FromBody] ShopSaveModel shopSave)
        {
            var shop = _mapper.Map<Shop>(shopSave);
            shop.Id = Guid.NewGuid();
            _context.Shops.Add(shop);
            _context.SaveChanges();
            return shop.Id;
        }
        
        [HttpPut]
        public void Put([FromBody] ShopUpdateModel shop)
        {
            _context.Shops.Update(_mapper.Map<Shop>(shop));
            _context.SaveChanges();
        }
        
                
        [HttpDelete("{id:guid}")]
        public void Delete(Guid id)
        {
            _context.Shops.Remove(_context.Shops.Find(id));
            _context.SaveChanges();
        }
        
    }
}


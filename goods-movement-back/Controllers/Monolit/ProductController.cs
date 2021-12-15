using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using goods_movement_back.Model;
using goods_movement_back.ModelView;
using goods_movement_back.ModelView.Unit;
using Microsoft.AspNetCore.Mvc;
using AppContext = goods_movement_back.Model.AppContext;

namespace goods_movement_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        
        private readonly AppContext _context;
        private readonly IMapper _mapper;

        public ProductController(AppContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductModel>), 200)]
        public IEnumerable<ProductModel> Get()=>
                (from product in _context.Products
                join unit in _context.Units on product.UnitId equals unit.Id
                select new ProductModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    UnitName = unit.Name,
                    UnitId = unit.Id,
                    UnitShortName = unit.ShortName
                }).ToList();

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(ProductModel), 200)]
        public ProductModel Get([FromRoute] Guid id)=>
            Get().Where(x => x.Id == id).FirstOrDefault();


        [HttpPost]
        public Guid Post([FromBody] ProductSaveModel productSave)
        {
            var product = _mapper.Map<Product>(productSave);
            product.Id = Guid.NewGuid();
            _context.Products.Add(product);
            _context.SaveChangesAsync();
            return product.Id;
        }

        [HttpPut]
        public void Put([FromBody] ProductUpdateModel product)
        {
            _context.Products.Update(_mapper.Map<Product>(product));
            _context.SaveChangesAsync();
        }

        
        [HttpDelete("{id:guid}")]
        public void Delete(Guid id)
        {
            _context.Products.Remove(_context.Products.Find(id));
            _context.SaveChangesAsync();
        }
    }
}
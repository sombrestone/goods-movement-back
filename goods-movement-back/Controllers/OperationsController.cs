using System;
using goods_movement_back.Enum;
using goods_movement_back.ModelView.Operations.Arrival;
using goods_movement_back.Service;
using Microsoft.AspNetCore.Mvc;

namespace goods_movement_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationsController: ControllerBase
    {
        private readonly OperationsService _service;

        public OperationsController(OperationsService service)
        {
            _service = service;
        }
        
        [HttpPost]
        [Route("arrival")]
        public IActionResult Arrival([FromBody] ArrivalSaveModel model)
        {
            try
            {
                return Ok(_service.Arrival(model));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        
        [HttpPost]
        [Route("sale")]
        public IActionResult Sale([FromBody] SaleSaveModel model)
        {
            try
            {
                return Ok(_service.Sale(model));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        
        [HttpPost]
        [Route("return")]
        public IActionResult Return([FromBody] SaleSaveModel model)
        {
            try
            {
                return Ok(_service.Sale(model,DocType.Return));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        
        [HttpPost]
        [Route("move")]
        public IActionResult Move([FromBody] MoveSaveModel model)
        {
            try
            {
                return Ok(_service.Move(model));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        
        

        [HttpGet("smart-balance/{depId:guid}")]
        public IActionResult SmartBalance([FromRoute] Guid depId)
        {
            try
            {
                return Ok(_service.GetBalance(depId));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
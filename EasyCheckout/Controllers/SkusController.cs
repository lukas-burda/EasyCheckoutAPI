using EasyCheckout.Data.Services;
using EasyCheckout.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyCheckout.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkusController : Controller
    {
        private readonly SkuService _skuService;

        public SkusController(SkuService skuService)
        {
            _skuService = skuService;
        }

        [HttpGet]
        public ActionResult<List<Sku>> Get() => _skuService.Get();

        [HttpGet("{id}")]
        public ActionResult<Sku> Get(Guid id)
        {
            var sku = _skuService.Get(id);
            if (sku == null)
            {
                return NotFound();
            }
            return sku;
        }

        [HttpPost]
        public ActionResult<Sku> Create([FromBody]Sku sku)
        {
            sku.HasSubProperties = sku.HasSubProperty(sku.SubProperties);
            if (sku.HasSubProperties)
            {
                sku.SubProperties = sku.IdentifyProperties(sku.SubProperties);
            }

            _skuService.Create(sku);

            return CreatedAtRoute("", new { id = sku.Id }, sku);
        }

        [HttpPut("{id}")]
        public ActionResult<Sku> Update([FromRoute]Guid id, [FromBody]Sku skuIn)
        {
            var sku = _skuService.Get(id);
            if(sku == null)
            {
                return NotFound();
            }
            skuIn.Id = sku.Id;
            _skuService.Update(id, skuIn);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var sku = _skuService.Get(id);
            if (sku == null)
            {
                return NotFound();
            }
            _skuService.Remove(sku.Id);

            return NoContent();
        }
    }
}

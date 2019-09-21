using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Abstractions.BLL;
using Ecommerce.Models;
using Ecommerce.Models.APIViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebApp.Controllers.API
{
    [ApiController]
    [Route("api/products")]
    public class ProductController:ControllerBase
    {
        private IProductManager _productManager;
        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] ProductSearchCriteriaVM criteria)
        {
            var products = _productManager.GetByCriteria(criteria);
                

            if (products != null && products.Any())
            {
                return Ok(products);
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
             var product =  _productManager.GetById(id);

            if (product == null)
            {
                return BadRequest("No Product Found!");
            }

            return Ok(product);
        }

        public IActionResult Post(Product product)
        {
            if (ModelState.IsValid)
            {
               var isAdded =  _productManager.Add(product);

                if (isAdded)
                {
                    return Created("/api/products/"+product.Id,product);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Product model)
        {
            var product = _productManager.GetById(id);
            if (product == null)
            {
                return BadRequest("No Product Found to Update!");
            }
            if (ModelState.IsValid)
            {
               
                    product.Name = model.Name;
                    product.Price = model.Price;
                    product.CategoryId = model.CategoryId;
                    product.IsActive = model.IsActive;
                    product.ExpireDate = model.ExpireDate;

                    bool isUpdated = _productManager.Update(product);
                    if (isUpdated)
                    {
                        return Ok();
                    }
             }


            return BadRequest(ModelState);



        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var product = _productManager.GetById(id);
            if (product == null)
            {
                return BadRequest("No Product found to Delete");
            }

            var isRemoved = _productManager.Remove(product);
            if (isRemoved)
            {
                return Ok();
            }

            return BadRequest();
        }



        
    }
}

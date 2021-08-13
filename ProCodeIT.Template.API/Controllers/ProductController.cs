using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProCodeIT.Template.BLL.Infra.Services;
using ProCodeIT.Template.Models.Dummies;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProCodeIT.Template.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDummy>>> GetAll()
        {
            var list = await _productService.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<ProductDummy>>(list));
        }

        [HttpGet("{codigoProduct}")]
        public async Task<ActionResult<ProductDummy>> Get(int codigoProduct)
        {
            var result = await _productService.GetAsync(codigoProduct);

            return Ok(_mapper.Map<ProductDummy>(result));
        }

        [HttpPost]
        public async Task<ActionResult<ProductDummy>> Insert([FromBody] ProductDummy product)
        {
            var result = await _productService.InsertAsync(product);

            return Ok(_mapper.Map<ProductDummy>(result));
        }

        [HttpPut("{codigoProduct}")]
        public async Task<ActionResult<ProductDummy>> Update(int codigoProduct, [FromBody] ProductDummy product)
        {
            var entity = await _productService.GetAsync(codigoProduct);

            if (entity == null)
            {
                return NoContent();
            }

            var result = await _productService.UpdateAsync(entity, product);

            return Ok(_mapper.Map<ProductDummy>(result));
        }

        [HttpDelete("{codigoProduct}")]
        public async Task<ActionResult> DeleteAsync(int codigoProduct)
        {
            var entity = await _productService.GetAsync(codigoProduct);

            if (entity == null)
            {
                return NoContent();
            }

            _productService.Delete(entity);

            return Ok();
        }

    }
}

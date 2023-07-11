using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Trial.Core.Caching;
using Trial.Framework;
using Trial.Service.Catalog.customerService;
using Trial.Service.DTOs.Customer;

namespace Trial.Web.Controllers
{
    public class CustomerController:TrialController
    {
        #region Field
        private readonly ICustomerService _service;
        private readonly ICacheManager _cacheManager;
        public CustomerController(ICustomerService service , ICacheManager cacheManager)
        {
            _service = service;
           _cacheManager = cacheManager;
        }
        #endregion

        #region CustomerController

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = _cacheManager.GetAsync("Customer", 60, async () => _service.SearchAllCustomer().Result);
            return Ok(list);
        }

        [HttpGet("find/{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            var customer = await _service.GetbyId(id);

            return (customer == null) ? NotFound() : Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm]CustomerDTO customerDTO)
        {
            if (customerDTO.ID != 0)
                return BadRequest();

            var customer = await _service.Register(customerDTO);
            return CreatedAtAction("FindById", new { Id = customer.ID }, customer);


        }

        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            if (!_service.IsExists(id))
                return BadRequest();
            await _service.Remove(id);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] CustomerDTO customerDTO)
        {
            if (!_service.IsExists(customerDTO.ID))
                return BadRequest();
            var customer = await _service.Update(customerDTO);
            return Ok(customer);
        }
        #endregion

    }
}

using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerCardsController : ControllerBase
    {
        private ICustomerCardService _customerCardService;

        public CustomerCardsController(ICustomerCardService customerCardService)
        {
            _customerCardService = customerCardService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _customerCardService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycustomerid")]
        public IActionResult GetByCustomerId(int customerId)
        {
            var result = _customerCardService.GetByCustomerId(customerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("add")]
        public IActionResult Add(CustomerCard customerCreditCard)
        {
            var result = _customerCardService.Add(customerCreditCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("delete")]
        public IActionResult Delete(CustomerCard customerCard)
        {
            var result = _customerCardService.Delete(customerCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("update")]
        public IActionResult Update(CustomerCard customerCard)
        {
            var result = _customerCardService.Update(customerCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}


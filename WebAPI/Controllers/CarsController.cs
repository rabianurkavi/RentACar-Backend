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
    public class CarsController : ControllerBase
    {
        ICarService _carservice;
        public CarsController(ICarService carService)
        {
            _carservice = carService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carservice.GetAll();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carservice.Add(car);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("update")]
        public IActionResult Update(Car car)
        {
            var result = _carservice.Update(car);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carservice.Delete(car);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyıd")]
        public IActionResult GetById(int id)
        {
            var result = _carservice.GetCarsByColorId(id);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getcarsdailyprice")]
        public IActionResult GetCarsDailyPrice(decimal price)
        {
            var result = _carservice.GetCarsDailyPrice(price);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result); 
        }
        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            var result = _carservice.GetCarDetails();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet]
        public IActionResult GetCarsByColorId(int colorid)
        {
            var result = _carservice.GetCarsByColorId(colorid);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

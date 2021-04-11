using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
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
       //[Authorize(Roles ="Car.List")]
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
        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carservice.Delete(car);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int carId)
        {
            var result = _carservice.GetCarsByColorId(carId);
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
        [HttpGet("getalldetails")]
        public IActionResult GetCarDetails()
        {
            var result = _carservice.GetCarDetails();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbybrand")]
        public IActionResult GetByBrand(int brandid)
        {
            var result = _carservice.GetCarsDetailByBrandId(brandid);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
       
        [HttpGet("getbycolor")]
        public IActionResult GetByColor(int colorid)
        {
            var result = _carservice.GetCarsByColorId(colorid);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getdetailsbymodelyear")]
        public IActionResult GetCarDetailsByModelYear(short min, short max)
        {
            var result = _carservice.GetCarDetailsByModelYear(min, max);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("getcardetail")]
        public IActionResult GetCarDetail(int carId)
        {
            var result = _carservice.GetCarDetail(carId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("getcarsfilterdetails")]
        public IActionResult GetCarsDetails([FromQuery] CarDetailFilterDto filterDto)
        {
            var result = _carservice.GetCarsFiltreDetails(filterDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

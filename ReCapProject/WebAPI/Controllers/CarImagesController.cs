using BusinessLogic.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
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
    public class CarImagesController : ControllerBase
    {
        
        ICarImageService _carImageService;
        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
            
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
           
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Add(file,carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update([FromForm(Name = ("Image"))] IFormFile file, [FromForm(Name = ("Id"))] int id)
        {
            var toUpdate = _carImageService.Get(id).Data;
            var result = _carImageService.Update(file,toUpdate);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete([FromForm(Name = ("Id"))] int id)
        {
            var todelete = _carImageService.Get(id).Data;
            var result = _carImageService.Delete(todelete);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

using BlazorApp.Server.Interfaces;
using BlazorApp.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICar _ICar;

        public CarController(ICar iCar)
        {
            _ICar = iCar;
        }

        [HttpGet]
        public async Task<List<Car>> Get()
        {
            return await Task.FromResult(_ICar.GetCarDetails());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Car car = _ICar.GetCarData(id);
            if (car != null)
            {
                return Ok(car);
            }
            return NotFound();
        }

        [HttpPost]
        public void Post(Car car)
        {
            _ICar.AddCar(car);
        }

        [HttpPut]
        public void Put(Car car)
        {
            _ICar.UpdateCarDetails(car);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _ICar.DeleteCar(id);
            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServidorBDs.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarsController : ControllerBase
{
    public static List<Car> cars = new List<Car>();
    public CarsController()
    {

    }
    [HttpGet]
    public IEnumerable<Car> Get()
    {
        return cars;
    }
    [HttpPost]
    public ActionResult<Car> AddCar([FromBody] Car newCar)
    { 
        cars.Add(newCar);
        return Created($"cars/{newCar.Id}", newCar);
    }
    [HttpDelete("{id}")]
    public ActionResult DeleteCar(int id)
    {
        cars.RemoveAll(car => car.Id == id);
        return NoContent();
    }
}
public class Car
{
    public int Id { get; set; }
    public required string Name { get; set; }
}

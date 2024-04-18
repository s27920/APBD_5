using Microsoft.AspNetCore.Mvc;

namespace APBD_5.Animals;

[ApiController]
[Route("/api/animals")]
public class AnimalControllers : ControllerBase
{
    private readonly IAnimalService _animalService;
    public AnimalControllers(IAnimalService animalService)
    {
        _animalService = animalService;
    }
    
    [HttpGet("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetAnimals([FromQuery] string orderBy)
    {
        var animals = _animalService.GetAnimals(orderBy);
        return Ok(animals);
    }

    [HttpPost]
    public IActionResult CreateAnimal([FromBody] CreateAnimalDTO dto)
    {
        var success = _animalService.AddAnimal(dto);
        return success ? StatusCode(StatusCodes.Status201Created) : Conflict();
    }

    [HttpPatch]
    public IActionResult ModifyAnimal([FromBody] modifyAnimalDTO dto)
    {
        var success = _animalService.ModifyAnimal(dto);
        return success ? StatusCode(StatusCodes.Status200OK) : StatusCode(StatusCodes.Status304NotModified);
    }

    [HttpDelete]
    public IActionResult DeleteAnimal([FromBody] DeleteAnimalDTO dto)
    {
        var success = _animalService.RemoveAnimal(dto);
        return success ? StatusCode(StatusCodes.Status204NoContent) : Conflict();
    }
}
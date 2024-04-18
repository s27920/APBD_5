using Microsoft.AspNetCore.Mvc;

namespace APBD_5.Animals;

public class AnimalControllers : ControllerBase
{
    private readonly IAnimalService _studentService;
    public AnimalControllers(IAnimalService studentService)
    {
        _studentService = studentService;
    }
}
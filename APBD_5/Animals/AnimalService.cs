using System.Collections;

namespace APBD_5.Animals;

public interface IAnimalService
{
    public IEnumerable<Animal> GetAnimals(string orderBy);
    public bool AddAnimal(CreateAnimalDTO dto);
    public bool RemoveAnimal(DeleteAnimalDTO dto);
    public bool ModifyAnimal(modifyAnimalDTO dto);

}

public class AnimalService : IAnimalService
{

    private readonly IAnimalRepository _animalRepository;

    public AnimalService(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    public IEnumerable<Animal> GetAnimals(string orderBy)
    {
        return _animalRepository.GetAnimals(orderBy);
    }

    public bool AddAnimal(CreateAnimalDTO dto)
    {
        return _animalRepository.AddAnimal(dto);
    }

    public bool RemoveAnimal(DeleteAnimalDTO dto)
    {
        return _animalRepository.RemoveAnimal(dto);
    }

    public bool ModifyAnimal(modifyAnimalDTO dto)
    {
        return _animalRepository.ModifyAnimal(dto);
    }
}
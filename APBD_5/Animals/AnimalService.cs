using System.Collections;

namespace APBD_5.Animals;

public interface IAnimalService
{
    public IEnumerable<Animal> GetAnimals(string orderBy);
    public bool AddAnimal()
}

public class AnimalService
{
    
}
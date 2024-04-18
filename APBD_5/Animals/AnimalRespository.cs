using System.Data.SqlClient;

namespace APBD_5.Animals;



public interface IAnimalRepository
{
    public IEnumerable<Animal> GetAnimals(string orderBy);
    public bool AddAnimal(CreateAnimalDTO dto);
    public bool RemoveAnimal(DeleteAnimalDTO dto);
    public bool ModifyAnimal(modifyAnimalDTO dto);
}

public class AnimalRespository : IAnimalRepository
{
    private readonly IConfiguration _configuration;

    public AnimalRespository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IEnumerable<Animal> GetAnimals(string orderBy)
    {
        using var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        connection.Open();
        
    }

    public bool AddAnimal(CreateAnimalDTO dto)
    {
        throw new NotImplementedException();
    }

    public bool RemoveAnimal(DeleteAnimalDTO dto)
    {
        throw new NotImplementedException();
    }

    public bool ModifyAnimal(modifyAnimalDTO dto)
    {
        throw new NotImplementedException();
    }
}
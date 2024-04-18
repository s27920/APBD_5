
using Microsoft.Data.SqlClient;

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
        
        var validatedOrderBy =
        
    }

    public bool AddAnimal(CreateAnimalDTO dto)
    {
        using var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        connection.Open();
        string name = dto.Name;
        string desc = dto.Description;
        string cat = dto.Category;
        string area = dto.Area;
        using var com = new SqlCommand("INSERT INTO Animals (Name, Description, Category, Area) VALUES (@name, @desc, @cat, @area)");
        com.Parameters.AddWithValue("@name", name);
        com.Parameters.AddWithValue("@desc", desc);
        com.Parameters.AddWithValue("@cat", cat);
        com.Parameters.AddWithValue("@area", area);
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

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
        
        var validatedOrderBy = new string[] { "IdAnimal", "Name", "Description", "Category", "Area" }.Contains(orderBy) ? orderBy : "Id";
        using var command = new SqlCommand($"SELECT Id, Email FROM Animal ORDER BY {validatedOrderBy}", connection);
        using var reader = command.ExecuteReader();
        List<Animal> animals = new List<Animal>();
        while (reader.Read())
        {
            Animal animal = new Animal()
            {
                IdAnimal = (int)reader["IdAnimal"], Name = reader["Name"].ToString()!,
                Description = reader["Description"].ToString()!, Category = reader["Category"].ToString()!,
                Area = reader["Area"].ToString()!
            };
            animals.Add(animal);
        }

        return animals;
    }

    public bool AddAnimal(CreateAnimalDTO dto)
    {
        using var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        connection.Open();
        string name = dto.Name;
        string desc = dto.Description;
        string cat = dto.Category;
        string area = dto.Area;
        using var com = new SqlCommand("INSERT INTO Animal (Name, Description, Category, Area) VALUES (@name, @desc, @cat, @area)", connection);
        com.Parameters.AddWithValue("@name", name);
        com.Parameters.AddWithValue("@desc", desc);
        com.Parameters.AddWithValue("@cat", cat);
        com.Parameters.AddWithValue("@area", area);
        int affectedRows = com.ExecuteNonQuery();
        return affectedRows == 1;
    }

    public bool RemoveAnimal(DeleteAnimalDTO dto)
    {
        using var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        connection.Open();
        int id = dto.Id;
        using SqlCommand command = new SqlCommand("DELETE FROM Animal WHERE IdAnimal = @ID", connection);
        command.Parameters.AddWithValue("@ID", id);
        int affectedRows = command.ExecuteNonQuery();
        return affectedRows == 1;
    }

    public bool ModifyAnimal(modifyAnimalDTO dto)
    {
        using var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        connection.Open();
        int id = dto.Id;
        string name = dto.Name;
        string desc = dto.Description;
        string cat = dto.Category;
        string area = dto.Area;
        using SqlCommand command = new SqlCommand("UPDATE Animal SET Name = @name, Description = @desc, Category = @cat, Area = @area WHERE IdAnimal = @ID", connection);
        command.Parameters.AddWithValue("@name", name);
        command.Parameters.AddWithValue("@desc", desc);
        command.Parameters.AddWithValue("@cat", cat);
        command.Parameters.AddWithValue("@area", area);
        command.Parameters.AddWithValue("@ID", id);
        int affectedRows = command.ExecuteNonQuery();
        return affectedRows == 1;
    }
}
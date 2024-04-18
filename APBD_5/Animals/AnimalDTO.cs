using System.ComponentModel.DataAnnotations;

namespace APBD_5.Animals;

public class CreateAnimalDTO
{
    [Required]
    public string Name{ get; set; }
    [Required]
    public string Description{ get; set; }
    [Required]
    public string Category{ get; set; }
    [Required]
    public string Area { get; set; }   
}

public class DeleteAnimalDTO
{
    public int Id { get; set; }
}

public class modifyAnimalDTO
{
    [Required]
    public int Id { get; set; }
    public string Name{ get; set; }
    public string Description{ get; set; }
    public string Category{ get; set; }
    public string Area { get; set; }  
}

public class GetAnimalsDTO
{
    public string param { get; set; }
}
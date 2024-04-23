using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecondProductShop.Models;

public class Product
{
    public int Id { get; set; }
    [StringLength(55, MinimumLength = 3, ErrorMessage = "Длина имени не должна быть меньше 3 символов и больше 55")]
    [Required(ErrorMessage = "Поле 'Имя' обязательно для заполнения")]
    public string Name { get; set; }
    [Range(50, int.MaxValue, ErrorMessage = "Минимальная цена 50 единиц")]
    [Required(ErrorMessage = "Поле 'Цена' обязательно для заполнения")]
    public int Price { get; set; }
    public DateTime DateOfCreation { get; set; }
    public DateTime? DateOfEditing { get; set; }
    public string? Description { get; set; }
    public string? Avatar { get; set; }
    [NotMapped]
    public IFormFile? ImageFile { get; set; }
    
    [Required(ErrorMessage = "Пожалуйста, выберите категорию")]
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    [Required(ErrorMessage = "Пожалуйста, выберите бренд")]
    public int BrandId { get; set; }
    public Brand? Brand { get; set; }
}
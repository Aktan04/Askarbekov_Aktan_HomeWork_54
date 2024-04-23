using System.ComponentModel.DataAnnotations;

namespace SecondProductShop.Models;

public class Category
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Поле 'Категория' обязательно для заполнения")]
    public string NameOfCategory { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace SecondProductShop.Models;

public class Brand
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Поле 'Бренд' обязательно для заполнения")]
    public string NameOfBrand { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace SecondProductShop.Models;

public class Order
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Поле 'Название' обязательно для заполнения")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Поле 'Адресс' обязательно для заполнения")]
    public string Address { get; set; }
    [Required(ErrorMessage = "Поле 'Контактный телефон' обязательно для заполнения")]
    public string ContactPhone { get; set; }
    
    public int ProductId { get; set; }
    public Product? Product { get; set; }
}
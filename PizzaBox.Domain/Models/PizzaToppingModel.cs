namespace PizzaBox.Domain.Models
{
  //Model representation of Many-to-Many relationship between Pizza and Topping
  //Does not use AModel, instead using PizzaId and ToppingId as its keys
  public class PizzaToppingModel
  {
    public int PizzaId { get; set; }
    public PizzaModel Pizza { get; set; }
    public int ToppingId { get; set; }
    public ToppingModel Topping { get; set; }
  }
}
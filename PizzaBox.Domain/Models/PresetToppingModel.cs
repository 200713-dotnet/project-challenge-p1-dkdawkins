namespace PizzaBox.Domain.Models
{
  //Model representation of Many-to-Many relationship between PresetPizza and Topping
  //Does not use AModel, instead using PresetPizzaId and ToppingId as its keys
  public class PresetToppingModel
  {
    public int PresetPizzaId { get; set; }
    public PresetPizzaModel PresetPizza { get; set; }
    public int ToppingId { get; set; }
    public ToppingModel Topping { get; set; }
  }
}
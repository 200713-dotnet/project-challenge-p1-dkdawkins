using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  public class OrderTest
  {
    // [Fact]
    // public void Test_CreatePizza()
    // {
    //   var name = "Test";
    //   var size = "S";
    //   var crust = "Normal";
    //   List<string> toppings = new List<string>{"cheese", "ham"};
    //   var sut = new Order(name);

    //   for (int i=0; i<=60; i++)
    //   {
    //     sut.CreatePizza(size, crust, toppings);
    //   }

    //   Assert.True(sut.Pizzas.Count == 50);
    // }
    private static readonly SqliteConnection _connection = new SqliteConnection("Data Source=:memory:");
    private static readonly DbContextOptions<PizzaBoxDbContext> _options = new DbContextOptionsBuilder<PizzaBoxDbContext>().UseSqlite(_connection).Options;

    public static readonly IEnumerable<object[]> _records = new List<object[]>()
    {
      new object[]
      {
        new UserModel(){Id = 1, Name = "test"},
        new StoreModel(){Id = 1, Name = "store"}
      }
    };

    [Theory]
    [MemberData(nameof(_records))]
    public async void Test_Create(UserModel user, StoreModel store)
    {
      await _connection.OpenAsync();

      try
      {
        using (var ctx = new PizzaBoxDbContext(_options))
        {
          await ctx.Database.EnsureCreatedAsync();
        }

        using (var ctx = new PizzaBoxDbContext(_options))
        {
          await ctx.Users.AddAsync(user);
          await ctx.Stores.AddAsync(store);
          await ctx.SaveChangesAsync();

          OrderRepository repo = new OrderRepository(ctx);
          for (int i=0; i<100; i++)
          {
            repo.Create(user.Id, store.Id);
          }
          Assert.NotEmpty(await ctx.Orders.ToListAsync());
        }
      }

      finally
      {
        await _connection.CloseAsync();
      }
    }
  }
}
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  public class StoreTest
  {
    private static readonly SqliteConnection _connection = new SqliteConnection("Data Source=:memory:");
    private static readonly DbContextOptions<PizzaBoxDbContext> _options = new DbContextOptionsBuilder<PizzaBoxDbContext>().UseSqlite(_connection).Options;

    public static readonly IEnumerable<object[]> _records = new List<object[]>()
    {
      new object[]
      {
        new List<StoreModel>()
        {
          new StoreModel(){Id = 1, Name = "store1"},
          new StoreModel(){Id = 2, Name = "store2"},
          new StoreModel(){Id = 3, Name = "store3"},
          new StoreModel(){Id = 4, Name = "store4"},
          new StoreModel(){Id = 5, Name = "store5"}
        }
      }
    };

    [Theory]
    [MemberData(nameof(_records))]
    public async void Test_Store(List<StoreModel> stores)
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
          StoreRepository repo = new StoreRepository(ctx);

          await ctx.Stores.AddRangeAsync(stores);
          await ctx.SaveChangesAsync();

          List<StoreModel> retStores = repo.ReadStores();

          Assert.True(retStores.Count == stores.Count);
        }

        using (var ctx = new PizzaBoxDbContext(_options))
        {
          StoreRepository repo = new StoreRepository(ctx);

          Assert.NotNull(repo.Read(stores[0].Name));
        }

        using (var ctx = new PizzaBoxDbContext(_options))
        {
          StoreRepository repo = new StoreRepository(ctx);

          Assert.NotNull(repo.Read(stores[0].Id));
        }

      }

      finally
      {
        await _connection.CloseAsync();
      }
    }
  }
}
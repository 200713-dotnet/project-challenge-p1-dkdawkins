using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  public class UserTest
  {
    private static readonly SqliteConnection _connection = new SqliteConnection("Data Source=:memory:");
    private static readonly DbContextOptions<PizzaBoxDbContext> _options = new DbContextOptionsBuilder<PizzaBoxDbContext>().UseSqlite(_connection).Options;

    public static readonly IEnumerable<object[]> _records = new List<object[]>()
    {
      new object[]
      {
        new UserModel(){Id = 1, Name = "test"}
      }
    };

    [Theory]
    [MemberData(nameof(_records))]
    public async void Test_User(UserModel user)
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
          UserRepository repo = new UserRepository(ctx);
          
          repo.Create(user.Name);

          Assert.NotNull(repo.Read(user.Name));
        }

        using (var ctx = new PizzaBoxDbContext(_options))
        {
          UserRepository repo = new UserRepository(ctx);

          Assert.NotNull(repo.Read(user.Id));
        }
      }

      finally
      {
        await _connection.CloseAsync();
      }
    }
  }
}
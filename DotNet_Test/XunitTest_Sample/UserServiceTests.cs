using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace XunitTest_Sample
{
    public class UserServiceTests
    {
        private readonly DbContextOptions<AppDbContext> _contextOptions;

        AppDbContext CreateContext() => new AppDbContext(_contextOptions);

        public UserServiceTests()
        {
            _contextOptions = new DbContextOptionsBuilder<AppDbContext>()
               .UseInMemoryDatabase("InMemoryDB")
               .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
               .Options;

            using var context = new AppDbContext(_contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.AddRange(
                new User { Id = 1, Name = "John" },
                new User { Id = 2, Name = "Jane" });

            context.SaveChanges();
        }

        [Fact]
        public void TestGetUserById_UserIsExist_ReturnUser()
        {
            // Arrange
            UserRepository userService = new UserRepository(CreateContext());
            int expectUserId = 1;

            // Act
            User? result = userService.GetUserById(expectUserId);

            // Assert
            Assert.Equal(expectUserId, result.Id);
            Assert.Equal("John", result.Name);
        }

        [Fact]
        public void TestCreateUser()
        {
            // Arrange
            UserRepository userService = new UserRepository(CreateContext());
            User newUser = new()
            {
                Name = "Test"
            };

            Assert.True(newUser.Id == 0);
            Assert.NotEmpty(newUser.Name);

            // Act
            User? result = userService.CreateUser(newUser);

            // Assert
            Assert.True(result.Id > 0);
            Assert.Equal("Test", result.Name);
        }
    }
}


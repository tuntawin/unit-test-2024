using Models;
using Moq;
using Services;

namespace XunitTest_Moq
{
    public class UserServiceTests
    {
        [Fact]
        public void TestGetUserById()
        {
            // Arrange
            var mockUserDataService = new Mock<IUserRepository>();
            mockUserDataService.Setup(x => x.GetUserById(It.IsAny<int>()))
                               .Returns(new User { Id = 1, Name = "Guy" });

            UserService userManager = new UserService(mockUserDataService.Object);

            // Act
            User? user = userManager.GetUserById(2);

            // Assert
            Assert.NotNull(user);
            Assert.Equal(1, user.Id);
            Assert.Equal("Guy", user.Name);
        }

        [Fact]
        public void TestCreateUser()
        {
            // Arrange
            var mockUserDataService = new Mock<IUserRepository>();
            mockUserDataService.Setup(x => x.CreateUser(It.IsAny<User>()))
                               .Returns((User user) =>
                               {
                                   user.Id = 1; // Simulating database-generated Id
                                   return user;
                               });

            UserService userManager = new UserService(mockUserDataService.Object);

            // Act
            User newUser = userManager.CreateUser(new User { Name = "Moh" });

            // Assert
            Assert.NotNull(newUser);
            Assert.Equal(1, newUser.Id); // Expecting Id to be 1
            Assert.Equal("Moh", newUser.Name);
        }
    }
}
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using IndigoSoftTestTask.Domain.Entities;
using IndigoSoftTestTask.Infrastructure.Data;
using IndigoSoftTestTask.Application.Users.Queries;


namespace IndigoSoftTestTask.Application.FunctionalTests;

using static Testing;

public class UserTest
{
    private ApplicationDbContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()) // Генерация уникального имени для БД в памяти
            .Options;

        return new ApplicationDbContext(options);
    }

    [Test]
    public async Task FindUsersByIpPart_ShouldReturnCorrectUsers_WhenIpPartExists()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        

        // Добавляем пользователей и их IP в базу данных
        var user1 = new User { Id = 100001 };
        var user2 = new User { Id = 1234567 };

        var ip1 = new UserIP { IPAddress = "31.214.157.141", ConnectedAt = DateTime.UtcNow, User = user1 };
        var ip2 = new UserIP { IPAddress = "62.4.36.194", ConnectedAt = DateTime.UtcNow, User = user2 };

        context.Users.AddRange(user1, user2);
        context.UserIPs.AddRange(ip1, ip2);
        await context.SaveChangesAsync();

        // Act
        var query = new FindUsersByIpPartQuery("31.214");
        var result = await SendAsync(query);
        // var result = await userService.FindUsersByIpPart("31.214");

        // Assert
        Assert.That(result.Count, Is.EqualTo(1)); // Ожидаем одного пользователя в результате
        Assert.That(result.First().Id, Is.EqualTo(100001)); // Проверяем, что вернулся правильный пользователь
    }

    [Test]
    public async Task FindUsersByIpPart_ShouldReturnEmptyList_WhenIpPartDoesNotExist()
    {
        // Arrange
        var context = GetInMemoryDbContext();

        var user1 = new User { Id = 100001 };
        var ip1 = new UserIP { IPAddress = "31.214.157.141", ConnectedAt = DateTime.UtcNow, User = user1 };

        context.Users.Add(user1);
        context.UserIPs.Add(ip1);
        await context.SaveChangesAsync();

        // Act
        //var result = await userService.FindUsersByIpPart("99.99");
        var query = new FindUsersByIpPartQuery("99.99");
        var result = await SendAsync(query);

        // Assert
        Assert.IsEmpty(result); // Ожидаем, что результат будет пустым
    }
}
